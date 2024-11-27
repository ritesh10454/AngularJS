using LCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LCM.Controllers.Master
{
    public class data_Temp
    {
        public Int32 id { get; set; }
        public string MyProperty { get; set; }
    }

    public class DEPTController : Controller
    {
        // GET: DEPT
        GetLocalIP ip = new GetLocalIP();

        public ActionResult DeptMasterView()
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

        public ActionResult CompanyMasterView()
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

        public ActionResult UnitMasterView()
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

        public JsonResult Get_AllFrequency()
        {
            try
            {
                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    List<VPL_Compliance_Frequency> deptt = Obj.VPL_Compliance_Frequency.ToList();
                    return Json(deptt, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            { return Json(ex.InnerException, JsonRequestBehavior.AllowGet); }

        }
        public JsonResult Get_AllDay()
        {
            try
            {
                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    List<DD_Freq> deptt = Obj.DD_Freq.ToList();
                    return Json(deptt, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            { return Json(ex.InnerException, JsonRequestBehavior.AllowGet); }

        }
        public JsonResult Get_AllMonth()
        {
            try
            {
                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    List<MM_Freq> deptt = Obj.MM_Freq.ToList();
                    return Json(deptt, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            { return Json(ex.InnerException, JsonRequestBehavior.AllowGet); }

        }
        public JsonResult Get_AllDeptt()
        {
            try
            {
                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    List<Com_Dept_Master> deptt = Obj.Com_Dept_Master.ToList();
                    return Json(deptt, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            { return Json(ex.InnerException, JsonRequestBehavior.AllowGet); }

        }
        public JsonResult get_Session_ID()
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                List<data_Temp> company = new List<data_Temp>();
                data_Temp dp = new data_Temp();
                dp.id = Convert.ToInt32(Session["userid"]);
                company.Add(dp);
                return Json(company, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Get_DepttById(string Id)
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                int DeptID = int.Parse(Id);
                return Json(Obj.Com_Dept_Master.Find(DeptID), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Get_AllCompany()
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                List<Com_Company_Master> company = Obj.Com_Company_Master.ToList();
                return Json(company, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Get_CompanyById(string Id)
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                int CompanyCode = int.Parse(Id);
                return Json(Obj.Com_Company_Master.Find(CompanyCode), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Get_AllUnitByCompany()
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                List<Com_Unit_Master> unit = Obj.Com_Unit_Master.ToList();
                return Json(unit, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GET_ALL_EMP()
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                List<Com_Emp_Legal_Sec> Empsec = Obj.Com_Emp_Legal_Sec.ToList();
                return Json(Empsec, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Get_UnitById(Employee Employe)
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                decimal CompanyCode = Convert.ToDecimal(Employe.Emp_City);
                List<Com_Unit_Master> unitbyid = Obj.Com_Unit_Master.Where(x => x.CompanyCode == CompanyCode).ToList();
                return Json(unitbyid, JsonRequestBehavior.AllowGet);
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
        public void VPL_Compliance_Scheduling_Generate()
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                Obj.VPL_Compliance_Scheduling_Generate();
            }
        }



        public ActionResult Index()
        {
            return View();
        }
    }
}