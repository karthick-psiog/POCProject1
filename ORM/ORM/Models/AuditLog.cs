using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ORM.Models
{
    public class AuditLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int transid { get; set; }

        [ForeignKey("User")]
        [Column(Order = 0)]
        public int userid { get; set; }

        [ForeignKey("EventType")]
        [Column(Order = 1)]
        public int eventtypeid { get; set; }

        [StringLength(1000), Required]
        public String source { get; set; }

        [StringLength(1000), Required]
        public String logmessage { get; set; }

        [Required]
        public DateTime logtimestamp { get; set; }

        // Foreign Key Reference
        public User User { get; set; }
        public EventType EventType { get; set; }

    }
}