using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCM.Models;

namespace LCM.Controllers.LegalCases
{
    public class LegalCasesController : Controller
    {
        // GET: LegalCases
        Legalcases Objlc = new Legalcases();
        public ActionResult LegalCases()
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

        public JsonResult Get_DashboardUndatedCase()
        {
            try
            {
                using (LegalCaseEntities obj= new LegalCaseEntities())
                {
                    List<Vw_DashboardUndatedCase> Legal_dashb = obj.Vw_DashboardUndatedCase.ToList();
                    return Json(Legal_dashb, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Vw_DashboardUndatedCase_Details_With_TextUp(LegalCaseDashboard_details com)
        {
            try
            {
                //LegalCaseEntities objl = new LegalCaseEntities();
                string textup =HttpUtility.UrlDecode( com.TextUp.ToString());                
                List<LegalCaseDashboard_details> legalDetail = new List<LegalCaseDashboard_details>();
                if (textup == "")
                {
                    legalDetail = Objlc.Get_Dashboard_cases(textup).ToList();
                }
                else
                {
                    legalDetail = Objlc.Get_Dashboard_cases(textup).ToList();

                }
                return Json(legalDetail, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }
    
        public ActionResult CaseHeader()
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

        public ActionResult CaseReport()
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

        public ActionResult CaseSearch()
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

        public ActionResult AdvocateInsert()
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

        public string Insert_Case(PRPSetup prp)
        {
            string str = "";
            if (prp !=null)
            {
                using(LegalCaseEntities obj= new LegalCaseEntities())
                {
                    prp.Crby= Session["userid"].ToString();
                    str = Objlc.AllinOneCaseHeader(prp);
                }
            }
            return str;
        }

        public string Update_Case(PRPSetup prp)
        {
            string str = "";
            if (prp != null)
            {
                using (LegalCaseEntities obj = new LegalCaseEntities())
                {
                    str = Objlc.AllinOneCaseHeader(prp);
                }
            }
            return str;
        }


        //public string Close_Case(PRPSetup prp)
        //{
        //    string str = "";
        //    if (prp != null)
        //    {
        //        using (LegalCaseEntities obj = new LegalCaseEntities())
        //        {
        //            str = Objlc.AllinOneCaseHeader(prp);
        //        }
        //    }
        //    return str;
        //}

        


    }
}