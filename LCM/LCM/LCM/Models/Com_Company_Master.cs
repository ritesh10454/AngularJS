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
    
    public partial class Com_Company_Master
    {
        public Nullable<long> ID { get; set; }
        public decimal CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public decimal StateCode { get; set; }
        public decimal CountryCode { get; set; }
        public string GSTNo { get; set; }
        public string ContactNo { get; set; }
        public string PFNo { get; set; }
        public byte[] Logo { get; set; }
        public string Active { get; set; }
        public string Crby { get; set; }
        public string CrIP { get; set; }
        public Nullable<System.DateTime> CrDate { get; set; }
        public Nullable<decimal> CityCode { get; set; }
    }
}
