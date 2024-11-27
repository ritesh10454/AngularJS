using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using LCM.Models;

namespace LCM.Controllers
{
    public class ComplianceMasterController : Controller
    {
        //// GET: Master
        //public ActionResult Index()
        //{
        //    return View();
        //}
        DateTime enddt = Convert.ToDateTime("9999-12-31 00:00:00.000");
        GetLocalIP ip = new GetLocalIP();

        Legalcompliances objcompl = new Legalcompliances();
        public ActionResult ComplianceDetail()
        {
            if (Session["userid"] != null)
            {
                if (Session["username"] != null)
                {
                    ViewBag.Username = Session["username"].ToString();
                    if (Session["img"] != null)
                    {
                        ViewBag.userimage = Session["img"].ToString();
                    }
                    else
                    {
                        if (Session["Gender"].ToString() == "M")
                            ViewBag.userimage = "/mash-able/dark/assets/images/user.png";
                        else
                            ViewBag.userimage = "/mash-able/dark/assets/images/Girls.png";
                    }
                }
                return View();
            }
            else
            { 
                return Redirect("http://192.168.101.236/Working/Login.aspx");
            }
        }

        public ActionResult ComplianeSelectedDetail()
        {
            if (Session["userid"] != null)
            {
                if (Session["username"] != null)
                {
                    ViewBag.Username = Session["username"].ToString();
                    if (Session["img"] != null)
                    {
                        ViewBag.userimage = Session["img"].ToString();
                    }
                    else
                    {
                        if (Session["Gender"].ToString() == "M")
                            ViewBag.userimage = "/mash-able/dark/assets/images/user.png";
                        else
                            ViewBag.userimage = "/mash-able/dark/assets/images/Girls.png";
                    }
                }
                return View();
            }
            else
            {
                return Redirect("http://192.168.101.236/Working/Login.aspx");
            }
        }

        public ActionResult ComplianceInsert()
        {
            if (Session["userid"] != null)
            {
                if (Session["username"] != null)
                {
                    ViewBag.Username = Session["username"].ToString();
                    if (Session["img"] != null)
                    {
                        ViewBag.userimage = Session["img"].ToString();
                    }
                    else
                    {
                        if (Session["Gender"].ToString() == "M")
                            ViewBag.userimage = "/mash-able/dark/assets/images/user.png";
                        else
                            ViewBag.userimage = "/mash-able/dark/assets/images/Girls.png";
                    }
                }
                return View();
            }
            else
                return Redirect("http://192.168.101.236/Working/Login.aspx");
            // return View();
        }

        public string Insert_Compliance(VPL_Compliance_Master MasterDetail, VPL_Compliance_Responsibility compliance_responsible)
        {

            if (MasterDetail != null)
            {
                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    MasterDetail.CrIP = ip.GetLocalIpAddress();
                    compliance_responsible.EmpID = MasterDetail.CrBy;
                    MasterDetail.CrBy = Convert.ToDecimal(Session["userid"].ToString());
                    MasterDetail.Isactive = 1;
                    MasterDetail.CrDate = System.DateTime.Now;
                    Obj.VPL_Compliance_Master.Add(MasterDetail);
                    Obj.SaveChanges();
                    decimal id = MasterDetail.CID;
                    compliance_responsible.CID = id;

                    compliance_responsible.StartDate = System.DateTime.Now;
                    compliance_responsible.EndDate = Convert.ToDateTime("9999-12-31 00:00:00.000");
                    compliance_responsible.Isactive = 1;
                    Obj.VPL_Compliance_Responsibility.Add(compliance_responsible);
                    Obj.SaveChanges();

                    decimal tid = compliance_responsible.TransID;
                    return id.ToString();
                }
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }
        public string Update_Compliance(VPL_Compliance_Master MasterDetail, VPL_Compliance_Responsibility compliance_responsible)
        {
            if (MasterDetail != null)
            {
                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {

                    VPL_Compliance_Master Com_Update = Obj.VPL_Compliance_Master.Where(x => x.CID == MasterDetail.CID).FirstOrDefault();

                    Com_Update.CrIP = ip.GetLocalIpAddress();
                    compliance_responsible.EmpID = MasterDetail.CrBy;
                    Com_Update.CrBy = Convert.ToDecimal(Session["userid"].ToString());
                    Com_Update.CrDate = System.DateTime.Now;
                    Com_Update.CompanyID = MasterDetail.CompanyID;
                    Com_Update.Deadline = MasterDetail.Deadline;
                    Com_Update.DeptID = MasterDetail.DeptID;
                    Com_Update.Frequency = MasterDetail.Frequency;
                    Com_Update.Name = MasterDetail.Name;
                    Com_Update.Regulate_For = MasterDetail.Regulate_For;
                    Com_Update.Regulate_Ref = MasterDetail.Regulate_Ref;
                    Com_Update.UnitID = MasterDetail.UnitID;
                    Com_Update.Deadline = MasterDetail.Deadline;
                    Com_Update.Alertbefore = MasterDetail.Alertbefore;
                    Obj.SaveChanges();
                    decimal id = MasterDetail.CID;
                    compliance_responsible.CID = id;
                    compliance_responsible.Isactive = 1;
                    Obj.SaveChanges();
                    decimal tid = compliance_responsible.TransID;
                    VPL_Compliance_Scheduling_Generate();
                    return "Compliance Updated Successfully";
                }
            }
            else
            {
                return "Employee Not Updated! Try Again";
            }
        }

