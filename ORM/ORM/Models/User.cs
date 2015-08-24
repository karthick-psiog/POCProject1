using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ORM.Models
{
    public class User
    {
        [Key]
        public int userid { get; set; }

        [StringLength(50), Required]
        public string encryptedpwd { get; set; }

        [Required]
        public DateTime createddate { get; set; }

        public DateTime? lastmodifieddate { get; set; }

        public DateTime? lastlogindate { get; set; }
    }
}