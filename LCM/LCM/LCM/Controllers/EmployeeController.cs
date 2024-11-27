using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCM.Models;

namespace VPL_Compliances.Controllers
{
    public class EmployeeController : Controller
    {
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
        /// <summary>  
        ///   
        /// Get All Employee  
        /// </summary>  
        /// <returns></returns>  
        public JsonResult Get_AllEmployee()
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                List<Employee> Emp = Obj.Employees.ToList();
                return Json(Emp, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Get Employee With Id  
        /// </summary>  
        /// <param name="Id"></param>  
        /// <returns></returns>  
        public JsonResult Get_EmployeeById(string Id)
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                int EmpId = int.Parse(Id);
                return Json(Obj.Employees.Find(EmpId), JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Insert New Employee  
        /// </summary>  
        /// <param name="Employe"></param>  
        /// <returns></returns>  
        public JsonResult Get_UnitById_New(Employee Employe)
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    decimal CompanyCode = Convert.ToDecimal(Employe.Emp_City);
                    List<Com_Unit_Master> unitbyid = Obj.Com_Unit_Master.Where(x => x.CompanyCode == CompanyCode).ToList();
                    return Json(unitbyid, JsonRequestBehavior.AllowGet);
                }
            
        }
        public string Insert_Employee(Employee Employe)
        {
            if (Employe != null)
            {
                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    Obj.Employees.Add(Employe);
                    Obj.SaveChanges();
                    return "Employee Added Successfully";
                }
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }
        /// <summary>  
        /// Delete Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string Delete_Employee(Employee Emp)
        {
            if (Emp != null)
            {
                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    var Emp_ = Obj.Entry(Emp);
                    if (Emp_.State == System.Data.Entity.EntityState.Detached)
                    {
                        Obj.Employees.Attach(Emp);
                        Obj.Employees.Remove(Emp);
                    }
                    Obj.SaveChanges();
                    return "Employee Deleted Successfully";
                }
            }
            else
            {
                return "Employee Not Deleted! Try Again";
            }
        }
        /// <summary>  
        /// Update Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        /// 
        public string Get_UnitById(Com_Unit_Master Employe)
        {
            using (VPLComplianceEntities Obj = new VPLComplianceEntities())
            {
                decimal CompanyCode = Employe.CompanyCode;
                List<Com_Unit_Master> unitbyid = Obj.Com_Unit_Master.Where(x => x.CompanyCode == CompanyCode).ToList();
                return "";
            }
        }
        public string Update_Employee(Employee Emp)
        {
            if (Emp != null)
            {
                using (VPLComplianceEntities Obj = new VPLComplianceEntities())
                {
                    var Emp_ = Obj.Entry(Emp);
                    Employee EmpObj = Obj.Employees.Where(x => x.Emp_Id == Emp.Emp_Id).FirstOrDefault();
                    EmpObj.Emp_Age = Emp.Emp_Age;
                    EmpObj.Emp_City = Emp.Emp_City;
                    EmpObj.Emp_Name = Emp.Emp_Name;
                    Obj.SaveChanges();
                    return "Employee Updated Successfully";
                }
            }
            else
            {
                return "Employee Not Updated! Try Again";
            }
        }
    }
}