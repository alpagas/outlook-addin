using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OAFramework
{
    [Table("DataFieldGroup")]
    public class EFDataFieldGroup : IField
    {
        [Key]
        public int DataFieldGroupId { get; set; }

        [Required]
        [MaxLength(50),MinLength(2)]
        public string FieldName { get; set; }

        public IDataUnit CreateDataUnit(bool createDBValue)
        {
            return null;
        }

        public IList<IField> Children
        {
            get
            {
                return DataFields.Select(x => x as IField).ToList();
            }
        }

        public ICollection<EFDataField> DataFields { get; set; }
    }
}
