using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OAFramework
{
    public class EFDataUnitCheck : EFDataUnit, IDataUnitCheck
    {
        [Required]
        public bool CheckValue { get; set; }

        public override IDataUnit Clone()
        {
            var clone = new EFDataUnitCheck();
            clone.DataField = DataField;
            clone.CheckValue = CheckValue;
            return clone;
        }

        public override void Update(IDataUnit dataUnit)
        {
            var du = dataUnit as EFDataUnitCheck;
            if ((du != null) && (this.DataField.Equals(du.DataField)) && (this.CheckValue != du.CheckValue) && (dataUnit.IsValid()))
            {
                this.CheckValue = du.CheckValue;
            }
        }

        public override bool IsValid()
        {
            return true;
        }

        public override void FillWithDefaultValue()
        {
            CheckValue = false;
        }

        public override void FillWithValueOf(EFDataUnit dataUnit)
        {
            var du = dataUnit as EFDataUnitCheck;
            if (du != null) CheckValue = du.CheckValue;
            else
            {
                throw new InvalidCastException("current dataunit is not a EFDataUnitCheck");
            }
        }

        public override string ControlClassName
        {
            get
            {
                return "FiMailGUI.DataControl.CheckDataControl";
            }
        }

        public override string ValueAsString()
        {
            return String.Format("Check Value = {0}", CheckValue);
        }

    }
}
