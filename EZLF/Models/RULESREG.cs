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
    
    public partial class RULESREG
    {
        public decimal ID { get; set; }
        public string RULE { get; set; }
        public Nullable<byte> LEASETYPE { get; set; }
        public Nullable<byte> SORTORDER { get; set; }
        public Nullable<bool> STORAGELEASE { get; set; }
        public Nullable<bool> PRINTEDLINES { get; set; }
        public Nullable<bool> VACATIONLEASE { get; set; }
        public Nullable<bool> RESIDENTIALLEASE { get; set; }
        public bool COMMERCIALLEASE { get; set; }
    }
}
