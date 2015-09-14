using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OAMail
{
    public class MailSelection : List<Outlook.MailItem>, IEquatable<MailSelection>
    {
        public MailSelection(Outlook.Selection selection)
        {
            var sel = selection;
            foreach (Object obj in sel)
                if (obj is Outlook.MailItem)
                    this.Add((Outlook.MailItem)obj);
        }

        public List<string> GetEntryIDs()
        {
            var result = new List<string>();
            foreach (Outlook.MailItem Mail in this)
                result.Add(Mail.EntryID);
            return result;
        }

        public bool Equals(MailSelection other)
        {
            if (this.Count != other.Count)
                return false;
            else
            {
                var IDA = other.GetEntryIDs();
                var IDB = this.GetEntryIDs();

                foreach (string S in IDA)
                    if (!IDB.Contains(S))
                        return false;
            }
            return true;
        }
    }
}
