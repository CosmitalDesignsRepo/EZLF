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
    
    public partial class NEWSLETTERPROGRESS
    {
        public decimal ID { get; set; }
        public byte MAILINGTYPE { get; set; }
        public System.DateTime STARTDATE { get; set; }
        public Nullable<System.DateTime> ENDDATE { get; set; }
        public decimal TOTALRECIPIENTS { get; set; }
        public bool UNATTENDED { get; set; }
        public bool TEST { get; set; }
    }
}
