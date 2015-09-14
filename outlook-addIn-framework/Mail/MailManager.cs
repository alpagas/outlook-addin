using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;

using OAFramework.Configuration;
using OAFramework.User;

using Outlook = Microsoft.Office.Interop.Outlook;
using log4net;

namespace OAFramework
{
    public static class MailManager
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(MailManager));
        private static readonly Object missing = Type.Missing;
        
        private static OAObjectsContext Context = OADBManager.Instance.DBContext;

        private static IDictionary<string, IMailGroup> _cacheMailGroups;
        private static IDictionary<string, IMail> _cacheMails;
        private static Dictionary<string, string> _mailGroupAssociation;

        private static readonly object _lockObject = new object();

        public static string GetMailGroupId(Outlook.MailItem[] items)
        {
            string mailId = GetFirstScanId(items.First());
            if (items.Count() == 1) return mailId;
            if (items.Select(GetFirstScanId).Distinct().Count() == 1) return mailId;
            return ComputeMailGroupId(items);
            
            /*
            // l'id d'un des mails du group suffit à retrouver le group
            
            string mailGroupId;
            if (!_mailGroupAssociation.TryGetValue(mailId, out mailGroupId))
            {
                if (items.Count() == 1) return mailId;

                mailGroupId = ComputeMailGroupId(items);
                foreach (var item in items)
                {
                    _mailGroupAssociation.Add(GetFirstScanId(item), mailGroupId);
                }
            }
            
            return mailGroupId;
             */
        }

        private static string ComputeMailGroupId(Outlook.MailItem[] items)
        {
            string result=string.Empty;
            for (int i = 0; i < items.Length; i++)
            {
                if (i == 0) 
                    result = GetFirstScanId(items[i]);
                else
                {
                    result = Xor(result, GetFirstScanId(items[i]));
                }
            }
            return result;
        }

        private static string Xor(string key, string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
                sb.Append((char)(input[i] ^ key[(i % key.Length)]));
            String result = sb.ToString();

            return result;
        }

        public static string GetFirstScanId(Outlook.MailItem item)
        {
            var firstScanEntry = item.UserProperties.Find("ConversationEntryId");

            if (firstScanEntry == null)
            {
                firstScanEntry = item.UserProperties.Add("ConversationEntryId", Outlook.OlUserPropertyType.olText, true, missing);
                firstScanEntry.Value = item.ConversationIndex.Substring(0,44);
                item.Save();
                return item.ConversationIndex.Substring(0, 44);
            }
            return (string)firstScanEntry.Value;
        }

        public static string GetFirstScanUniqueId(Outlook.MailItem item)
        {
            var firstScanEntry = item.UserProperties.Find("UniqueEntryId");

            if (firstScanEntry == null)
            {
                firstScanEntry = item.UserProperties.Add("UniqueEntryId", Outlook.OlUserPropertyType.olText, true, missing);
                firstScanEntry.Value = item.EntryID;
                item.Save();
                return item.EntryID;
            }
            return (string)firstScanEntry.Value;
        }
        
        public static void FillCacheWithAllMailForUser(EFUserGroup userGroup)
        {
            try
            {
                _cacheMails = Context.Mails
                    .Where(x => x.UserGroupId == userGroup.UserGroupId)
                    .Select<EFMail, IMail>(u => u)
                    .ToDictionary(x => x.MailScanId);

                _cacheMailGroups = Context.MailGroups
                    .Include(x => x.DataUnits)
                    .Include(x => x.Emails)
                    .Where(x => x.Emails.Any())
                    .Where(x => x.Emails.FirstOrDefault().UserGroup.UserGroupId == userGroup.UserGroupId)
                    .Select<EFMailGroup, IMailGroup>(u => u)
                    .ToDictionary(x => x.MailGroupScanId);
            }
            catch (Exception e)
            {
                _cacheMailGroups = new Dictionary<string, IMailGroup>();
                _cacheMails = new Dictionary<string, IMail>();
             _logger.ErrorFormat("Error while creating Mail manager cache => {0}", e);
            }
        }

        public static IMailGroup GetMailGroup(Outlook.MailItem[] items)
        {
            var key =  GetMailGroupId(items) ;

            IMail newkey = null;
            if(_cacheMails.TryGetValue(key,out newkey))
            {
                if (newkey is EFMail) key = ((EFMail)newkey).MailGroup.MailGroupScanId;
            }
        
            IMailGroup cachedObject;
            bool keyExistsInCache;
            lock (_lockObject)
            {
                keyExistsInCache = _cacheMailGroups.TryGetValue(key, out cachedObject);
            }

            if (keyExistsInCache)
            {
                return cachedObject;
            }
            else
            {
                var result = CreateMailGroupWithScanId(items);

                lock (_lockObject)
                {
                    if (!_cacheMailGroups.ContainsKey(key)) _cacheMailGroups.Add(key, result);
                }

                return result;
            }
        }

        private static IMailGroup CreateMailGroupWithScanId(Outlook.MailItem[] items)
        {
            return new BackBoneMailGroup(items);
        }

        public static EFMailGroup SaveMailGroup(IMailGroup mailgroup, IEnumerable<EFDataUnit> dataUnits)
        {
            return mailgroup.SaveMailGroup(dataUnits);
        }

        /****************cache Mail Group********************/

        public static void UpdateCacheMailGroup(EFMailGroup mailgroup)
        {
            UpdateCacheMailGroup(mailgroup, true);
        }

        public static void UpdateCacheMailGroup(EFMailGroup mailgroup, bool addNew)
        {
            lock (_lockObject)
            {
                if (_cacheMailGroups.ContainsKey(mailgroup.MailGroupScanId))
                {
                    _cacheMailGroups.Remove(mailgroup.MailGroupScanId);
                }
                if (addNew) _cacheMailGroups.Add(mailgroup.MailGroupScanId, mailgroup);

                foreach (var mail in mailgroup.Mails)
                {
                    UpdateCacheMail(mail as EFMail, addNew);
                }
            }
        }

        public static void DeleteMailGroup(IMailGroup selectedMailGroup)
        {
            var mailGroup = selectedMailGroup as EFMailGroup;

            if (mailGroup != null)
            {
                UpdateCacheMailGroup(mailGroup, false);
                
                var mailToDeleted = selectedMailGroup.Mails.ToList();
                foreach (EFMail t in mailToDeleted)
                {
                    OADBManager.Instance.DBContext.Entry(t).State = EntityState.Deleted;
                }

                var cbToDeleted = selectedMailGroup.DataUnits.ToList();
                foreach (EFDataUnit t in cbToDeleted)
                {
                    OADBManager.Instance.DBContext.Entry(t).State = EntityState.Deleted;
                }

                OADBManager.Instance.DBContext.Entry(selectedMailGroup).State = EntityState.Deleted;
                OADBManager.Instance.DBContext.SaveChanges();
            }
        }

        /****************cache Mail********************/
        
        public static void UpdateCacheMail(EFMail mail)
        {
            UpdateCacheMail(mail, true);
        }

        public static void UpdateCacheMail(EFMail mail, bool addNew)
        {
            lock (_lockObject)
            {
                if (mail != null)
                {
                    if (_cacheMails.ContainsKey(mail.MailScanId))
                    {
                        _cacheMails.Remove(mail.MailScanId);
                    }
                    if (addNew) _cacheMails.Add(mail.MailScanId, mail);
                }
            }
        }

        public static void DeleteMail(IMail selectedMail)
        {
            var mail = selectedMail as EFMail;

            if (mail != null)
            {
                UpdateCacheMail(mail, false);
                
                OADBManager.Instance.DBContext.Entry(selectedMail).State = EntityState.Deleted;
                OADBManager.Instance.DBContext.SaveChanges();
            }
        }

        public static bool IsAlreadyReferenced(IMailGroup mailGroup)
        {
            foreach (var currentmail in mailGroup.Mails)
            {
                IMail mail;
                if (_cacheMails.TryGetValue(currentmail.MailScanId, out mail))
                {
                    if ((mail is EFMail) && (((EFMail)mail).MailGroup.MailGroupScanId != mailGroup.MailGroupScanId))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
