using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OAFramework
{
    public abstract class EFDataUnitCombo : EFDataUnit, IDataUnitCombo
    {
        [Required]
        [MaxLength(300), MinLength(1)]
        public string SelectedValue { get; set; }

        public override void Update(IDataUnit dataUnit)
        {
            var du = dataUnit as EFDataUnitCombo;
            if ((du != null) && (this.DataField.Equals(du.DataField)) && (this.SelectedValue != du.SelectedValue) && (du.IsValid()))
            {
                this.SelectedValue = du.SelectedValue;
            }
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(SelectedValue);
        }

        public override void FillWithValueOf(EFDataUnit dataUnit)
        {
            var du = dataUnit as EFDataUnitCombo;
            if (du != null) SelectedValue = du.SelectedValue;
            else
            {
                throw new InvalidCastException("current dataunit is not a EFDataUnitCombo");
            }
        }

        public override string ControlClassName
        {
            get
            {
                if(DataField.IsLargeControl)
                return "FiMailGUI.DataControl.ComboDataControl";
                return "FiMailGUI.DataControl.SmallComboDataControl";
            }
        }

        public override string ValueAsString()
        {
            return String.Format("SelectedValue = {0}", SelectedValue);
        }

        public abstract IList<string> GetValuesForCombo();
        public abstract bool IsStatic { get; }
    }

    public class EFDataUnitComboQuery : EFDataUnitCombo
    {
        public override IDataUnit Clone()
        {
            var clone = new EFDataUnitComboQuery();
            clone.DataField = DataField;
            clone.SelectedValue = SelectedValue;
            return clone;
        }

        public override IList<string> GetValuesForCombo()
        {
            var values = DataField.ComboValues.Select(x => x.ComboValue).ToList();
            values.Sort();
            return values;
        }

        public override bool IsStatic {
            get
            {
                return false;
            }
        }
    }

    public class EFDataUnitComboStatic : EFDataUnitCombo
    {
        public override IDataUnit Clone()
        {
            var clone = new EFDataUnitComboStatic();
            clone.DataField = DataField;
            clone.SelectedValue = SelectedValue;
            return clone;
        }

        public override IList<string> GetValuesForCombo()
        {
            if (!string.IsNullOrEmpty(DataField.ComboStaticValues)) return DataField.ComboStaticValues.Split(';', '|', ',');
            else
            {
                return new List<string>();
            }
        }

        public override bool IsStatic
        {
            get
            {
                return true;
            }
        }
    }
}
