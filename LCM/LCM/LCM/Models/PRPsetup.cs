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
    public class PRPSetup 
    {
        public string NoticeDeductiondays { get; set; }
        public string SIM { get; set; }
        public string Email { get; set; }
        public string Data { get; set; }
        public string NoticeEnd_DateSystem { get; set; }
        public string AllowAmount { get; set; }
        public string NoticeDays { get; set; }
        public string Notice_Period_Deduction { get; set; }
        public string MtypeFlag { get; set; }
        public string Project_RampID { get; set; }
        public string Project_Title { get; set; }
        public string Project_Desc { get; set; }
        public string Project_OBJ { get; set; }
        public string Project_Out_Come_Value { get; set; }
        public string Project_Out_Come_ValueType { get; set; }
        public string Project_Out_Come_Range { get; set; }
        public string Project_Cost_Saving { get; set; }
        public string Project_Efficiency_Type { get; set; }
        public string Project_Efficiency_Value { get; set; }
        public string ExitFormHeadID { get; set; }
        public string fileUp { get; set; }
        public string Handing_taking_ID { get; set; }
        public string Items { get; set; }
        public string Givento { get; set; }
        public string FormsHeadID { get; set; }
        public string ExitFormAnswerID { get; set; }
        public string ExitFormID { get; set; }
        public string ExitTransID { get; set; }
        public string ExitFormQuestionID { get; set; }
        public string ExitFormAnswerVal { get; set; }
        public string formid { get; set; }
        public string NoticeStartDate { get; set; }
        public string NoticeEndDate { get; set; }
        public string NoticeBY { get; set; }
        public string NoticeDate { get; set; }
        public string NName { get; set; }
        public string MName { get; set; }
        public string MDate1 { get; set; }
        public string MRemark { get; set; }
        public string MFlagName { get; set; }
        public string HODRemark { get; set; }
        public string HRRemark { get; set; }
        public string HODDate1 { get; set; }
        public string HRDate1 { get; set; }
        public string HRName { get; set; }
        public string scode { get; set; }
        public string LastDatetime { get; set; }
        public string UsedIP { get; set; }
        public string UsedDate { get; set; }
        public string usedby { get; set; }
        public string used { get; set; }
        public string securitycheckin { get; set; }
        public string securitycheckout { get; set; }
        public string securitycheckintime { get; set; }
        public string securitycheckoutime { get; set; }
        public byte[] img { get; set; }
        public string ODID { get; set; }
        public string Lock { get; set; }
        public string KmsTravelled { get; set; }
        public string Mode_Name { get; set; }
        public string DESTINATION { get; set; }
        public string STAY_Place { get; set; }
        public string billno { get; set; }
        public string PassedforRs { get; set; }
        public string CheckedforRs { get; set; }
        public string ReceiptDate { get; set; }
        public string ReceiptNo { get; set; }
        public string CashDeposited { get; set; }
        public string ImprestDrawn { get; set; }
        public string BillDate { get; set; }
        public string Magzines { get; set; }
        public string PorterCharges { get; set; }
        public string RailReservation { get; set; }
        public string IncidentalCharges { get; set; }
        public string LocalConveyance { get; set; }
        public string MonthName { get; set; }
        public string AuthS { get; set; }
        public string AuthID { get; set; }
        public string AuthDate { get; set; }
        public string AuthIP { get; set; }
        public string AllowName { get; set; }
        public string AllowID { get; set; }
        public string NoofTimes { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
        public string document { get; set; }
        public string km { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string FromStation { get; set; }
        public string ToStation { get; set; }
        public string TravelMode { get; set; }
        public string ReportAt { get; set; }
        public string NoofDays { get; set; }
        public string Stay { get; set; }
        public string Particular { get; set; }
        public string EntryType { get; set; }
        public string ODDate { get; set; }
        public string WorkingDays { get; set; }
        public string Present { get; set; }
        public string Rest { get; set; }
        public string EL { get; set; }
        public string SL { get; set; }
        public string CL { get; set; }
        public string Absent { get; set; }
        public string NH { get; set; }
        public string CO { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string HRAppFlag1 { get; set; }
        public string HodAppFlag1 { get; set; }
        public string Reason { get; set; }
        public string Role { get; set; }
        public string authtype { get; set; }
        public string TransID { get; set; }
        public string AttdDate { get; set; }
        public string inTime { get; set; }
        public string Outtime { get; set; }
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
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }
        public string GSTNo { get; set; }
        public string ContactNo { get; set; }
        public string Active { get; set; }
        public string Crby { get; set; }
        public string CrIP { get; set; }
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
        public string EndDate { get; set; }
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

        //Legal Cases Entities
        public string from { get; set; }
        public string ResponsiblePerson { get; set; }
        public string To { get; set; }
        public string fileO { get; set; }
        public string caseamount { get; set; }
        public string TypeID { get; set; }
        public string TypeName { get; set; }
        public string Dtype { get; set; }
        public string Udate { get; set; }
        public string did { get; set; }
        public string Casesummary { get; set; }
        public string Case_Hearing_Orderid { get; set; }
        public string OrderDetail { get; set; }
        public string BP { get; set; }
        public string HP { get; set; }
        public string LogsID { get; set; }
        public string Transfer_Date { get; set; }
        public string From_CourtNO { get; set; }
        public string From_Judge { get; set; }
        public string To_CourtNO { get; set; }
        public string To_Judge { get; set; }
        public string Case_Hearing_HistoryID { get; set; }
        public string BusinesDate { get; set; }
        public string HearingDate { get; set; }
        public string BusinessPurpose { get; set; }
        public string HearingPurpose { get; set; }
        public string CourtNumber { get; set; }
        public string crbyname { get; set; }
        public string PtypeName { get; set; }
        public string Ptype { get; set; }
        public string UnderActID { get; set; }
        public string UnderActName { get; set; }
        public string UnderActDesc { get; set; }
        public string UnderSectionID { get; set; }
        public string UnderSectionName { get; set; }
        public string UnderSectionDesc { get; set; }
        public string StageofCaseID { get; set; }
        public string StageofCaseName { get; set; }
        public string StageofCaseDesc { get; set; }
        public string CaseType { get; set; }
        public string FilingNumber { get; set; }
        public string FilingDate { get; set; }
        public string RegistrationNumber { get; set; }
        public string RegistrationDate { get; set; }
        public string CNRNumber { get; set; }
        public string Petitioner { get; set; }
        public string Petitioner_NAME { get; set; }
        public string Petitioner_Advocate_name { get; set; }
        public string Petitioner_Advocate { get; set; }
        public string Respondent { get; set; }
        public string Respondent_name { get; set; }
        public string Respondent_Advocate_name { get; set; }
        public string Respondent_Advocate { get; set; }
        public string Judge { get; set; }
        public string Judge_name { get; set; }
        public string UnderAct { get; set; }
        public string UnderSection { get; set; }
        public string StageofCase { get; set; }
        public string CourtNo { get; set; }
        public string Petitioner_Cum_RespondentID { get; set; }
        public string Relation { get; set; }
        public string Empid { get; set; }
        public string emailid { get; set; }
        public string JudgeId { get; set; }
        public string JudgeName { get; set; }
        public string CaseId { get; set; }
        public string CaseTypeName { get; set; }
        public string CaseTypeShort { get; set; }

        public string fullname2 { get; set; }

        public string filePath { get; set; }

        public string filename { get; set; }
        public string Image { get; set; }
        public string filetype { get; set; }

    }

    public class QueryResponse
    {
        public QueryResponse() { }
        public int Response { get; set; }
        public string ResponseMsg { get; set; }
    }

    public class UploadResponse
    {
        public UploadResponse() { }
        public int Response { get; set; }
        public string FilePath { get; set; }

        public string Image { get; set; }
        public string ResponseMsg { get; set; }
    }

    public class caseReport
    {
        public caseReport() { }
        public string SrNo { get; set; }
        public string Petitioner { get; set; }
        public string Respondent { get; set; }
        public string CaseNo { get; set; }
        public string Court { get; set; }
        public string Nature_of_case { get; set; }
        public string Amount { get; set; }
        public string LastDate { get; set; }
        public string NextDate { get; set; }
        public string Status { get; set; }
    }
     
}