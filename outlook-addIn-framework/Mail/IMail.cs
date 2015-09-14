using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAFramework.User;

using Outlook = Microsoft.Office.Interop.Outlook;

namespace OAFramework
{
    public interface IMail
    {
        string MailScanId { get; set; }

        string MailScanUniqueId { get; set; }

        string Subject { get; set; }

        DateTime StatusDate { get; set; }

        string StatusUser { get; set; }

        EFUserGroup UserGroup { get; set; }

        Outlook.MailItem LinkedMail { get; set; }
    }

    public interface IMailGroup
    {
        string MailGroupScanId { get; set; }

        string Subject { get; }

        string StatusUser { get; set; }

        ICollection<EFDataUnit> DataUnits { get; set; }

        ICollection<IMail> Mails { get; }

        EFMailGroup SaveMailGroup(IEnumerable<EFDataUnit> dataUnits);
        
    }
}
