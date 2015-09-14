/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiMailFramework
{
    [Table("TemplateFile")]
    public class EFTemplateFile
    {
        [Key]
        public int TemplateFileId { get; set; }

        [Required]
        [MaxLength(300), MinLength(1)]
        public string TemplateName { get; set; }

        public int TemplateId { get; set; }

        [ForeignKey("TemplateId")]
        public EFTemplate Template { get; set; }
    }
}
*/