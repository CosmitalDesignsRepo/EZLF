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
    
    public partial class ORDER
    {
        public decimal ID { get; set; }
        public Nullable<decimal> USERID { get; set; }
        public System.DateTime ORDERDATE { get; set; }
        public byte PACKAGE { get; set; }
        public bool STATUS { get; set; }
        public string FIRST { get; set; }
        public string LAST { get; set; }
        public string COMPANY { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string ZIP { get; set; }
        public decimal TOTALPRICE { get; set; }
        public string NAMEONCARD { get; set; }
        public string CCNUM { get; set; }
        public Nullable<bool> CCTYPE { get; set; }
        public Nullable<System.DateTime> CCEXP { get; set; }
        public string CCCODE { get; set; }
        public string NOTES { get; set; }
        public Nullable<bool> TYPE { get; set; }
        public Nullable<bool> LENGTH { get; set; }
        public Nullable<short> PROPERTIES { get; set; }
        public Nullable<short> MONTHS { get; set; }
        public string COUNTRY { get; set; }
        public Nullable<bool> SAVEINFO { get; set; }
        public Nullable<byte> GATEWAY { get; set; }
        public Nullable<bool> ISTRANSARMOR { get; set; }
        public string PHONE { get; set; }
        public string DOMAIN { get; set; }
        public Nullable<decimal> TAUSERID { get; set; }
        public string GACLIENTID { get; set; }
        public Nullable<byte> TAORDERTYPE { get; set; }
    }
}
