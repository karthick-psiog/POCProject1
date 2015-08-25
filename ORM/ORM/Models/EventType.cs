using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ORM.Models
{
    public class EventType
    {
        [Key]
        public int eventtypeid { get; set; }

        [StringLength(150), Required]
        public string eventtype { get; set; }

        public Boolean? isactive { get; set; }
    }
}