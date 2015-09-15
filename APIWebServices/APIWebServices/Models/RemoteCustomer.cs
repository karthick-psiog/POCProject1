using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWebServices.Models
{
    public class RemoteCustomer
    {
        public int remoteuserid { get; set; }
        public string mobile { get; set; }
        public System.DateTime DOB { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string PIN { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Nullable<bool> isactive { get; set; }
    }
}