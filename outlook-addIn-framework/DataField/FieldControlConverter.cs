using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace OAFramework
{
    public enum FieldControlType
    {
        [Description("Text")]EFDataUnitText = 0,
        [Description("Date")]EFDataUnitDate = 1,
        [Description("CheckBox")]EFDataUnitCheck = 2,
        [Description("Label")]EFDataUnitLabel = 3,
        [Description("Link")]EFDataUnitLink = 4,
        [Description("Amount")]EFDataUnitAmount = 5,
        [Description("ComboQuery")]EFDataUnitComboQuery = 6,
        [Description("ComboStatic")]EFDataUnitComboStatic = 7,
        [Description("Number")]EFDataUnitNumber = 8
    }

    public class FieldControlConverter : EnumConverter
    {
        private Type _enumType;
        
        public FieldControlConverter(Type type)
            : base(type)
        {
            _enumType = type;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context,CultureInfo culture,object value,Type destType)
        {
            FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, value));
            var dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));

            if (dna != null) return dna.Description;
            else return value.ToString();
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType)
        {
            return srcType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            foreach (FieldInfo fi in _enumType.GetFields())
            {
                var dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));

                if ((dna != null) && ((string)value == dna.Description)) return Enum.Parse(_enumType, fi.Name);
            }
            return Enum.Parse(_enumType, (string)value);
        }
    }
}
