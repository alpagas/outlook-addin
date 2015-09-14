using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAFramework
{
    public interface IDataUnit
    {
        string ControlClassName { get; }
        EFDataField DataField { get; set; }
        IDataUnit Clone();
        bool IsValid();
        void FillWithDefaultValue();
    }

    public interface IDataUnitNumber : IDataUnit
    {
        double NumberValue { get; set; }
    }

    public interface IDataUnitText : IDataUnit
    {
        string TextValue { get; set; }
    }

    public interface IDataUnitDate : IDataUnit
    {
        DateTime DateValue { get; set; }
    }

    public interface IDataUnitCheck : IDataUnit
    {
        bool CheckValue { get; set; }
    }

    public interface IDataUnitCombo : IDataUnit
    {
        string SelectedValue { get; set; }
        IList<string> GetValuesForCombo();
        bool IsStatic {get;}
    }
    
    public interface IDataUnitLabel : IDataUnit
    {
        string LabelValue { get; set; }
    }
    public interface IDataUnitLink : IDataUnit
    {
        string LinkValue { get; set; }
    }

    public interface IDataUnitAmount : IDataUnit
    {
        double Amount { get; set; }
        string Ccy { get; set; }
    }

}
