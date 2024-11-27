using LCM.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LCM.Models
{
    public class ComplianceDashboard
    {
        public ComplianceDashboard() { }

        public Int32 Comp_Count { get; set; }
        public string Comp_Name { get; set; }
        public Int32 Comp_Color { get; set; }
    }
}