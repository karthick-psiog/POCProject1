using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ORM.Models
{
    public class ServiceArea
    {
        [Key]
        [StringLength(6), Required]
        public string PIN { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string state { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        public Boolean? isactive { get; set; }
    }
}