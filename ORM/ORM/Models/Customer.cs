using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ORM.Models
{
    public class Customer
    {
        // Foreign Key as Primary Key
        [Required]
        [Key, ForeignKey("User")]
        public int userid { get; set; }

        [Key]
        [StringLength(15), Required]
        public string mobile { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [StringLength(25), Required]
        public string firstname { get; set; }

        [StringLength(25)]
        public string lastname { get; set; }

        [StringLength(1500), Required]
        public string address { get; set; }

        [StringLength(50), Required]
        public string city { get; set; }

        // Foreign Key [Primart key of 'ServiceArea']
        [Key, ForeignKey("ServiceArea")]
        public int PIN { get; set; }

        [StringLength(50), Required]
        public string state { get; set; }

        [StringLength(50), Required]
        public string country { get; set; }

        // Foreign Key Reference
        public User User { get; set; }
        public ServiceArea ServiceArea { get; set; }
    }
}