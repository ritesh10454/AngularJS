using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LCM.Models;


namespace LCM.Controllers
{
    public class DashboardController : Controller
    {
        //// GET: Dashboard
        //public ActionResult Index()
        //{
        //    return View();
        //}
        Legalcases legal = new Legalcases();


        public ActionResult Dashboard()
        {
            if (Request.QueryString["ioyujwe"] != null && Request.QueryString["poiojihyyujwe"] != null)
            {
                getloginforquery();
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
                        {
                            ViewBag.userimage = "/mash-able/dark/assets/images/user.png";
                        }
                        else
                        {
                            ViewBag.userimage = "/mash-able/dark/assets/images/Girls.png";
                        }
                    }
                }
                return View();
            }
            else
            {
                return  Redirect("http://192.168.101.236/Working/Login.aspx");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        public string Logout_Session()
        {
            string str = "";
            Session.Abandon();
            str = "Closed";
            return str;
        }

        public void getloginforquery()
        {
            GetLocalIP ipad = new GetLocalIP();
            try
            {
                //if (Session["userid"] != null)
                //{
                //    if (Session["username"] != null)  {
                //        string sss = (Session["dpwd"] != null) ? Session["dpwd"].ToString() : ""; // (Request.QueryString["poiojihyyujwe"]!=null) ? Request.QueryString["poiojihyyujwe"].ToString() : "";
                //        PRPSetup p = new PRPSetup();
                //        p.ID = Decrypt((Session["userid"] != null) ? Session["userid"].ToString() : "");
                //        p.name = sss.Replace(" ", "+");
                //        p.type = ipad.GetLocalIpAddress();
                //        BL obj = new BL();

                //        if (Request.Browser.IsMobileDevice == true)
                //        {
                //            p.Active = "1";
                //        }
                //        else
                //        {
                //            p.Active = "0";
                //        }
                //        p = obj.hCM_login_chevk(p);
                //        if (p.ID == null)
                //        {
                //            return;
                //        }
                //        if (p.ID == "0")
                //        {
                //            Response.Redirect("http://192.168.101.236/");
                //        }
                //        else
                //        {
                //            Session["role"] = p.Role;
                //            Session["userid"] = p.ID;
                //            Session["loginid"] = p.logid;
                //            Session["username"] = p.userid;
                //            Session["dept"] = p.DeptName;
                //            Session["Gender"] = p.Gender;
                //            Session["UnitCode"] = p.UnitCode;
                //            getimg();
                //            ViewBag.username = "Welcome " + Session["username"].ToString() + " - " + Session["dept"].ToString() + "(" + Session["role"].ToString() + ")";
                //            //    ViewBag.Three0days= VPLCompliance_dashboard


                //        }
                //    }
                //}



                //string empiddec = Encrypt(txtusername.Text);
                string sss = Request.QueryString["poiojihyyujwe"].ToString(); // (Request.QueryString["userid"] != null) ? Request.QueryString["userid"].ToString() : "";
                PRPSetup p = new PRPSetup();
                p.ID = Decrypt(Request.QueryString["ioyujwe"].ToString());
                p.name = sss.Replace(" ", "+");
                p.type = ipad.GetLocalIpAddress();
                BL obj = new BL();

                if (Request.Browser.IsMobileDevice == true)
                {
                    p.Active = "1";
                }
                else
                {
                    p.Active = "0";
                }
                p = obj.hCM_login_chevk(p);
                if (p.ID == null)
                {
                    return;
                }
                if (p.ID == "0")
                {
                    Response.Redirect("http://192.168.101.236/Working/Login.aspx");
                }
                else
                {
                    Session["role"] = p.Role;
                    Session["userid"] = p.ID;
                    Session["loginid"] = p.logid;
                    Session["username"] = p.userid;
                    Session["dept"] = p.DeptName;
                    Session["Gender"] = p.Gender;
                    Session["UnitCode"] = p.UnitCode;
                    getimg();
                    ViewBag.username = "Welcome " + Session["username"].ToString() + " - " + Session["dept"].ToString() + "(" + Session["role"].ToString() + ")";
                    //    ViewBag.Three0days= VPLCompliance_dashboard


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public List<PRPsetupWork> LoginCheck(PRPSetup prp)
        {
            List<PRPsetupWork> pl1 = new List<PRPsetupWork>();
            BlEmployee bl = new BlEmployee();
            GetLocalIP ip = new GetLocalIP();
            string ipad= ip.GetLocalIpAddress();
            string empiddec = Encrypt(prp.ID);
            string sss = Encrypt(prp.name);
            prp.ID = empiddec;
            prp.name = sss;
            prp.type = ipad;
            if (Request.Browser.IsMobileDevice == true)
            {
                prp.Active = "1";
            }
            else
            {
                prp.Active = "0";
            }
            PRPSetup prp1 = bl.hCM_login_chevk(prp);
            if (prp1.ID=="0")
            {
                pl1.Add(new PRPsetupWork { Response = -1 , ResponseMsg=prp1.name }); 
            }
            else
            {
                Session["role"] = prp1.Role;
                Session["userid"] = prp1.ID;
                Session["loginid"] = prp1.logid;
                Session["username"] = prp1.userid;
                Session["dept"] = prp1.DeptName;
                Session["Gender"] = prp1.Gender;
                Session["UnitCode"] = prp1.UnitCode;
                getimg();
                Session["dpwd"] = sss;
                Session["duserid"] = Encrypt(prp1.ID);
                PRPsetupWork p1 = new PRPsetupWork();
                BlEmployee bl1 = new BlEmployee();
                p1.EmpID = Session["userid"].ToString();
                if (Request.Browser.IsMobileDevice == true)
                {
                    p1.ID = "1";
                }
                else
                {
                    p1.ID = "0";
                }
                pl1 = bl1.GetappAuth(p1);
                //if (Request.QueryString["TaxEmpID"] != null)
                //{
                //    Response.Redirect("/Tax/FNFTaxTaxation.aspx?TaxEmpID=" + Request.QueryString["TaxEmpID"]);
                //}
                //else
                //{
                //                    pl1 = bl1.GetappAuth(p1);
                //if (pl1.Count > 0)
                //{
                //    if (pl1.Count == 1 && pl1[0].Application_id == "1")
                //    {
                //    return RedirectToAction("Index","Dashboard");  //Response.RedirectToRoute  ("/Working/Dashboard.aspx", false);
                //    }
                //    else
                //    {
                //        Response.Redirect("/CommonScreen_App.aspx", false);
                //    }
                //}
                // }

            }
           
            return pl1;
        }

        public void getimg()
        {
            
            List <PRPSetup> pl = new List<PRPSetup>();
            BlEmployee bl = new BlEmployee();
            PRPSetup p = new PRPSetup();
            p.ID = Session["userid"].ToString();
            p.type = "photo";
            DataTable dt = new DataTable();
            dt = bl.Get_Mastertable(p);
            if (dt.Rows.Count > 0)
            {                //   var storedString = Convert.ToBase64String(pl[0].name);
                byte[] bytes = (byte[])dt.Rows[0]["name"];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                Session["img"] = "data:image/png;base64," + base64String;
            }


        }
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText.Replace(" ", "+"));
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


    }
}