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
    
    public partial class VPL_Compliance_InfoRequired
    {
        public decimal TransID { get; set; }
        public Nullable<decimal> CID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> DeptID { get; set; }
        public Nullable<decimal> EmpID { get; set; }
        public Nullable<int> Isactive { get; set; }
    
        public virtual VPL_Compliance_Master VPL_Compliance_Master { get; set; }
    }
}
