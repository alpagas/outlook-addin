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
    [Table("MailGroup")]
    public class EFMailGroup : IMailGroup
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(EFMailGroup));

        public EFMailGroup()
        {
        }

        public EFMailGroup(BackBoneMailGroup backBoneMailGroup)
        {
            StatusUser = backBoneMailGroup.StatusUser;
            //UserGroup = UserManager.UserGroup;
            MailGroupScanId = backBoneMailGroup.MailGroupScanId;
            Emails = new List<EFMail>();
            foreach (var backoneMail in backBoneMailGroup.Mails)
            {
                var mail = new EFMail((BackBoneMail)backoneMail);
                mail.MailGroup = this;
                Emails.Add(mail);   
            }
        }
        [Key]
        public int MailGroupId { get; set; }

        [Required]
        public string MailGroupScanId { get; set; }

        [Required]
        public string StatusUser { get; set; }
        
        [NotMapped]
        public string Subject
        {
            get
            {
                if (Emails.Any()) return Emails.First().Subject;
                return "[EMPTY MAIL GROUP]";
            }
        }

        //public int UserGroupId { get; set; }
        //[ForeignKey("UserGroupId")]
        //public EFUserGroup UserGroup { get; set; }

        public ICollection<EFDataUnit> DataUnits { get; set; }

        public ICollection<IMail> Mails
        {
            get
            {
                return Emails.Select(x=>x as IMail).ToList()  ;
            }
        }

        public ICollection<EFMail> Emails { get; set; }
        
        public EFMailGroup SaveMailGroup(IEnumerable<EFDataUnit> dataUnits)
        {
            try
            {
                if ((DataUnits == null) || (!DataUnits.Any()))
                    DataUnits = dataUnits.ToArray();
                else
                {
                    foreach (var dataUnit in dataUnits)
                    {
                        if (DataUnits.ToList().Any(x => x.DataFieldId == dataUnit.DataFieldId))
                        {
                            foreach (var srcDataUnit in DataUnits.ToList().Where(x => x.DataFieldId == dataUnit.DataFieldId))
                                srcDataUnit.FillWithValueOf(dataUnit);
                        }
                        else
                        {
                            DataUnits.Add(dataUnit); //why not use a clone here ?
                        }
                    }
                }
                foreach (var du in DataUnits)
                {
                    _logger.InfoFormat("EFMailGroup -> Trying to update dataunits {0} value {1}", du.DataField.FieldName, du.ValueAsString());
                }

                var duToDeleted = DataUnits.Where(x => !x.IsValid()).ToList();
                for (int i = 0; i < duToDeleted.Count; i++)
                {
                    OADBManager.Instance.DBContext.Entry(duToDeleted[i]).State = EntityState.Deleted;
                }
                OADBManager.Instance.DBContext.SaveChanges();
                MailManager.UpdateCacheMailGroup(this);
                _logger.InfoFormat("EFMailGroup -> Updated {0} dataunits successfully", DataUnits.Count);
                return this;
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("EFMailGroup -> Error while Updating mail {0} {1} ", this.MailGroupId, e);
                return null;
            }
        }
        
       
    }
}