        public string delete_Compliance(VPL_Compliance_Master MasterDetail)
        {
            if (MasterDetail != null)
            {
                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    VPL_Compliance_Master Com_Update = Obj.VPL_Compliance_Master.Where(x => x.CID == MasterDetail.CID).FirstOrDefault();
                    Com_Update.Isactive = 0;
                    Obj.SaveChanges();
                    return "Compliance Deleted Successfully";
                }
            }
            else
            {
                return "Compliance Not Deleted! Try Again";
            }
        }

        public JsonResult Get_VPL_Compliance_Master_Detail_withfrequency()
        {
            List<Compliance_FrequencyDetail> CO = new List<Compliance_FrequencyDetail>();
            using (VPLComplianceEntities obj = new VPLComplianceEntities())
            {
                decimal userid = Convert.ToDecimal(Session["userid"].ToString());

                var compliancelst = obj.VPL_Compliance_Master_Detail.Where(x => (x.CrBy == userid) && x.Isactive == 1).ToList();
                foreach (var i in compliancelst)
                {
                    var frequncylist = obj.VPL_Compliance_Frequency_Details.Where(a => a.ComplianceID == i.CID).OrderBy(a => a.FDID).ToList();
                    CO.Add(new Compliance_FrequencyDetail
                    {
                        complinace_Master_WithFreq = i,
                        complinace_Master_WithFreq_detail = frequncylist
                    });
                }
            }
            return new JsonResult { Data = CO, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public void VPL_Compliance_Scheduling_Generate()
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                Obj.VPL_Compliance_Scheduling_Generate();
            }
        }

