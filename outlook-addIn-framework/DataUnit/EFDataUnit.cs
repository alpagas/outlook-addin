using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace OAFramework
{
    [Table("DataUnit")]
    public abstract class EFDataUnit : IDataUnit
    {
        [Key]
        public int DataUnitId { get; set; }

        public int DataFieldId { get; set; }
        public int MailGroupId { get; set; }

        [ForeignKey("DataFieldId")]
        public EFDataField DataField { get; set; }

        [ForeignKey("MailGroupId")]
        public EFMailGroup MailGroup { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }

        public abstract IDataUnit Clone();

        [NotMapped]
        public abstract string ControlClassName { get;}

        public abstract void Update(IDataUnit dataUnit);

        public abstract bool IsValid();
        
        public virtual void FillWithDefaultValue()
        {
        }

        public abstract void FillWithValueOf(EFDataUnit dataUnit);

        public abstract string ValueAsString();
        

    }
}
