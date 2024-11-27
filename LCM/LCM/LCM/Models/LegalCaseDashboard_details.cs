using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LCM.Models
{
    public class LegalCaseDashboard_details
    {
        public LegalCaseDashboard_details() { }
        public Nullable<Int32> sr_no { get; set; }
        public string Petitioner { get; set; }
        public string Respondent { get; set; }
        public string Case_no { get; set; }
        public string Court { get; set; }
        public string Nature_of_Case { get; set; }
        public string Amount { get; set; }
        public string Last_Date { get; set; }
        public string Next_Date { get; set; }
        public string Status { get; set; }
        public string TextUp { get; set; }
    }

    public class ComplianceDashboard_details
    {
        public ComplianceDashboard_details() { }
        public Nullable<Int32> ID { get; set; }
        public string Deadlinea { get; set; }
        public decimal CID { get; set; }
        public Nullable<int> DeptID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> UnitID { get; set; }
        public string Name { get; set; }
        public string Regulate_For { get; set; }
        public string Regulate_Ref { get; set; }
        public Nullable<int> Frequency { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public Nullable<int> Alertbefore { get; set; }
        //public Nullable<decimal> CrBy { get; set; }
        //public Nullable<System.DateTime> CrDate { get; set; }
        //public string CrIP { get; set; }
        public Nullable<int> Isactive { get; set; }
        public string CompanyName { get; set; }
        public string UnitName { get; set; }
        public string DeptName { get; set; }
        public string FullName { get; set; }
        public decimal responsiblemep { get; set; }
        public string FrequencyName { get; set; }
        public string color { get; set; }
    }
}