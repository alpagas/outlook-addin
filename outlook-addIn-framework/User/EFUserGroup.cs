using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace OAFramework.User
{
    [Table("AddInUserGroup")]
    public class EFUserGroup
    {
        [Key]
        public int UserGroupId { get; set; }

        [Required]
        public string UserGroupName { get; set; }

        public ICollection<EFUser> Users { get; set; }

    }
}
