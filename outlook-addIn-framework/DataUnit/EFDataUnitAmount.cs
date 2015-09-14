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
    public class EFDataUnitAmount : EFDataUnit, IDataUnitAmount
    {
        [Required]
        public double Amount { get; set; }

        [Required]
        public string Ccy { get; set; }
        
        public override IDataUnit Clone()
        {
            var clone = new EFDataUnitAmount();
            clone.DataField = DataField;
            clone.Amount = Amount;
            clone.Ccy = Ccy;
            return clone;
        }

        public override void Update(IDataUnit dataUnit)
        {
            var du = dataUnit as EFDataUnitAmount;
            if ((du != null) && (this.DataField.Equals(du.DataField)) && (du.IsValid()))
            {
                this.Amount = du.Amount;
                this.Ccy = du.Ccy;
            }
        }

        public override bool IsValid()
        {
            return !double.IsNaN(Amount) && !string.IsNullOrEmpty(Ccy);
        }

        public override void FillWithDefaultValue()
        {
            Ccy = "EUR";
            Amount = 0.0d;
        }

        public override void FillWithValueOf(EFDataUnit dataUnit)
        {
            var du = dataUnit as EFDataUnitAmount;
            if (du != null)
            {
                Amount = du.Amount;
                Ccy = du.Ccy;
            }
            else
            {
                throw new InvalidCastException("current dataunit is not a EFDataUnitAmount");
            }
        }


        public override string ControlClassName
        {
            get
            {
                return "FiMailGUI.DataControl.AmountDataControl";
            }
        }

        public override string ValueAsString()
        {
            return String.Format("{0} {1}", Amount, Ccy);
        }
    }
}
