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
        public string PIN { get; set; }

        public int?  isactive { get; set; }
    }
}