using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LCM.Models
{
    public class Compliance_FrequencyDetail
    {
        public VPL_Compliance_Master_Detail complinace_Master_WithFreq { get; set; }
        public List<VPL_Compliance_Frequency_Details> complinace_Master_WithFreq_detail { get; set; }
    }
}