using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ORM.Models
{
    public class AuditLog
    {
        [Key]
        public int transid { get; set; }

        [Key] //Foreign Key [Primart key of 'Customer']
        public int userid { get; set; }

        [Key] //Foreign Key [Primart key of 'EventType']
        public int eventtypeid { get; set; }

        [StringLength(1000), Required]
        public String source { get; set; }

        [StringLength(1000), Required]
        public String logmessage { get; set; }

        [Required]
        public DateTime logtimestamp { get; set; }

        // Foreign Key Reference
        public Customer Customer { get; set; }
        public EventType EventType { get; set; }

    }
}