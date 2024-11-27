using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using LCM.Models;

namespace LCM.Controllers.Master
{
    public class MasterController : Controller
    {
        Legalcases obj_lc = new Legalcases();
        // GET: Master
        public ActionResult Index()
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

        public ActionResult Petitioner_Cum_Respondent()
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

        public ActionResult CaseType()
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

        public ActionResult CityMaster()
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

        public ActionResult DocumentType()
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

        public ActionResult JudgeMaster()
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

        public ActionResult Purpose()
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

        public ActionResult StageofCasemaster()
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

        public ActionResult UnderActmaster()
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

        public ActionResult UnderSectionmaster()
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

        public JsonResult GetPetitioner_Cum_RespondentlIst(PRPSetup prp)
        {
            try
            {
                List<PRPSetup> PetitionerList = obj_lc.GetPetitioner_Cum_RespondentlIst(prp);
                return Json(PetitionerList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException,JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCaseTypelIstwithParameter(PRPSetup prp)
        {
            try
            {
                List<PRPSetup> casetypeListNew = obj_lc.GetCaseTypelIst(prp);
                return Json(casetypeListNew, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetJudgeMasterListwithParameter(PRPSetup prp)
        {
            try
            {
                List<PRPSetup> judgeListNew = obj_lc.GetJudgeMasterList(prp);
                return Json(judgeListNew, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult GetCourtCityListwithParameter(PRPSetup prp)
        {
            try
            {
                List<PRPSetup> courtcityList = obj_lc.GetCourtCityList(prp);
                return Json(courtcityList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetDocumenttypelIstwithParameter(PRPSetup prp)
        {
            try
            {
                List<PRPSetup> PetitionerList = obj_lc.GetDocumenttypelIst(prp);
                return Json(PetitionerList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetPurposeMasterlistwithParameter(PRPSetup prp)
        {
            try
            {
                List<PRPSetup> PurposeList = obj_lc.GetPurposeMasterlist(prp);
                return Json(PurposeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetStageofCasemasterlIstwithParameter(PRPSetup prp)
        {
            try
            {
                List<PRPSetup> stageofcase = obj_lc.GetStageofCasemasterlIst(prp);
                return Json(stageofcase, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetUnderActmasterlIstwithParameter(PRPSetup prp)
        {
            try
            {
                List<PRPSetup> underActList = obj_lc.GetUnderActmasterlIst(prp);
                return Json(underActList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetUnderSectionmasterlIstwithParameter(PRPSetup prp)
        {
            try
            {
                List<PRPSetup> underSectionList = obj_lc.GetUnderSectionmasterlIst(prp);
                return Json(underSectionList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCaseDocumentslIstwithParameter(PRPSetup prp)
        {
            try
            {
                List<PRPSetup> CaseDocumentsList = obj_lc.GetCaseDocumentslIst(prp);
                return Json(CaseDocumentsList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public string AllinOneUnderActmaster(PRPSetup prp)
        {
            string str = "";
            prp.Crby =  Session["userid"].ToString();
            str = obj_lc.AllinOneUnderActmaster(prp);
            return str;
        }

        public string AllinOneUnderSectionmaster(PRPSetup prp)
        {
            string str = "";
            prp.Crby = Session["userid"].ToString();
            str = obj_lc.AllinOneUnderSectionmaster(prp);
            return str;
        }        

        public string AllinOneStageofCasemaster(PRPSetup prp)
        {
            string str = "";
            prp.Crby = Session["userid"].ToString();
            str = obj_lc.AllinOneStageofCasemaster(prp);
            return str;
        }

        public string AllinOnePurposeMaster(PRPSetup prp)
        {
            string str = "";
             prp.Crby = Session["userid"].ToString();
            str = obj_lc.AllinOnePurposeMaster(prp);
            return str;
        }

        public string AllinOneJudgeMasterMaster(PRPSetup prp)
        {
            string str = "";
            prp.Crby = Session["userid"].ToString();
            str = obj_lc.AllinOneJudgeMasterMaster(prp);
            return str;
        }
        
        public string AllinOneDocumenttype(PRPSetup prp)
        {
            string str = "";
             prp.Crby = Session["userid"].ToString();
            str = obj_lc.AllinOneDocumenttype(prp);
            return str;
        }

        public string AllinOneCourtCity(PRPSetup prp)
        {
            string str = "";
             prp.Crby = Session["userid"].ToString();
            str = obj_lc.AllinOneCourtCity(prp);
            return str;
        }

        public string AllinOneCaseTypeMaster(PRPSetup prp)
        {
            string str = "";
             prp.Crby = Session["userid"].ToString();
            str = obj_lc.AllinOneCaseTypeMaster(prp);
            return str;
        }

        public string AllinOnePetitioner_Cum_Respondent(PRPSetup prp)
        {
            string str = "";
             prp.Crby = Session["userid"].ToString();
            str = obj_lc.AllinOnePetitioner_Cum_Respondent(prp);
            return str;
        }

        public string AllinOneCase_Hearing_History(PRPSetup prp)
        {
            string str = "";
             prp.Crby = Session["userid"].ToString();
            str = obj_lc.AllinOneCase_Hearing_History(prp);
            return str;
        }

        public string AllinOneCase_Hearing_Order(PRPSetup prp)
        {
            string str = "";
             prp.Crby = Session["userid"].ToString();
            str = obj_lc.AllinOneCase_Hearing_Order(prp);
            return str;
        }


        public string AllinOneCaseDocuments(PRPSetup prp)
        {
            string str = "";
             prp.Crby = Session["userid"].ToString();
            str = obj_lc.AllinOneCaseDocuments(prp);
            return str;
        }

        //public UploadResponse getCaseDocumentFileName(PRPSetup prp)
        //{
        //    //UploadResponse res = new UploadResponse();
        //    //res = obj_lc.GetCaseDocumentFileName(prp);
        //    //return res;
        //}

        public JsonResult DeleteFile(PRPSetup prp)
        {
            QueryResponse res = new QueryResponse();
            res = obj_lc.DeleteFile(prp.Image);
            return Json(res);
        }

        public JsonResult UploadFile(string filetype, string Image, HttpPostedFileBase file)
        {
            UploadResponse res = new UploadResponse();
            res = obj_lc.UploadCaseDocumentFile(filetype, Image, file);
            return Json(res);
        }

        public JsonResult UploadOrderFile(string filetype, string Image, HttpPostedFileBase file)
        {
            UploadResponse res = new UploadResponse();
            res = obj_lc.UploadCaseOrderFile(Image, file);
            return Json(res);
        }


    }
}