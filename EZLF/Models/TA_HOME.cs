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
    
    public partial class TA_HOME
    {
        public decimal ID { get; set; }
        public Nullable<decimal> APPLICANTID { get; set; }
        public string ADDRESSLINE1 { get; set; }
        public string ADDRESSLINE2 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string COUNTRY { get; set; }
        public string ZIP { get; set; }
        public Nullable<decimal> SORTORDER { get; set; }
        public Nullable<System.DateTime> MOVEINDATE { get; set; }
        public Nullable<System.DateTime> MOVEOUTDATE { get; set; }
    }
}