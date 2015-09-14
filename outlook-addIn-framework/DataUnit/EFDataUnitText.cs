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
    public class EFDataUnitText : EFDataUnit, IDataUnitText
    {
        [Required]
        [MaxLength(300), MinLength(1)]
        public string TextValue { get; set; }
        
        public override IDataUnit Clone()
        {
            var clone = new EFDataUnitText();
            clone.DataField = DataField;
            clone.TextValue = TextValue;
            return clone;
        }

        public override void Update(IDataUnit dataUnit)
        {
            var du = dataUnit as EFDataUnitText;
            if ((du != null) && (this.DataField.Equals(du.DataField)) && (this.TextValue != du.TextValue) && (du.IsValid()))
            {
                this.TextValue = du.TextValue;
            }
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(TextValue);
        }

        public override void FillWithValueOf(EFDataUnit dataUnit)
        {
            var du = dataUnit as EFDataUnitText;
            if (du != null) TextValue = du.TextValue;
            else
            {
                throw new InvalidCastException("current dataunit is not a EFDataUnitText");
            }
        }


        public override string ControlClassName
        {
            get
            {
                if (DataField.IsLargeControl)
                    return "FiMailGUI.DataControl.TextDataControl";
                return "FiMailGUI.DataControl.SmallTextDataControl";
            }
        }

        public override string ValueAsString()
        {
            return String.Format("Text = {0}", TextValue);
        }
    }
}
