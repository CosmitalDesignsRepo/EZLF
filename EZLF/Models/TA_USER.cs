//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EZLF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TA_USER
    {
        public decimal ID { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        public string LASTNAME { get; set; }
        public string SSN { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<byte> FCRAAGREEMENTACCEPTED { get; set; }
        public bool TURENTERCREATED { get; set; }
        public string ADMINNOTES { get; set; }
        public Nullable<System.DateTime> STARTDATE { get; set; }
        public Nullable<byte> USERACCESS { get; set; }
        public Nullable<System.DateTime> LASTLOGINDATE { get; set; }
        public Nullable<byte> MAILSTATUS { get; set; }
        public Nullable<System.DateTime> PASSWORDCHANGEDDATE { get; set; }
    }
}
