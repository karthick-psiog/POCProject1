using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    public class EmailLog
    {
        // Foreign Key as Primary Key
        [Key, ForeignKey("AuditLog")]
        [Column(Order = 0)]
        public int transid { get; set; }

        [StringLength(50), Required]
        public string emailaddress { get; set; }

        [Required]
        public int emailstatus { get; set; }

        [Required]
        public DateTime senttimestamp { get; set; }

        // Foreign Key Reference
        public AuditLog AuditLog { get; set; }
    }
}