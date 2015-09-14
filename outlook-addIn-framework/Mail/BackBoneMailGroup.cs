using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAFramework.Configuration;
using OAFramework.User;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using log4net;

namespace OAFramework
{
    public class BackBoneMailGroup : IMailGroup
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BackBoneMailGroup));

        public string MailGroupScanId { get; set; }
        
        public DateTime StatusDate { get; set; }
       
        public string StatusUser { get; set; }
        
        public ICollection<EFDataUnit> DataUnits { get; set; }

        public ICollection<IMail> Mails { get; set; }

        public string Subject
        {
            get
            {
                if (Mails.Any()) return Mails.First().Subject;
                return "[EMPTY MAIL GROUP]";
            }
        }
        
        public BackBoneMailGroup(Outlook.MailItem[] mails)
        {
            StatusDate = DateTime.Now;
            StatusUser = UserManager.UserName;
            DataUnits = new List<EFDataUnit>();
            MailGroupScanId = MailManager.GetMailGroupId(mails);
            Mails = new List<IMail>();
            foreach (var mail in mails)
            {
                Mails.Add(new BackBoneMail(mail));
            }
        }

        public EFMailGroup SaveMailGroup(IEnumerable<EFDataUnit> dataUnits)
        {
            try
            {
                var mailGroup = new EFMailGroup(this);
                
                mailGroup.DataUnits = dataUnits.ToList();
                
                foreach (var du in mailGroup.DataUnits)
                {
                    _logger.InfoFormat("EFMailGroup -> Trying to save dataunits {0} value {1}", du.DataField.FieldName, du.ValueAsString());
                }
                OADBManager.Instance.DBContext.MailGroups.Add(mailGroup);
                OADBManager.Instance.DBContext.SaveChanges();
                MailManager.UpdateCacheMailGroup(mailGroup);
                _logger.InfoFormat("EFMailGroup -> Saved {0} dataunits successfully", mailGroup.DataUnits.Count);
                return mailGroup;
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("EFMailGroup -> Error while saving mail {0} {1}", this.MailGroupScanId, e);
                return null;
            }
        }
    }
}
