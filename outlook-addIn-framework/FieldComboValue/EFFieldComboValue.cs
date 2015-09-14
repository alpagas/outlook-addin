using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace OAFramework
{
    [Table("FieldComboValue")]
    public class EFFieldComboValue
    {
        [Key]
        public int FieldComboValueId { get; set; }

        [Required]
        [MaxLength(150),MinLength(1)]
        public string ComboValue { get; set; }

        public int DataFieldId { get; set; }

        [ForeignKey("DataFieldId")]
        public EFDataField DataField { get; set; }

    }
}
