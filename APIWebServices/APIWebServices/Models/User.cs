using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWebServices.Models
{
    public class User
    {
        public String mobile { get; set; }

        public DateTime DOB { get; set; }

        public String firstname { get; set; }

        public String lastname { get; set; }

        public String address { get; set; }

        public String city { get; set; }

        public String PIN { get; set; }

        public String state { get; set; }

        public String country { get; set; }
    }
}