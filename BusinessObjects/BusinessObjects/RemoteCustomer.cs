//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessObjects
{
    using System;
    using System.Collections.Generic;
    
    public partial class RemoteCustomer
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