        public JsonResult VPL_Compliance_InfoRequired(VPL_Compliance_InfoRequired_Detail com)
        {
            using (VPLComplianceEntities   Obj = new VPLComplianceEntities())
            {
                decimal CID = Convert.ToDecimal(com.CID);
                List<VPL_Compliance_InfoRequired_Detail> combyid = Obj.VPL_Compliance_InfoRequired_Detail.Where(x => x.CID == CID).ToList();
                return Json(combyid, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult VPL_Compliancebyid(VPL_Compliance_Master_Detail combyid)
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                decimal CID = Convert.ToDecimal(combyid.CID);
                List<VPL_Compliance_Master_Detail> combyiddata = Obj.VPL_Compliance_Master_Detail.Where(x => x.CID == CID).ToList();
                return Json(combyiddata, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult VPLCompliance_All_Staff_Detail()
        {

            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                List<StaffDetail> Emp = Obj.StaffDetails.ToList();
                return Json(Emp, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Get_VPL_Compliance_Scheduling_Detail_BYCID(VPL_Compliance_Master_Detail combyid)
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                decimal CID = Convert.ToDecimal(combyid.CID);
                List<VPL_Compliance_Schedule_Report> combyiddata = Obj.VPL_Compliance_Schedule_Report.Where(x => x.CID == CID).ToList();
                return Json(combyiddata, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult VPL_Compliance_AlertTo_Detail(VPL_Compliance_AlertTo_Detail com)
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                decimal CID = Convert.ToDecimal(com.CID);
                List<VPL_Compliance_AlertTo_Detail> combyid = Obj.VPL_Compliance_AlertTo_Detail.Where(x => x.CID == CID).ToList();
                return Json(combyid, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult VPL_Compliance_SchedulingDate(Compliance_Scheduling_detail com)
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                decimal TID = Convert.ToDecimal(com.Transid);
                List<Compliance_Scheduling_detail> combyid = Obj.Compliance_Scheduling_detail.Where(x => x.Transid == TID).ToList();
                return Json(combyid, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult VPL_Compliance_SchedulingDateLatest(VPL_Compliance_Status com)
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                decimal TID = Convert.ToDecimal(com.ScheduledID);
                int maxid = Obj.VPL_Compliance_Status.Where(x => x.ScheduledID == TID).Max(x => x.TID);
                List<VPL_Compliance_Status> combyid = Obj.VPL_Compliance_Status.Where(x => x.ScheduledID == TID & x.TID == maxid).ToList();
                return Json(combyid, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult VPL_Compliance_Schedule_Status_Detail(VPL_Compliance_Schedule_Status com)
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                decimal TID = Convert.ToDecimal(com.ScheduledID);
                List<VPL_Compliance_Schedule_Status> combyid = Obj.VPL_Compliance_Schedule_Status.Where(x => x.ScheduledID == TID).ToList();
                return Json(combyid, JsonRequestBehavior.AllowGet);
            }
        }

        public string Insert_Frequency_Details(VPL_Compliance_Master com)
        {
            if (com != null)
            {

                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    VPL_Compliance_Frequency_Details fd = new VPL_Compliance_Frequency_Details();
                    fd.ComplianceID = com.CID;
                    fd.FrequencyID = Convert.ToInt16(com.Frequency);
                    if (fd.FrequencyID == 1 || fd.FrequencyID == 4)
                    {
                        fd.DD = com.DeptID;
                        fd.MM = 0;
                        fd.YY = 1;
                        fd.isactive = 1;
                        fd.CrBy = Convert.ToDecimal(Session["userid"].ToString());
                        fd.CrIP = ip.GetLocalIpAddress();
                        fd.CrDate = System.DateTime.Now;
                        Obj.VPL_Compliance_Frequency_Details.Add(fd);
                        Obj.SaveChanges();

                    }
                    else if (fd.FrequencyID == 4)
                    {
                        fd.DD = com.DeptID;
                        fd.MM = com.CompanyID;
                        fd.YY = 1;
                        fd.isactive = 1;
                        fd.CrBy = Convert.ToDecimal(Session["userid"].ToString());
                        fd.CrIP = ip.GetLocalIpAddress();
                        fd.CrDate = System.DateTime.Now;
                        Obj.VPL_Compliance_Frequency_Details.Add(fd);
                        Obj.SaveChanges();

                    }
                    else if (fd.FrequencyID == 2)
                    {
                        fd.DD = com.DeptID;
                        fd.MM = com.CompanyID;
                        fd.YY = 1;
                        fd.isactive = 1;
                        fd.CrBy = Convert.ToDecimal(Session["userid"].ToString());
                        fd.CrIP = ip.GetLocalIpAddress();
                        fd.CrDate = System.DateTime.Now;
                        Obj.VPL_Compliance_Frequency_Details.Add(fd);
                        Obj.SaveChanges();

                        fd.DD = com.UnitID;
                        fd.MM = Convert.ToInt16(com.Name);
                        fd.YY = 1;
                        fd.isactive = 1;
                        fd.CrBy = Convert.ToDecimal(Session["userid"].ToString());
                        fd.CrIP = ip.GetLocalIpAddress();
                        fd.CrDate = System.DateTime.Now;
                        Obj.VPL_Compliance_Frequency_Details.Add(fd);
                        Obj.SaveChanges();

                        fd.DD = Convert.ToInt16(com.Regulate_Ref);
                        fd.MM = Convert.ToInt16(com.Isactive);
                        fd.YY = 1;
                        fd.isactive = 1;
                        fd.CrBy = Convert.ToDecimal(Session["userid"].ToString());
                        fd.CrIP = ip.GetLocalIpAddress();
                        fd.CrDate = System.DateTime.Now;
                        Obj.VPL_Compliance_Frequency_Details.Add(fd);
                        Obj.SaveChanges();

                        fd.DD = Convert.ToInt16(com.Alertbefore);
                        fd.MM = Convert.ToInt16(com.CrIP);
                        fd.YY = 1;
                        fd.isactive = 1;
                        fd.CrBy = Convert.ToDecimal(Session["userid"].ToString());
                        fd.CrIP = ip.GetLocalIpAddress();
                        fd.CrDate = System.DateTime.Now;
                        Obj.VPL_Compliance_Frequency_Details.Add(fd);
                        Obj.SaveChanges();
                    }
                    else if (fd.FrequencyID == 3)
                    {

                        fd.DD = com.DeptID;
                        fd.MM = com.CompanyID;
                        fd.YY = 1;
                        fd.isactive = 1;
                        fd.CrBy = Convert.ToDecimal(Session["userid"].ToString());
                        fd.CrIP = ip.GetLocalIpAddress();
                        fd.CrDate = System.DateTime.Now;
                        Obj.VPL_Compliance_Frequency_Details.Add(fd);
                        Obj.SaveChanges();

                        fd.DD = com.UnitID;
                        fd.MM = Convert.ToInt16(com.Name);
                        fd.YY = 1;
                        fd.isactive = 1;
                        fd.CrBy = Convert.ToDecimal(Session["userid"].ToString());
                        fd.CrIP = ip.GetLocalIpAddress();
                        fd.CrDate = System.DateTime.Now;
                        Obj.VPL_Compliance_Frequency_Details.Add(fd);
                        Obj.SaveChanges();
                    }
                    else if (fd.FrequencyID == 5)
                    {
                        fd.DD = 0;
                        fd.MM = 0;
                        fd.YY = 1;
                        fd.fixeddate = Convert.ToDateTime(com.CrDate);
                        fd.isactive = 1;
                        fd.CrBy = Convert.ToDecimal(Session["userid"].ToString());
                        fd.CrIP = ip.GetLocalIpAddress();
                        fd.CrDate = System.DateTime.Now;
                        Obj.VPL_Compliance_Frequency_Details.Add(fd);
                        Obj.SaveChanges();
                    }
                    return "Frequency Added Successfully";
                }
            }
            else
            {
                return "Frequency Not Inserted! Try Again";
            }
        }


        public JsonResult Get_VPL_Compliance_Master_Detail()
        {
            try
            {
                using (VPLComplianceEntities Obji = new VPLComplianceEntities())
                {
                    List<VPL_Compliance_Master_Detail> Emp = Obji.VPL_Compliance_Master_Detail.ToList();
                    return Json(Emp, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ContentResult Upload()
        {
            string path = Server.MapPath("~/UploadsStatusFiles/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (string key in Request.Files)
            {
                HttpPostedFileBase postfile = Request.Files[key];
                postfile.SaveAs(path + postfile.FileName);
            }
            return Content("success");
        }

        public JsonResult Get_VPL_complianceDashboard()
        {
            try
            {
                using(VPLComplianceEntities obj= new VPLComplianceEntities())
                {
                    List<VPLCompliance_dashboard> dashb = obj.VPLCompliance_dashboard.ToList();
                    return Json(dashb, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Get_VPL_complianceDashboard_Detail_with_color(ComplianceDashboard_details com)
        {
            try
            {
               // VPLComplianceEntities obj = new VPLComplianceEntities();
                string color = HttpUtility.UrlDecode(com.color.ToString());
                List<ComplianceDashboard_details> compDetail = new List<ComplianceDashboard_details>();
                if (color=="" )
                {
                    compDetail = objcompl.Get_Dashboard_Compliances(color).ToList();
                }
                else
                {
                    compDetail = objcompl.Get_Dashboard_Compliances(color).ToList();
                }
                return Json(compDetail, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public string Insert_Compliance_Alert_required(VPL_Compliance_AlertTo com)
        {
            if (com != null)
            {
                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    List<VPL_Compliance_AlertTo> combyid = Obj.VPL_Compliance_AlertTo.Where(x => x.CID == com.CID && x.EmpID == com.EmpID &&  x.EndDate == enddt).ToList();
                    if (combyid.Count > 0)
                        return "Employee Already Exists in the Alert To List";
                    else
                    {
                        com.StartDate = System.DateTime.Now;
                        com.EndDate = Convert.ToDateTime("9999-12-31 00:00:00.000");
                        com.Isactive = 1;
                        Obj.VPL_Compliance_AlertTo.Add(com);
                        Obj.SaveChanges();
                        return "Employee Added Successfully";
                    }
                }
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }

        public string Insert_Compliance_Info_required(VPL_Compliance_InfoRequired com)
        {
            if (com != null)
            {
                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    List<VPL_Compliance_InfoRequired> combyid = Obj.VPL_Compliance_InfoRequired.Where(x => x.CID == com.CID && x.EmpID == com.EmpID && x.EndDate == enddt).ToList();
                    if (combyid.Count > 0)
                        return "Employee Already Exists in the Information Required List";
                    else
                    {
                        com.StartDate = System.DateTime.Now;
                        com.EndDate = Convert.ToDateTime("9999-12-31 00:00:00.000");
                        com.Isactive = 1;
                        Obj.VPL_Compliance_InfoRequired.Add(com);
                        Obj.SaveChanges();
                        return "Employee Added Successfully";
                    }
                }
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }


    }
}