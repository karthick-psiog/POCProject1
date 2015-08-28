using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ORM.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userid { get; set; }

        [StringLength(100), Required]
        public string encryptedpwd { get; set; }

        [Required]
        public DateTime createddate { get; set; }

        public DateTime? lastmodifieddate { get; set; }

        public DateTime? lastlogindate { get; set; }

        public Boolean? isactive { get; set; }
    }
}