using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.Office.Interop.Outlook;

namespace OAFramework
{
    [Table("DataField")]
    public class EFDataField : IField
    {
        [Key]
        public int DataFieldId { get; set; }
 
        [Required]
        [MaxLength(150),MinLength(2)]
        public  string FieldName { get; set; }
        
        [Required]
        public FieldControlType ControlType { get; set; }

        [Required]
        public bool IsLargeControl { get; set; }

        public int DataFieldGroupId { get; set; }
        
        public string ComboStaticValues { get; set; }

        [ForeignKey("DataFieldGroupId")]
        public EFDataFieldGroup DataFieldGroup { get; set; }

        public ICollection<EFFieldComboValue> ComboValues { get; set; }

        public  IDataUnit CreateDataUnit(bool createValue)
        {
            var typeControl = Type.GetType(GetControlType(ControlType, createValue));
            var dataunit = Activator.CreateInstance(typeControl) as IDataUnit;
            dataunit.DataField = this;
            dataunit.FillWithDefaultValue();
            return dataunit;
        }

        public IList<IField> Children
        {
            get
            {
                return new List<IField>();
            }
        }
        
        private static string GetControlType(FieldControlType controlType, bool createValue)
        {
            if (controlType == FieldControlType.EFDataUnitLabel) return string.Format("FiMailFramework.BackBoneLabel");
            if (controlType == FieldControlType.EFDataUnitLink) return string.Format("FiMailFramework.BackBoneLink");
            if (createValue) return string.Format("FiMailFramework.{0}", controlType);
            return string.Format("FiMailFramework.{0}", controlType.ToString().Replace("EFDataUnit", "BackBone"));
        }
    }
}
