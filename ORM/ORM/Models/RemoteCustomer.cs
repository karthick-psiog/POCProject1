using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ORM.Models
{
    public class RemoteCustomer
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int remoteuserid { get; set; }

        [Index("mobile", 1, IsUnique = true)]
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
        
        [StringLength(6), Required]
        public string PIN { get; set; }

        [StringLength(50), Required]
        public string state { get; set; }

        [StringLength(50), Required]
        public string country { get; set; }

        public Boolean? isactive { get; set; }
    }
}