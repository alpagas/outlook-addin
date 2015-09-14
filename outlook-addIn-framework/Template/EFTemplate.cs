using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OAFramework.User;

namespace OAFramework
{
    [Table("Template")]
    public class EFTemplate : IComparable
    {
        [Key]
        public int TemplateId { get; set; }

        [Required]
        [MaxLength(300), MinLength(1)]
        public string ElementName { get; set; }

        public int UserGroupId { get; set; }

        [ForeignKey("UserGroupId")]
        public EFUserGroup UserGroup { get; set; }

        public int DataFieldId { get; set; }

        [ForeignKey("DataFieldId")]
        public EFDataField DataField { get; set; }

        public EFTemplate Parent { get; set; }

        public ICollection<EFTemplate> Children { get; set; }

        [Required]
        public int OrderIndex { get; set; }

        public void SortChildren()
        {
            if (Children != null)
            {
                Children.ToList().Sort();
            }
        }

        public int CompareTo(object obj)
        {
            var template = obj as EFTemplate;
            if (template != null)
            {
                return template.OrderIndex.CompareTo(OrderIndex);
            }
            return 0;
        }
    }
}
