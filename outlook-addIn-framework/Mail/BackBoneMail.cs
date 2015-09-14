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
    public class BackBoneMail : IMail
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BackBoneMail));

        public string MailScanId { get; set; }
        public string MailScanUniqueId { get; set; }
        
        public string Subject { get; set; }

        public EFUserGroup UserGroup
        {
            get
            {
                return UserManager.UserGroup;
            }
            set
            {
                /*do nothing*/
            }
        }

        public DateTime StatusDate { get; set; }
       
        public string StatusUser { get; set; }
        
        public Outlook.MailItem LinkedMail { get; set; }
        
        public BackBoneMail(Outlook.MailItem mailItem)
        {
            StatusDate = mailItem.ReceivedTime;
            StatusUser = UserManager.UserName;
            MailScanId = MailManager.GetFirstScanId(mailItem);
            MailScanUniqueId = MailManager.GetFirstScanUniqueId(mailItem);
            Subject = mailItem.Subject;
            LinkedMail = mailItem;
        }

        public EFMail SaveMail()
        {
            try
            {
                var mail = new EFMail(this);
                
                OADBManager.Instance.DBContext.Mails.Add(mail);
                OADBManager.Instance.DBContext.SaveChanges();
                MailManager.UpdateCacheMail(mail);
                return mail;
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("EFMail -> Error while saving mail {0} {1} => {3}", this.Subject, this.MailScanUniqueId, e);
                return null;
            }
        }
    }
}
