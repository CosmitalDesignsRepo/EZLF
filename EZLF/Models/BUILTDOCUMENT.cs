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
    
    public partial class BUILTDOCUMENT
    {
        public decimal ID { get; set; }
        public Nullable<decimal> USERID { get; set; }
        public Nullable<decimal> DOCUMENT { get; set; }
        public Nullable<bool> ISREAD { get; set; }
        public Nullable<System.DateTime> CREATED { get; set; }
        public Nullable<decimal> LEASE { get; set; }
        public Nullable<decimal> PROPERTY { get; set; }
        public Nullable<decimal> READRECEIPT { get; set; }
        public Nullable<decimal> EMAILED { get; set; }
        public Nullable<bool> ISPRINTED { get; set; }
        public string CUSTOMFIELDS { get; set; }
        public Nullable<System.DateTime> READRECEIPTDATE { get; set; }
        public Nullable<bool> ISTRIAL { get; set; }
        public Nullable<bool> PRINTING { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public Nullable<bool> LATEST { get; set; }
        public Nullable<bool> ISLEASE { get; set; }
        public string MACHINE { get; set; }
    }
}
