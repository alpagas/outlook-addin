using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OAFramework
{
    public class EFDataUnitNumber : EFDataUnit, IDataUnitNumber
    {
        [Required]
        public double NumberValue { get; set; }
        
        public override IDataUnit Clone()
        {
            var clone = new EFDataUnitNumber();
            clone.DataField = DataField;
            clone.NumberValue = NumberValue;
            return clone;
        }

        public override void Update(IDataUnit dataUnit)
        {
            var du = dataUnit as EFDataUnitNumber;
            if ((du != null) && (this.DataField.Equals(du.DataField)) && (this.NumberValue != du.NumberValue) && (du.IsValid()))
            {
                this.NumberValue = du.NumberValue;
            }
        }

        public override bool IsValid()
        {
            return !double.IsNaN(NumberValue) && !(NumberValue !=0D);
        }

        public override void FillWithValueOf(EFDataUnit dataUnit)
        {
            var du = dataUnit as EFDataUnitNumber;
            if (du != null) NumberValue = du.NumberValue;
            else
            {
                throw new InvalidCastException("current dataunit is not a EFDataUnitNumber");
            }
        }


        public override string ControlClassName
        {
            get
            {
                return "FiMailGUI.DataControl.NumberDataControl";
            }
        }

        public override string ValueAsString()
        {
            return String.Format("Number = {0}", NumberValue);
        }
    }
}
