using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAFramework;
using OAFramework.Configuration;
using OAFramework.User;

using Outlook = Microsoft.Office.Interop.Outlook;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

using log4net;
using log4net.Util;

namespace OAFramework
{
    [Table("Mail")]
    public class EFMail : IMail
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(EFMail));

        public EFMail()
        {
        }

        public EFMail(BackBoneMail backBoneMail)
        {
            MailScanId = backBoneMail.MailScanId;
            MailScanUniqueId = backBoneMail.MailScanUniqueId;
            Subject = backBoneMail.Subject;
            StatusDate = backBoneMail.StatusDate;
            StatusUser = backBoneMail.StatusUser;
            UserGroup = UserManager.UserGroup;
        }
        [Key]
        public int MailId { get; set; }

        [Required]
        public string MailScanId { get; set; }

        [Required]
        public string MailScanUniqueId { get; set; }
        
        public string Subject { get; set; }

        [Required]
        public DateTime StatusDate { get; set; }
        
        [Required]
        public string StatusUser { get; set; }

        public int UserGroupId { get; set; }

        [ForeignKey("UserGroupId")]
        public EFUserGroup UserGroup { get; set; }

        public int MailGroupId { get; set; }
        
        [ForeignKey("MailGroupId")]
        public EFMailGroup MailGroup { get; set; }

        public Outlook.MailItem LinkedMail { get; set; }
    }
}
