using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCM.Models;

namespace LCM.Controllers.Master
{
    public class CasesController : Controller
    {
        // GET: Cases
        Legalcases obj_lc = new Legalcases();
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

        public ActionResult CaseDetailFlow()
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
                string caseID = (Request.QueryString["CaseID"] != null) ? Request.QueryString["CaseID"].ToString() : "";
                ViewBag.CaseID = caseID;
                ViewBag.UserID = Session["userid"].ToString();
                return View();
            }
            else
            {
                return Redirect("http://192.168.101.236/Working/Login.aspx");
            }
        }

        public ActionResult Case_Document()
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

        public ActionResult PrintCase()
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

        public JsonResult GetCaseTypelIst()
        {
            try
            {
                List<PRPSetup> CaseTypelIst = obj_lc.GetCaseTypelIst().ToList();
                return Json(CaseTypelIst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetPetitioner_Cum_RespondentlIst_P()
        {
            try
            {
                List<PRPSetup> petitioner_P = obj_lc.GetPetitioner_Cum_RespondentlIst_P().ToList();
                return Json(petitioner_P, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetPetitioner_Cum_RespondentlIst_A()
        {
            try
            {
                List<PRPSetup> petitioner_A = obj_lc.GetPetitioner_Cum_RespondentlIst_A().ToList();
                return Json(petitioner_A, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetJudgeMasterList()
        {
            try
            {
                List<PRPSetup> JudgeMasterList = obj_lc.GetJudgeMasterList().ToList();
                return Json(JudgeMasterList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetUnderActmasterlIst()
        {
            try
            {
                List<PRPSetup> UnderActmasterlIst = obj_lc.GetUnderActmasterlIst().ToList();
                return Json(UnderActmasterlIst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetUnderSectionmasterlIst()
        {
            try
            {
                List<PRPSetup> UnderSectionmasterlIst = obj_lc.GetUnderSectionmasterlIst().ToList();
                return Json(UnderSectionmasterlIst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetStageofCasemasterlIst()
        {
            try
            {
                List<PRPSetup> StageofCasemasterlIst = obj_lc.GetStageofCasemasterlIst().ToList();
                return Json(StageofCasemasterlIst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCourtCityList()
        {
            try
            {
                List<PRPSetup> CourtCityList = obj_lc.GetCourtCityList().ToList();
                return Json(CourtCityList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetPurposeMasterlist(PRPSetup purpose)
        {
            try
            {
                List<PRPSetup> purposeList= obj_lc.GetPurposeMasterlist(purpose).ToList();
                return Json(purposeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Getresponsibleperson(PRPSetup caseOrder)
        {
            try
            {
                List<PRPSetup> resEmpList = obj_lc.Getresponsibleperson().ToList();
                return Json(resEmpList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetCase_Hearing_Orderlist(PRPSetup caseOrder)
        {
            try
            {
                List<PRPSetup> caseOrderList = obj_lc.GetCase_Hearing_Orderlist(caseOrder);
                return Json(caseOrderList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCaseHeaderlIst(PRPSetup caseHead)
        {
            try
            {
                List<PRPSetup> CaseHeaderlIst = obj_lc.GetCaseHeaderlIst(caseHead).ToList();
                return Json(CaseHeaderlIst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException,JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult case_Responsibility()
        {
            try
            {
                List<PRPSetup> case_response = obj_lc.case_Responsibility().ToList();
                return Json(case_response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCase_Hearing_HistorylIst(PRPSetup objList)
        {
            try
            {
                List<PRPSetup> hear_histList = obj_lc.GetCase_Hearing_HistorylIst(objList);
                return Json(hear_histList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public string GetCaseStatusByEmpid(PRPSetup prp)
        {
            string str = "";
            try
            {
                prp.Crby = Session["userid"].ToString();
                str = obj_lc.GetCaseStatusByEmpid(prp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return str;
        }

        public JsonResult GetCase_Transfer_Courts_Logs_List(PRPSetup objList)
        {
            try
            {
                List<PRPSetup> courts_log_List = obj_lc.GetCase_Transfer_Courts_Logs_List(objList);
                return Json(courts_log_List, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetDocumenttypelIst(PRPSetup arg1)
        {
            try
            {
                List<PRPSetup> doctypeList = obj_lc.GetDocumenttypelIst(arg1).ToList();
                return Json(doctypeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCaseDocumentslIst(PRPSetup objList)
        {
            try
            {
                List<PRPSetup> casedocList = obj_lc.GetCaseDocumentslIst(objList).ToList();
                return Json(casedocList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCaseHeaderSearchTable(PRPSetup objList)
        {
            try
            {
                List<caseReport> caseReportList = obj_lc.GetCaseHeaderSearchTable(objList);
                return Json(caseReportList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCaseHeaderSearch(PRPSetup objList)
        {
            try
            {
                List<PRPSetup> caseSearchList = obj_lc.GetCaseHeaderSearch(objList);
                return Json(caseSearchList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }



        public string AllinOneCaseHeader(PRPSetup prp)
        {
            string str = "";
            prp.Crby = Session["userid"].ToString();
            str = obj_lc.AllinOneCaseHeader(prp);
            return str;
        }

        //public ActionResult UploadFile()
        //{
        //    var file = Request.Files[0];
        //    var path = Path.Combine(Server.MapPath("~/Photos/") + file.FileName);
        //    file.SaveAs(path);

        //    // prepare a relative path to be stored in the database and used to display later on.
        //    path = Url.Content(Path.Combine("~/Photos/" + file.FileName));
        //    // save to db
        //    return Json(path.ToString(), JsonRequestBehavior.AllowGet);

        //}

        //[HttpPost]
        //public virtual string UploadFiles(object obj)
        //{
        //    var length = Request.ContentLength;
        //    var bytes = new byte[length];
        //    Request.InputStream.Read(bytes, 0, length);
        //    var fileName = Request.Headers["X-File-Name"];
        //    var fileSize = Request.Headers["X-File-Size"];
        //    var fileType = Request.Headers["X-File-Type"];

        //    var saveToFileLoc = "D:\\Images\\" + fileName;
        //    var fileStream = new FileStream(saveToFileLoc, FileMode.Create, FileAccess.ReadWrite);
        //    fileStream.Write(bytes, 0, length);
        //    fileStream.Close();

        //    return string.Format("{0} bytes uploaded", bytes.Length);
        //}

        //[HttpPost]
        //public ContentResult Upload(System.Web.HttpPostedFileBase aFile)
        //{
        //    string file = aFile.FileName;
        //    string path = Server.MapPath("../Upload//");
        //    aFile.SaveAs(path + Guid.NewGuid() + "." + file.Split('.')[1]);
        //    return Content( file.ToString());
        //}


        public QueryResponse checkValidFile()
        {
            QueryResponse res = new QueryResponse();
            string fileExtension = "";
            var supportedTypes = new[] { "png", "PNG", "jpg", "JPG", "jpeg", "JPEG", "pdf", "PDF", "doc", "DOC", "DOCX", "docx" };
            foreach (string key in Request.Files)
            {
                HttpPostedFileBase postedFile = Request.Files[key];
                fileExtension = System.IO.Path.GetExtension(postedFile.FileName);
            }
            try
            {
                if (supportedTypes.Contains(fileExtension))
                {
                    res.Response = 1; res.ResponseMsg = "SUCCESS";
                }
                else
                {
                    res.Response = -1; res.ResponseMsg = "FAILED";
                    new Exception(res.ResponseMsg);
                    
                }
            }
            catch (Exception ex)
            {
                res.Response = -1; res.ResponseMsg = ex.Message;
            }
            return res;
        }

        [HttpPost]
        public ContentResult Upload()
        {
            string path = Server.MapPath("~/Upload/");
            String filename = "";
            string strfileName = "";
            string fileExtension = "";
            string filePath = "";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (string key in Request.Files)
            {
                HttpPostedFileBase postedFile = Request.Files[key];
                postedFile.SaveAs(path + postedFile.FileName);
                filename = System.IO.Path.GetFileNameWithoutExtension(postedFile.FileName);
                fileExtension = System.IO.Path.GetExtension(postedFile.FileName);
                string strTimeStamp = System.DateTime.Now.ToString("ddMMyyhhmmss");
                //strTimeStamp += Guid.NewGuid();
                strfileName = filename + strTimeStamp + fileExtension;
                Uri urlSchema = System.Web.HttpContext.Current.Request.Url;
                string url = urlSchema.AbsoluteUri;
               // originalPath = System.Web.HttpContext.Current.Request.Url.Host; 
                filePath = url +  "/Upload/" + strfileName;

            }
            return Content(filePath);
        }

        [HttpPost]
        public ContentResult UploadFolder()
        {
            string path = Server.MapPath("~/UploadFolder/");
            String filename = "";
            string strfileName = "";
            string fileExtension = "";
            string filePath = "";
            var result = System.Web.HttpContext.Current.Request.RequestContext;
            //  var model = result.FormData["model"];
           


            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFileBase postedFile = Request.Files[key];
                postedFile.SaveAs(path + postedFile.FileName);
                filename = System.IO.Path.GetFileNameWithoutExtension(postedFile.FileName);
                fileExtension = System.IO.Path.GetExtension(postedFile.FileName);
                string strTimeStamp = System.DateTime.Now.ToString("ddMMyyhhmmss");
                //strTimeStamp += Guid.NewGuid();
                strfileName = filename + strTimeStamp + fileExtension;
                Uri uri = System.Web.HttpContext.Current.Request.Url;
                string host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                //Uri urlSchema = System.Web.HttpContext.Current.Request.Url;
                //string url = urlSchema.AbsoluteUri;

               // originalPath = System.Web.HttpContext.Current.Request.Url.Host;
                //filePath = originalPath + "/UploadFolder/" + strfileName;
                filePath = host + "/UploadFolder/" + strfileName;
            }
            return Content(filePath);
        }
    }
}