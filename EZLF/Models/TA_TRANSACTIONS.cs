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
    
    public partial class TA_TRANSACTIONS
    {
        public decimal ID { get; set; }
        public Nullable<decimal> ORDERID { get; set; }
        public string DESCRIPTION { get; set; }
        public System.DateTime TRANSDATE { get; set; }
        public Nullable<int> IP { get; set; }
        public string SITEINSTANCE { get; set; }
        public decimal TYPE { get; set; }
        public Nullable<decimal> SOURCEUSER { get; set; }
        public Nullable<decimal> TARGETUSER { get; set; }
        public decimal USERID { get; set; }
    }
}