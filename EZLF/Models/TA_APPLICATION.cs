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
    
    public partial class TA_APPLICATION
    {
        public decimal ID { get; set; }
        public Nullable<decimal> TU_APPLICATIONID { get; set; }
        public byte APPLICATIONTYPE { get; set; }
        public Nullable<decimal> PROPERTYID { get; set; }
        public Nullable<decimal> TUORGANIZATIONID { get; set; }
        public Nullable<byte> PUSHNOTIFICATION { get; set; }
        public Nullable<byte> SENDNOTIFICATION { get; set; }
        public Nullable<byte> APPLICATIONSTATUS { get; set; }
        public Nullable<decimal> ORDERID { get; set; }
        public Nullable<byte> PAIDFORSTATUS { get; set; }
        public Nullable<System.DateTime> SUBMITTEDDATE { get; set; }
        public Nullable<decimal> PRICEPERAPPLICANT { get; set; }
        public string LANDLORDPHONE { get; set; }
        public string LANDLORDEXT { get; set; }
        public Nullable<decimal> RENTAMOUNT { get; set; }
        public Nullable<decimal> LEASETERM { get; set; }
        public Nullable<decimal> DEPOSIT { get; set; }
        public Nullable<decimal> PROMOCODEID { get; set; }
        public Nullable<byte> STATUS { get; set; }
        public Nullable<System.DateTime> DATEDENIED { get; set; }
        public decimal LANDLORDID { get; set; }
        public bool LEGACYSMARTMOVE { get; set; }
        public string LANDLORDFIRSTNAME { get; set; }
        public string LANDLORDLASTNAME { get; set; }
    }
}
