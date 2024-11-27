using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
namespace LCM.Models
{
    public class PRPsetupWork
    {//inTime	Outtime
        public string WagesType { get; set; }
        public string AllowValues { get; set; }
        public string AllowID { get; set; }
        public string WorkTitle { get; set; }
        public string Wordid { get; set; }
        public string WorkType { get; set; }
        public string WorkRelateTo { get; set; }
        public string WorkDescription { get; set; }
        public string FileUpload { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public string Crby { get; set; }
        public string CrIP { get; set; }
        public string Isactive { get; set; }
        public string TaskID { get; set; }
        public string Task { get; set; }
        public string TaskFile { get; set; }
        public string TaskInvolment { get; set; }
        public string WorkTypeID { get; set; }
        public string WorkTypeName { get; set; }
        public string StatusID { get; set; }
        public string StatusName { get; set; }

        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public string TravelClass { get; set; }
        public string Tickets { get; set; }
        public string ActualFare { get; set; }
        public string BillFile { get; set; }
        public string PlaceVisit { get; set; }

        public string MemberName { get; set; }
        public string RelationShip { get; set; }
        public string Age { get; set; }
        public string AdvanceAmt { get; set; }
        public string TotLTAAmount { get; set; }


        public string formid { get; set; }
        public string Srno { get; set; }
        public string Vehicle_Modal { get; set; }
        public string Vehicle_No { get; set; }
        public string Vehicle_Type { get; set; }


        public string Application_id { get; set; }
        public string Application_Name { get; set; }
        public string Application_Detail { get; set; }
        public string Application_Path { get; set; }
        public string Application_icon { get; set; }
        public string color { get; set; }

        public string AllowValue { get; set; }
        public string BankAccountNo { get; set; }
        public string CFAmount { get; set; }
        public string BFAmount { get; set; }

        public string Gross { get; set; }
        public string CTC { get; set; }
        public string ArrNetPay { get; set; }
        public string ArrTotDeductions { get; set; }


        public string ArrTotAllowance { get; set; }
        public string NetPay { get; set; }
        public string TotalAllowance { get; set; }
        public string TotalDeductions { get; set; }


        public string ArrearDays { get; set; }
        public string TotNetPay { get; set; }
        public string WorkingDays { get; set; }
        public string FestivalDate { get; set; }
        public string FestivalName { get; set; }
        public string inTime { get; set; }
        public string Outtime { get; set; }
        public string AllowName { get; set; }
        public string monthname { get; set; }
        public string ToYr { get; set; }
        public string rest { get; set; }
        public string Present { get; set; }
        public string AttdType { get; set; }
        public string PlanShift { get; set; }
        public string ActualShift { get; set; }
        public string WorkHours { get; set; }
        public string TotalHours { get; set; }
        public string FullName { get; set; }
        public string DateOFBirth { get; set; }
        public string MainCadre { get; set; }
        public string EMPDOJ { get; set; }

        public string LeaveHours { get; set; }
        public string ODHours { get; set; }
        public string ShortLeaveHours { get; set; }

        public string AttdDate { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string role { get; set; }
        public string TotalDays { get; set; }
        public string EMP_CODE { get; set; }
        public string MONTH_NAME { get; set; }
        public string CASUAL_LEAVE { get; set; }
        public string EARNED_LEAVE { get; set; }
        public string SICK_LEAVE { get; set; }
        public string CL_AV { get; set; }
        public string EL_AV { get; set; }
        public string SL_AV { get; set; }
        public string authtype { get; set; }
        public string apptype { get; set; }
        public string hraptype { get; set; }
        public string hodapptype { get; set; }
        public string TransID { get; set; }
        public string LeaveID { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string HodAppFlag1 { get; set; }
        public string HRAppFlag1 { get; set; }
        public string HodRemarks { get; set; }

        public string Reason { get; set; }
        public string LeaveDesc { get; set; }
        public string HRRemarks { get; set; }
        public string Opening { get; set; }
        public string Hod { get; set; }
        public string Cpo { get; set; }
        public string Supervisor { get; set; }
        public string deptdesc { get; set; }
        public string PositionCode { get; set; }
        public string ID { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string CompanyID { get; set; }
        public string CompanyCode { get; set; }
        public string Place { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }
        public string GSTNo { get; set; }
        public string ContactNo { get; set; }
        public string Active { get; set; }       
        public string CrDate { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string DeptID { get; set; }
        public string DeptName { get; set; }
        public string DeptLevel { get; set; }
        public string SubDeptID { get; set; }
        public string SubDeptName { get; set; }
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string CountryID { get; set; }
        public string CountryName { get; set; }
        public string StateID { get; set; }
        public string StateName { get; set; }
        public string CityID { get; set; }
        public string CityName { get; set; }
        public string PositionID { get; set; }
        public string PositionName { get; set; }
        public string StartDate { get; set; }
        public string CostCenter { get; set; }
        public string CostCenterName { get; set; }
        public string DesinID { get; set; }
        public string EmpCadre { get; set; }
        public string EmpCadrename { get; set; }
    

        public string DesignID { get; set; }
        public string DesignName { get; set; }
        public string BankID { get; set; }
        public string BankName { get; set; }
        public string InstName { get; set; }
        public string InstID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Title { get; set; }
        public string Fullname { get; set; }
        public string DateOfBirth { get; set; }
        public string BirthPlace { get; set; }
        public string MaritalStatus { get; set; }
        public string Weddingdate { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string EmpID { get; set; }

        public string EmpStatus { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ContactNo1 { get; set; }
        public string addresstype { get; set; }

        public string paymode { get; set; }
        public string Remarks { get; set; }
        public string Bankaccno { get; set; }

        public string FTypeID { get; set; }
        public string FTypeDesc { get; set; }

        public string EduID { get; set; }
        public string StudyBranchID1 { get; set; }

        public string StudyBranchID2 { get; set; }

        public string FinalGrade { get; set; }

        public string LastExamination { get; set; }
        public string BloodGroup { get; set; }
        public string BPHigh { get; set; }
        public string BpLow { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string EyesColor { get; set; }
        public string EyeDistantVision { get; set; }
        public string EyeNearVision { get; set; }

        public string haircolor { get; set; }
        public string IdentityMark { get; set; }
        public string ColourBlindness { get; set; }

        public string IDType { get; set; }

        public string IDValue { get; set; }
        public string TotalExp { get; set; }
        public string Industry { get; set; }
        public string Salary { get; set; }

        public string CommType { get; set; }
        public string CommValue { get; set; }

        public string ScaleID { get; set; }
        public string ctc { get; set; }

        public string TimeType { get; set; }
        public string ShiftCode { get; set; }

        public string addresstypename { get; set; }

        public string IDTypeName { get; set;}

        public string EduName { get; set; }
        public string EduGroupName { get; set; }
        public string EGName { get; set; }
        public string StudyBranchName { get; set; }
        public string StudyBranchName2 { get; set; }
        public string WeekOff { get; set; }
        public string ShiftDesc { get; set; }
        public string WeekOffName { get; set; }
        public string userid { get; set; }
        public string logid { get; set; }
        public string Overtime { get; set; }
        public int Response { get; set; }
        public string ResponseMsg { get; set; }



    }
}