using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace OAFramework.User
{
    [Table("AddInUser")]
    public class EFUser
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public int UserGroupId { get; set; }

        [ForeignKey("UserGroupId")]
        public EFUserGroup UserGroup { get; set; }

    }
}
