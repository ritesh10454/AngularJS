//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LCM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VPL_Compliance_Frequency_Details
    {
        public decimal FDID { get; set; }
        public Nullable<decimal> ComplianceID { get; set; }
        public Nullable<int> FrequencyID { get; set; }
        public Nullable<int> DD { get; set; }
        public Nullable<int> MM { get; set; }
        public Nullable<int> YY { get; set; }
        public Nullable<System.DateTime> fixeddate { get; set; }
        public Nullable<int> isactive { get; set; }
        public Nullable<decimal> CrBy { get; set; }
        public Nullable<System.DateTime> CrDate { get; set; }
        public string CrIP { get; set; }
        public Nullable<int> isupdate { get; set; }
    }
}
