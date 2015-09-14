using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAFramework
{
    public class EFDataUnitDate : EFDataUnit, IDataUnitDate
    {
     
        [Required]
        public DateTime DateValue { get; set; }
        
        public override IDataUnit Clone()
        {
            var clone = new EFDataUnitDate();
            clone.DataField = DataField;
            clone.DateValue = DateValue;
            return clone;
        }

        public override void Update(IDataUnit dataUnit)
        {
            var du = dataUnit as EFDataUnitDate;
            if ((du != null) && (this.DataField.Equals(du.DataField)) && (this.DateValue != du.DateValue) && (du.IsValid()))
            {
                this.DateValue = du.DateValue;
            }
        }

        public override bool IsValid()
        {
            return ((DateValue != DateTime.MinValue) && (DateValue != DateTime.MinValue));
        }

        public override void FillWithDefaultValue()
        {
            DateValue = DateTime.MinValue;
        }

        public override void FillWithValueOf(EFDataUnit dataUnit)
        {
            var du = dataUnit as EFDataUnitDate;
            if (du != null) DateValue = du.DateValue;
            else
            {
                throw new InvalidCastException("current dataunit is not a EFDataUnitDate");
            }
        }

        public override string ControlClassName
        {
            get
            {
                if (DataField.IsLargeControl)
                return "FiMailGUI.DataControl.DateDataControl";
                return "FiMailGUI.DataControl.SmallDateDataControl";
            }
        }

        public override string ValueAsString()
        {
            return String.Format("Selected Date = {0}", DateValue);
        }
    }
}
