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
    
    public partial class DOCUMENTSTOBUILD_BATCHES
    {
        public decimal BATCH { get; set; }
        public decimal BUILDFORLEASE { get; set; }
        public decimal BUILDFORPROPERTY { get; set; }
        public Nullable<bool> EMAIL { get; set; }
        public Nullable<bool> MAIL { get; set; }
        public string CUSTOMFIELDS { get; set; }
        public Nullable<decimal> BUILTID { get; set; }
        public Nullable<System.DateTime> DOCDATE { get; set; }
        public bool USEDEVBUILDER { get; set; }
    }
}
