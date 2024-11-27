using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Collections.Generic;
using LCM.Models;

// <summary>
// Summary description for BlEmployee
// </summary>
namespace LCM.Models
{
    public class BlEmployeeWork 
    {
        //--------------------------------------------------------
        //clsBLado ADO = new clsBLado();
        //clsPRPadoBL ADOprp = new clsPRPadoBL();
        //clsPRPadoDL ADOprpDL = new clsPRPadoDL();
        //------------------------------------------------

        //select * from GET_TIME Vehicle_Master_insert
        GetIP ipad = new GetIP();
        SqlConnection sqlCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        SqlConnection sqlCnnSAP = new SqlConnection(ConfigurationManager.ConnectionStrings["ImpSAP"].ConnectionString);

        SqlCommand sqlCmd;
        public string HCM_Daily_WorkTracker_InsertAll(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[6];
                sqlCmd.Parameters.Add(new SqlParameter("@Wordid", objprp.Wordid));
                sqlCmd.Parameters.Add(new SqlParameter("@WorkType", objprp.WorkType));
                sqlCmd.Parameters.Add(new SqlParameter("@WorkRelateTo", objprp.WorkRelateTo));
                sqlCmd.Parameters.Add(new SqlParameter("@WorkTitle", objprp.WorkTitle));
                sqlCmd.Parameters.Add(new SqlParameter("@WorkDescription", objprp.WorkDescription));
                sqlCmd.Parameters.Add(new SqlParameter("@FileUpload", objprp.FileUpload));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@Status", objprp.Status));
                sqlCmd.Parameters.Add(new SqlParameter("@CrBy", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@FromTime ", objprp.FromTime));
                sqlCmd.Parameters.Add(new SqlParameter("@ToTime", objprp.ToTime));

                sqlCmd.CommandText = "HCM_Daily_WorkTracker_InsertAll";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }


        }

        List<PRPsetupWork> obj;
        public DataTable HCM_EmployeeImpreset_Select(PRPsetupWork objprp)
        {
            try
            {

                sqlCnn.Open(); sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCnnSAP;
                sqlCmd.CommandType = CommandType.Text;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.CommandText = "select * from vpp.ZIMPREST where cast(EMP_CODE as int)=" + objprp.EmpID;
                adp = new SqlDataAdapter(sqlCmd);
                adp.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                return dtable;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string Insert_HCM_EmployeeImpreset(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[6];
                sqlCmd.Parameters.Add(new SqlParameter("@TID", objprp.TransID));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@Amount", objprp.AllowValue));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@CrBy", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));

                sqlCmd.CommandText = "Insert_HCM_EmployeeImpreset";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }


        }
        public List<PRPsetupWork> HCM_Daily_WorkTracker_Dashboard(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCnn;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.CommandText = "HCM_Daily_WorkTracker_Dashboard";
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                SqlDataReader sqlReader = sqlCmd.ExecuteReader(); obj = new List<PRPsetupWork>();


                while (sqlReader.Read())
                {
                    PRPsetupWork p = new PRPsetupWork();
                    p.TotalDays = sqlReader["total"].ToString();
                    p.StatusName = sqlReader["StatusName"].ToString();
                    p.StatusID = sqlReader["StatusID"].ToString();
                    p.color = sqlReader["color"].ToString();
                    obj.Add(p);
                }
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> Vehicle_Master_display(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCnn;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.CommandText = "Vehicle_Master_display";
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.Srno));
                sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
               

                while (sqlReader.Read())
                {
                    PRPsetupWork p = new PRPsetupWork();
                    p.ID = sqlReader["id"].ToString();
                    p.Srno = sqlReader["Srno"].ToString();
                    p.Vehicle_Modal = sqlReader["Vehicle_Modal"].ToString();
                    p.Vehicle_No = sqlReader["Vehicle_No"].ToString();
                    p.Application_Detail = sqlReader["Vehicle_Modal"].ToString() + " - " + sqlReader["Vehicle_No"].ToString();
                    p.Vehicle_Type = sqlReader["Vehicle_Type"].ToString();
                    p.UnitCode = sqlReader["unit"].ToString();
                    obj.Add(p);
                }
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        DataSet ds1 = new DataSet();
        public List<PRPsetupWork> Get_Master(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCnn;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.CommandText = "Get_Master";
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                SqlDataReader sqlReader = sqlCmd.ExecuteReader(); obj = new List<PRPsetupWork>();


                while (sqlReader.Read())
                {
                    PRPsetupWork p = new PRPsetupWork();
                    p.ID = sqlReader["id"].ToString();
                    p.name = sqlReader["name"].ToString();
                    obj.Add(p);
                }
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_report(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCnn;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.CommandText = "HCM_report";
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@allow", objprp.AllowName));
                SqlDataReader sqlReader = sqlCmd.ExecuteReader(); obj = new List<PRPsetupWork>();


                while (sqlReader.Read())
                {
                    PRPsetupWork p = new PRPsetupWork();
                    p.EmpID = sqlReader["Empid"].ToString();
                    p.AllowID = sqlReader["AllowID"].ToString();
                    p.AllowName = sqlReader["AllowName"].ToString();
                    p.AllowValues = sqlReader["AllowValues"].ToString();// +" "+ sqlReader["Extraline"].ToString();
                    p.WagesType = sqlReader["WagesType"].ToString();
                    p.name = sqlReader["Extraline"].ToString();
                    obj.Add(p);
                }
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public DataTable HCM_App_Version()
        {
            try
            {

                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.CommandText = "HCM_App_Version";
                adp = new SqlDataAdapter(sqlCmd);
                adp.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                return dtable;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public DataTable HCM_FNF_Emp(PRPsetupWork objprp)
        {
            try
            {

                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.CommandText = "HCM_FNF_Emp";
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                adp = new SqlDataAdapter(sqlCmd);
                adp.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                return dtable;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public DataTable HCM_FNF_Tax_List(PRPsetupWork objprp)
        {
            try
            {

                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.CommandText = "HCM_FNF_Tax_List";
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                adp = new SqlDataAdapter(sqlCmd);
                adp.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                return dtable;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_InsertTDS_Portal(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[6];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@AllowAmount", objprp.AllowValue));
                sqlCmd.Parameters.Add(new SqlParameter("@Remarks", objprp.Remarks));
                sqlCmd.Parameters.Add(new SqlParameter("@CrBy", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));

                sqlCmd.CommandText = "HCM_InsertTDS_Portal";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }


        }
        public DataTable HCM_Daily_WorkTrackerSelect(PRPsetupWork objprp)
        {
            try
            {               

                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.CommandText = "HCM_Daily_WorkTrackerSelect";
                sqlCmd.Parameters.Add(new SqlParameter("@Wordid", objprp.Wordid));
                sqlCmd.Parameters.Add(new SqlParameter("@WorkType", objprp.WorkType));
                sqlCmd.Parameters.Add(new SqlParameter("@WorkRelateTo", objprp.WorkRelateTo));
                sqlCmd.Parameters.Add(new SqlParameter("@WorkTitle", objprp.WorkTitle));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@CrBy", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@Status", objprp.Status));
                adp = new SqlDataAdapter(sqlCmd);
                adp.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                return dtable;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> ED_proc_getmasters(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCnn;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.CommandText = "ED_proc_getmasters";
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                SqlDataReader sqlReader = sqlCmd.ExecuteReader(); obj = new List<PRPsetupWork>();


                while (sqlReader.Read())
                {
                    PRPsetupWork p = new PRPsetupWork();
                    p.ID = sqlReader["id"].ToString();
                    p.name = sqlReader["name"].ToString();
                    obj.Add(p);
                }
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string Vehicle_Master_insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[6];
                sqlCmd.Parameters.Add(new SqlParameter("@Srno", objprp.Srno));
                sqlCmd.Parameters.Add(new SqlParameter("@Vehicle_Modal", objprp.Vehicle_Modal));
                sqlCmd.Parameters.Add(new SqlParameter("@Vehicle_No", objprp.Vehicle_No));
                sqlCmd.Parameters.Add(new SqlParameter("@Vehicle_Type", objprp.Vehicle_Type));
                sqlCmd.Parameters.Add(new SqlParameter("@unit", objprp.UnitCode));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));

                sqlCmd.CommandText = "Vehicle_Master_insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }


        }
        public string VPLHCM_ChangePHOTO(PRPSetup objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@photo", objprp.ODDate));

                // insertCMD.Parameters.Add("@photo", SqlDbType.VarBinary, -1).Value = DBNull.Value;

                sqlCmd.CommandText = "VPLHCM_ChangePHOTO";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }


        }
        SqlDataAdapter adp;
        DataTable dtable = new DataTable();
        public DataTable HCM_LTA_Master_withTID(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@EMPID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@Type", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@TID", objprp.TransID));
                sqlCmd.CommandText = "HCM_LTA_Master";
                adp = new SqlDataAdapter(sqlCmd);
                adp.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                return dtable;

            }
            finally
            {
                adp.Dispose();
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public DataTable HCM_LTA_Master(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@EMPID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@Type", objprp.type));

                sqlCmd.CommandText = "HCM_LTA_Master";
                adp = new SqlDataAdapter(sqlCmd);
                adp.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                return dtable;

            }
            finally
            {
                adp.Dispose();
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public DataTable HCM_Rpt_PendingLoanDetails_Detail(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.EmpID));


                sqlCmd.CommandText = "HCM_Rpt_PendingLoanDetails_Detail";
                adp = new SqlDataAdapter(sqlCmd);
                adp.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                return dtable;

            }
            finally
            {
                adp.Dispose();
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public DataTable HCM_Rpt_PendingLoanDetails_id(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCode", objprp.EmpID));


                sqlCmd.CommandText = "HCM_Rpt_PendingLoanDetails_id";

                adp = new SqlDataAdapter(sqlCmd);
                adp.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                return dtable;

            }
            finally
            {
                adp.Dispose();
                sqlCmd.Dispose();
                sqlCnn.Close();

            }


        }

        public string HCM_Insert_LTA_MemberDetails(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                sqlCmd.Parameters.Add(new SqlParameter("@TID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@MemberName", objprp.MemberName));
                sqlCmd.Parameters.Add(new SqlParameter("@RelationShip", objprp.RelationShip));
                sqlCmd.Parameters.Add(new SqlParameter("@Age", objprp.Age));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));

                sqlCmd.CommandText = "HCM_Insert_LTA_MemberDetails";

                return sqlCmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_Insert_LTA_FareDetails(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                sqlCmd.Parameters.Add(new SqlParameter("@TID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@FromPlace", objprp.FromPlace));
                sqlCmd.Parameters.Add(new SqlParameter("@ToPlace", objprp.ToPlace));
                sqlCmd.Parameters.Add(new SqlParameter("@TravelClass", objprp.TravelClass));
                sqlCmd.Parameters.Add(new SqlParameter("@Tickets", objprp.Tickets));
                sqlCmd.Parameters.Add(new SqlParameter("@ActualFare", objprp.ActualFare));
                sqlCmd.Parameters.Add(new SqlParameter("@BillFile", objprp.BillFile));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));

                sqlCmd.CommandText = "HCM_Insert_LTA_FareDetails";

                return sqlCmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_Insert_LTA_Transactions(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartYear", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndYear", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@AdvanceAmt", objprp.AdvanceAmt));
                sqlCmd.Parameters.Add(new SqlParameter("@TotLTAAmount", objprp.TotLTAAmount));
                sqlCmd.Parameters.Add(new SqlParameter("@PlaceVisit", objprp.PlaceVisit));
                sqlCmd.Parameters.Add(new SqlParameter("@CrBy", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@Country", objprp.Address));
                sqlCmd.Parameters.Add(new SqlParameter("@Texableamount", objprp.UnitName));
                sqlCmd.CommandText = "HCM_Insert_LTA_Transactions";

                return sqlCmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_emp_admin(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));

                sqlCmd.CommandText = "HCM_emp_admin";

                return sqlCmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_emp_hod(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.EmpID));


                sqlCmd.CommandText = "HCM_emp_hod";

                return sqlCmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> gettime()
        {
            try
            {
                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];

                sqlCmd.CommandText = "select * from GET_TIME";

                //ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();


                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.EMP_CODE = sqlReader["timing"].ToString();
                        obj.Add(p);

                    }
                }
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
                // ADO.ReaderClose(ADOprpDL);
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }

        public List<PRPsetupWork> getunitbyemp(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.EmpID));
                sqlCmd.CommandText = "getunitbyemp";

                //ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();


                while (sqlReader.Read())
                {
                    PRPsetupWork p = new PRPsetupWork();
                    p.UnitCode = sqlReader["UnitCode"].ToString();
                    p.UnitName = sqlReader["UnitName"].ToString();
                    obj.Add(p);


                }
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> GetappAuth(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@ismobile", objprp.ID));
                sqlCmd.CommandText = "GetappAuth";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.Application_id = sqlReader["Application_id"].ToString();
                        p.Application_Name = sqlReader["Application_Name"].ToString();
                        p.Application_Path = sqlReader["Application_Path"].ToString();
                        p.Application_Detail = sqlReader["Application_Detail"].ToString();
                        p.Application_icon = sqlReader["Application_icon"].ToString();
                        p.color = sqlReader["color"].ToString();
                        p.Response = 1;
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);

                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new PRPsetupWork { Response = -1,ResponseMsg=ex.Message }) ;
            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
            return obj;
        }
        public List<PRPsetupWork> check_shortleave_max(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@LeaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@date", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@up", objprp.ID));
                sqlCmd.CommandText = "check_shortleave_max";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.TotalDays = sqlReader["total"].ToString();
                        p.Salary = sqlReader["same"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Get_HOD_StaffData(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[3];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@dt", objprp.CrDate));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                sqlCmd.CommandText = "HCM_Get_HOD_StaffData";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.EMP_CODE = sqlReader["EmpID"].ToString();
                        p.name = sqlReader["Name"].ToString();
                        p.TotalDays = sqlReader["TotalDay"].ToString();
                        p.Present = sqlReader["Present"].ToString();
                        p.rest = sqlReader["rest"].ToString();
                        p.ODHours = sqlReader["OD"].ToString();
                        p.ShortLeaveHours = sqlReader["ST"].ToString();
                        p.LeaveHours = sqlReader["leave"].ToString();
                        p.apptype = sqlReader["Absent"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> GetLeavesummary(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[3];
                sqlCmd.Parameters.Add(new SqlParameter("@code", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@year", objprp.year));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));

                sqlCmd.CommandText = "GetLeavesummary";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.Active = sqlReader["avail"].ToString();
                        p.LeaveDesc = sqlReader["LeaveDesc"].ToString();
                        p.TotalAllowance = sqlReader["total"].ToString();
                        p.ActualShift = sqlReader["LeaveYear"].ToString();
                        p.AllowName = sqlReader["bal"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);

                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> TEST_SP_LEAVE_balance(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@EMP_CODE", objprp.EmpID));

                sqlCmd.CommandText = "TEST_SP_LEAVE_balance";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.EMP_CODE = sqlReader["EMP_CODE"].ToString();
                        p.MONTH_NAME = sqlReader["MONTH_NAME"].ToString();
                        p.CASUAL_LEAVE = sqlReader["CASUAL_LEAVE"].ToString();
                        p.EARNED_LEAVE = sqlReader["EARNED_LEAVE"].ToString();
                        p.SICK_LEAVE = sqlReader["SICK_LEAVE"].ToString();
                        p.CL_AV = sqlReader["CL_AV"].ToString();
                        p.EL_AV = sqlReader["EL_AV"].ToString();
                        p.SL_AV = sqlReader["SL_AV"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Leave_Transaction_approve(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[5];



                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));

                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@role", objprp.role));
                sqlCmd.Parameters.Add(new SqlParameter("@flag", objprp.HodAppFlag1));
                sqlCmd.Parameters.Add(new SqlParameter("@Reason", objprp.Reason));


                sqlCmd.CommandText = "HCM_Leave_Transaction_approve";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Leave_Transaction_insert_OD_localOnly(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[13];



                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));

                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@LeaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@FromTime", objprp.FromTime));
                sqlCmd.Parameters.Add(new SqlParameter("@ToTime", objprp.ToTime));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@Reason", objprp.Reason));
                sqlCmd.Parameters.Add(new SqlParameter("@CrBy", objprp.Crby));

                sqlCmd.Parameters.Add(new SqlParameter("@CrIP ", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate ", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate ", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@TotalDays ", objprp.TotalDays));
                sqlCmd.Parameters.Add(new SqlParameter("@Place ", objprp.Place));

                sqlCmd.CommandText = "HCM_Leave_Transaction_insert_OD_localOnly";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Leave_Transaction_insert_OD_latest_for_local(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[13];



                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));

                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@LeaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@FromTime", objprp.FromTime));
                sqlCmd.Parameters.Add(new SqlParameter("@ToTime", objprp.ToTime));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@Reason", objprp.Reason));
                sqlCmd.Parameters.Add(new SqlParameter("@CrBy", objprp.Crby));

                sqlCmd.Parameters.Add(new SqlParameter("@CrIP ", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate ", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate ", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@TotalDays ", objprp.TotalDays));
                sqlCmd.Parameters.Add(new SqlParameter("@Place ", objprp.Place));

                sqlCmd.CommandText = "HCM_Leave_Transaction_insert_OD_latest_for_local";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Leave_Transaction_insert_OD(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[13];



                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));

                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@LeaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@FromTime", objprp.FromTime));
                sqlCmd.Parameters.Add(new SqlParameter("@ToTime", objprp.ToTime));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@Reason", objprp.Reason));
                sqlCmd.Parameters.Add(new SqlParameter("@CrBy", objprp.Crby));

                sqlCmd.Parameters.Add(new SqlParameter("@CrIP ", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate ", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate ", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@TotalDays ", objprp.TotalDays));
                sqlCmd.Parameters.Add(new SqlParameter("@Place ", objprp.Place));

                sqlCmd.CommandText = "HCM_Leave_Transaction_insert_OD";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Leave_Transaction_insert_stl(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[13];



                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));

                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@LeaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@FromTime", objprp.FromTime));
                sqlCmd.Parameters.Add(new SqlParameter("@ToTime", objprp.ToTime));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@Reason", objprp.Reason));
                sqlCmd.Parameters.Add(new SqlParameter("@CrBy", objprp.Crby));

                sqlCmd.Parameters.Add(new SqlParameter("@CrIP ", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate ", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate ", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@TotalDays ", objprp.TotalDays));
                sqlCmd.Parameters.Add(new SqlParameter("@Place ", objprp.Place));

                sqlCmd.CommandText = "HCM_Leave_Transaction_insert_stl";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Leave_Transaction_insert_ONLY_Leave(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[13];



                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));

                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@LeaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@FromTime", objprp.FromTime));
                sqlCmd.Parameters.Add(new SqlParameter("@ToTime", objprp.ToTime));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@Reason", objprp.Reason));
                sqlCmd.Parameters.Add(new SqlParameter("@CrBy", objprp.Crby));

                sqlCmd.Parameters.Add(new SqlParameter("@CrIP ", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate ", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate ", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@TotalDays ", objprp.TotalDays));
                sqlCmd.Parameters.Add(new SqlParameter("@Place ", objprp.Place));

                sqlCmd.CommandText = "HCM_Leave_Transaction_insert_ONLY_Leave_Tmp";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Leave_Transaction_insert(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[13];



                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));

                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@LeaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@FromTime", objprp.FromTime));
                sqlCmd.Parameters.Add(new SqlParameter("@ToTime", objprp.ToTime));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@Reason", objprp.Reason));
                sqlCmd.Parameters.Add(new SqlParameter("@CrBy", objprp.Crby));

                sqlCmd.Parameters.Add(new SqlParameter("@CrIP ", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate ", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate ", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@TotalDays ", objprp.TotalDays));
                sqlCmd.Parameters.Add(new SqlParameter("@Place ", objprp.Place));

                sqlCmd.CommandText = "HCM_Leave_Transaction_insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Leave_TransactionDisplay_shortleave_onluleave(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));

                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                sqlCmd.Parameters.Add(new SqlParameter("@leaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@lt", objprp.TimeType));
                sqlCmd.CommandText = "HCM_Leave_TransactionDisplay_shortleave_onluleave";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.TransID = sqlReader["TransID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.LeaveID = sqlReader["LeaveID"].ToString();
                        p.FromTime = sqlReader["FromTime"].ToString();
                        p.ToTime = sqlReader["ToTime"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();

                        p.Reason = sqlReader["Reason"].ToString();
                        p.Place = sqlReader["Place"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.HRAppFlag1 = sqlReader["HRAppFlag1"].ToString();
                        p.HodAppFlag1 = sqlReader["HodAppFlag1"].ToString();
                        p.TotalDays = sqlReader["TotalDays"].ToString();
                        p.TotalAllowance = sqlReader["EndDate1"].ToString();
                        p.name = sqlReader["EndDate2"].ToString();

                        p.year = sqlReader["lvt"].ToString();
                        p.CrDate = sqlReader["CrDate"].ToString();
                        p.DateOFBirth = sqlReader["reqdate"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_ODDisplay_Full(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));

                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                sqlCmd.Parameters.Add(new SqlParameter("@leaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@lt", objprp.TimeType));
                sqlCmd.CommandText = "HCM_ODDisplay_Full_Temp";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader(); obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.TransID = sqlReader["TransID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.LeaveID = sqlReader["LeaveID"].ToString();
                        p.FromTime = sqlReader["FromTime"].ToString();
                        p.ToTime = sqlReader["ToTime"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();

                        p.Reason = sqlReader["Reason"].ToString();
                        p.Place = sqlReader["Place"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.HRAppFlag1 = sqlReader["HRAppFlag1"].ToString();
                        p.HodAppFlag1 = sqlReader["HodAppFlag1"].ToString();
                        p.name = sqlReader["EndDate2"].ToString();
                        if (p.name == "Local OD")
                        {
                            //if (sqlReader["reading1"].ToString() == "")
                            //{
                            //    p.Place = sqlReader["Place"].ToString();
                            //}
                            //else
                            //{
                            //    p.Place = sqlReader["tos"].ToString() + " to " + sqlReader["reading1"].ToString();
                            //}
                            p.TotalDays = sqlReader["reading"].ToString() + "KM";// + "/" + sqlReader["Amount"].ToString();
                        }
                        else
                        {
                            if(sqlReader["TotalDays"].ToString()=="1")
                            p.TotalDays= sqlReader["TotalDays"].ToString()+"Day";
                            else
                                p.TotalDays = sqlReader["TotalDays"].ToString() + "Days";
                        }
                        p.TotalAllowance = sqlReader["EndDate1"].ToString();
                        p.name = sqlReader["EndDate2"].ToString();

                        p.year = sqlReader["lvt"].ToString();
                       
                        p.CrDate = sqlReader["CrDate"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Leave_TransactionDisplay_shortleave_OD(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));

                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                sqlCmd.Parameters.Add(new SqlParameter("@leaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@lt", objprp.TimeType));
                sqlCmd.CommandText = "HCM_Leave_TransactionDisplay_shortleave_OD";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.TransID = sqlReader["TransID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.LeaveID = sqlReader["LeaveID"].ToString();
                        p.FromTime = sqlReader["FromTime"].ToString();
                        p.ToTime = sqlReader["ToTime"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();

                        p.Reason = sqlReader["Reason"].ToString();
                        p.Place = sqlReader["Place"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.HRAppFlag1 = sqlReader["HRAppFlag1"].ToString();
                        p.HodAppFlag1 = sqlReader["HodAppFlag1"].ToString();
                        p.TotalDays = sqlReader["TotalDays"].ToString();
                        p.TotalAllowance = sqlReader["EndDate1"].ToString();
                        p.name = sqlReader["EndDate2"].ToString();

                        p.year = sqlReader["lvt"].ToString();
                        if (p.name == "Local OD")
                        {
                            if (sqlReader["reading1"].ToString() == "")
                            {
                                p.Place = sqlReader["Place"].ToString();
                            }
                            else
                            {
                                p.Place = sqlReader["tos"].ToString() + " to " + sqlReader["reading1"].ToString();
                            }
                            p.TotalDays = sqlReader["reading"].ToString() + "KM"+"/"+ sqlReader["Amount"].ToString();
                        }
                        p.CrDate = sqlReader["CrDate"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Leave_TransactionDisplay_shortleave(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));

                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                sqlCmd.Parameters.Add(new SqlParameter("@leaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@lt", objprp.TimeType));
                sqlCmd.CommandText = "HCM_Leave_TransactionDisplay_shortleave";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.TransID = sqlReader["TransID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.LeaveID = sqlReader["LeaveID"].ToString();
                        p.FromTime = sqlReader["FromTime"].ToString();
                        p.ToTime = sqlReader["ToTime"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();

                        p.Reason = sqlReader["Reason"].ToString();
                        p.Place = sqlReader["Place"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.HRAppFlag1 = sqlReader["HRAppFlag1"].ToString();
                        p.HodAppFlag1 = sqlReader["HodAppFlag1"].ToString();
                        p.TotalDays = sqlReader["TotalDays"].ToString();
                        p.TotalAllowance = sqlReader["EndDate1"].ToString();
                        p.name = sqlReader["EndDate2"].ToString();

                        p.year = sqlReader["lvt"].ToString();
                        p.CrDate = sqlReader["CrDate"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Rpt_SalarySlip_type(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[7];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCode", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@cMonth", objprp.month));
                sqlCmd.Parameters.Add(new SqlParameter("@cYear", objprp.year));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpStatus", objprp.EmpStatus));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCatg", objprp.EmpCadre));


                sqlCmd.CommandText = "HCM_Rpt_SalarySlip_type";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        //p.ID = sqlReader["ID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();

                        p.WorkingDays = sqlReader["WorkingDays"].ToString();
                        p.TotalExp = sqlReader["TotNetPay"].ToString();
                        p.ArrearDays = sqlReader["ArrearDays"].ToString();
                        p.TotalDeductions = sqlReader["TotalDeductions"].ToString();
                        p.TotalAllowance = sqlReader["TotalAllowance"].ToString();
                        p.NetPay = sqlReader["NetPay"].ToString();
                        p.ArrTotAllowance = sqlReader["ArrTotAllowance"].ToString();
                        p.ArrTotDeductions = sqlReader["ArrTotDeductions"].ToString();
                        p.ArrNetPay = sqlReader["ArrNetPay"].ToString();
                        p.CTC = sqlReader["CTC"].ToString();
                        p.Gross = sqlReader["Gross"].ToString();
                        p.BFAmount = sqlReader["BFAmount"].ToString();
                        p.CFAmount = sqlReader["CFAmount"].ToString();

                        p.month = sqlReader["Mth"].ToString();
                        p.year = sqlReader["yr"].ToString();


                        p.AllowName = sqlReader["AllowName"].ToString();
                        p.AllowValue = sqlReader["AllowValue"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Rpt_SalarySlip(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[7];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCode", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@cMonth", objprp.month));
                sqlCmd.Parameters.Add(new SqlParameter("@cYear", objprp.year));
                sqlCmd.Parameters.Add(new SqlParameter("@UserID", objprp.userid));
                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpStatus", objprp.EmpStatus));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCatg", objprp.EmpCadre));

                sqlCmd.CommandText = "HCM_Rpt_SalarySlip";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.EmpStatus = sqlReader["EmpStatusDesc"].ToString();
                        p.FullName = sqlReader["FullName"].ToString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.SubDeptName = sqlReader["SubDeptName"].ToString();

                        p.LocationName = sqlReader["LocationName"].ToString();
                        p.MainCadre = sqlReader["MainCadre"].ToString();
                        p.EMPDOJ = sqlReader["EMPDOJ"].ToString();
                        p.ActualShift = sqlReader["EmpCadreDesc"].ToString();
                        p.DesignName = sqlReader["DesignName"].ToString();
                        p.WorkingDays = sqlReader["WorkingDays"].ToString();
                        p.TotalExp = sqlReader["TotNetPay"].ToString();
                        p.ArrearDays = sqlReader["ArrearDays"].ToString();
                        p.TotalDeductions = sqlReader["TotalDeductions"].ToString();
                        p.TotalAllowance = sqlReader["TotalAllowance"].ToString();
                        p.NetPay = sqlReader["NetPay"].ToString();
                        p.ArrTotAllowance = sqlReader["ArrTotAllowance"].ToString();
                        p.ArrTotDeductions = sqlReader["ArrTotDeductions"].ToString();
                        p.ArrNetPay = sqlReader["ArrNetPay"].ToString();
                        p.CTC = sqlReader["CTC"].ToString();
                        p.Gross = sqlReader["Gross"].ToString();
                        p.BFAmount = sqlReader["BFAmount"].ToString();
                        p.CFAmount = sqlReader["CFAmount"].ToString();

                        p.month = sqlReader["Mth"].ToString();
                        p.year = sqlReader["yr"].ToString();
                        p.BankAccountNo = sqlReader["BankAccountNo"].ToString();
                        p.BankName = sqlReader["BankName"].ToString();


                        p.AllowName = sqlReader["AllowName"].ToString();
                        p.AllowValue = sqlReader["AllowValue"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_Info_UserAuthorization(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[3];
                sqlCmd.Parameters.Add(new SqlParameter("@UserID", objprp.EmpID));

                sqlCmd.Parameters.Add(new SqlParameter("@AuthType", objprp.authtype));
                sqlCmd.Parameters.Add(new SqlParameter("@CrDate", objprp.CrDate));
                sqlCmd.CommandText = "HCM_Info_UserAuthorization";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader(); obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.UnitCode = sqlReader["UnitCode"].ToString();                        
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Rpt_SalarySlip_Web_Header(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[3];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCode", objprp.EmpID));

                sqlCmd.Parameters.Add(new SqlParameter("@cMonth", objprp.month));
                sqlCmd.Parameters.Add(new SqlParameter("@cYear", objprp.year));
                sqlCmd.CommandText = "HCM_Rpt_SalarySlip_Web_Header";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.EmpStatus = sqlReader["EmpStatusDesc"].ToString();
                        p.FullName = sqlReader["FullName"].ToString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.SubDeptName = sqlReader["SubDeptName"].ToString();

                        p.LocationName = sqlReader["LocationName"].ToString();
                        p.MainCadre = sqlReader["MainCadre"].ToString();
                        p.EMPDOJ = sqlReader["EMPDOJ"].ToString();
                        p.ActualShift = sqlReader["EmpCadreDesc"].ToString();
                        p.DesignName = sqlReader["DesignName"].ToString();
                        p.WorkingDays = sqlReader["WorkingDays"].ToString();
                        p.TotalExp = sqlReader["TotNetPay"].ToString();
                        p.ArrearDays = sqlReader["ArrearDays"].ToString();
                        p.TotalDeductions = sqlReader["TotalDeductions"].ToString();
                        p.TotalAllowance = sqlReader["TotalAllowance"].ToString();
                        p.NetPay = sqlReader["NetPay"].ToString();
                        p.ArrTotAllowance = sqlReader["ArrTotAllowance"].ToString();
                        p.ArrTotDeductions = sqlReader["ArrTotDeductions"].ToString();
                        p.ArrNetPay = sqlReader["ArrNetPay"].ToString();
                        p.CTC = sqlReader["CTC"].ToString();
                        p.Gross = sqlReader["Gross"].ToString();
                        p.BFAmount = sqlReader["BFAmount"].ToString();
                        p.CFAmount = sqlReader["CFAmount"].ToString();

                        p.month = sqlReader["Mth"].ToString();
                        p.year = sqlReader["yr"].ToString();
                        p.BankAccountNo = sqlReader["BankAccountNo"].ToString();
                        p.BankName = sqlReader["BankName"].ToString();
                        p.CompanyName = sqlReader["CompanyName"].ToString();
                        p.Outtime = sqlReader["mh2"].ToString();
                        p.TotalHours = sqlReader["TotNetPay"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Attendance_Display_basicHR_New(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@userid", objprp.userid));
                sqlCmd.CommandText = "HCM_Attendance_Display_basicHR_New";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader(); obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.EmpStatus = sqlReader["EmpStatus"].ToString();
                        p.FullName = sqlReader["FullName"].ToString();

                        p.DateOFBirth = Convert.ToDateTime(sqlReader["DateOFBirth"]).ToShortDateString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.SubDeptName = sqlReader["SubDeptName"].ToString();

                        p.LocationName = sqlReader["LocationName"].ToString();
                        p.MainCadre = sqlReader["MainCadre"].ToString();
                        p.EMPDOJ = sqlReader["EMPDOJ"].ToString();
                        p.ActualShift = sqlReader["EmpCadreDesc"].ToString();
                        p.DesignName = sqlReader["DesignName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_Attendance_Display_basicHR(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@userid", objprp.userid));
                sqlCmd.CommandText = "HCM_Attendance_Display_basicHR";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.EmpStatus = sqlReader["EmpStatus"].ToString();
                        p.FullName = sqlReader["FullName"].ToString();

                        p.DateOFBirth = Convert.ToDateTime(sqlReader["DateOFBirth"]).ToShortDateString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.SubDeptName = sqlReader["SubDeptName"].ToString();

                        p.LocationName = sqlReader["LocationName"].ToString();
                        p.MainCadre = sqlReader["MainCadre"].ToString();
                        p.EMPDOJ = sqlReader["EMPDOJ"].ToString();
                        p.ActualShift = sqlReader["EmpCadreDesc"].ToString();
                        p.DesignName = sqlReader["DesignName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_Attendance_Display_basic(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.CommandText = "HCM_Attendance_Display_basic";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.EmpStatus = sqlReader["EmpStatus"].ToString();
                        p.FullName = sqlReader["FullName"].ToString();

                        p.DateOFBirth = Convert.ToDateTime(sqlReader["DateOFBirth"]).ToShortDateString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.SubDeptName = sqlReader["SubDeptName"].ToString();

                        p.LocationName = sqlReader["LocationName"].ToString();
                        p.MainCadre = sqlReader["MainCadre"].ToString();
                        p.EMPDOJ = sqlReader["EMPDOJ"].ToString();
                        p.ActualShift = sqlReader["EmpCadreDesc"].ToString();
                        p.DesignName = sqlReader["DesignName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_Rpt_Daily_Attendance_today(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCode", objprp.EmpID));

                sqlCmd.Parameters.Add(new SqlParameter("@dt", objprp.CrDate));
                sqlCmd.CommandText = "HCM_Rpt_Daily_Attendance_today";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.AttdDate = sqlReader["AttdDate"].ToString();
                        p.AttdType = sqlReader["AttdTypeDesc"].ToString();
                        p.PlanShift = sqlReader["PlanShift"].ToString();
                        p.ActualShift = sqlReader["ActualShift"].ToString();
                        if (sqlReader["inTime"].ToString() != null && sqlReader["inTime"].ToString() != "")
                        {
                            p.inTime = Convert.ToDateTime(sqlReader["inTime"]).ToString("HH:mm:ss");
                        }
                        else
                        {
                            p.inTime = sqlReader["inTime"].ToString();
                        }
                        if (sqlReader["Outtime"].ToString() != null && sqlReader["Outtime"].ToString() != "")
                        {
                            p.Outtime = Convert.ToDateTime(sqlReader["Outtime"]).ToString("HH:mm:ss");
                        }
                        else
                        {
                            p.Outtime = sqlReader["Outtime"].ToString();
                        }
                        p.WorkHours = sqlReader["WorkHours"].ToString();
                        p.TotalHours = sqlReader["TotalHours"].ToString();
                        p.FullName = sqlReader["FullName"].ToString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.LeaveHours = sqlReader["LeaveHours"].ToString();
                        p.ODHours = sqlReader["ODHours"].ToString();
                        p.ShortLeaveHours = sqlReader["ShortLeaveHours"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Rpt_Daily_Attendance_last_five(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCode", objprp.EmpID));
                sqlCmd.CommandText = "HCM_Rpt_Daily_Attendance_last_five";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.AttdDate = sqlReader["Punchdatetime"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_Rpt_Daily_AttendanceBydate(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[8];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCode", objprp.EmpID));

                sqlCmd.Parameters.Add(new SqlParameter("@date", objprp.AttdDate));
                sqlCmd.Parameters.Add(new SqlParameter("@UserID", objprp.userid));
                sqlCmd.Parameters.Add(new SqlParameter("@nanme ", objprp.name));

                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@shift", objprp.ShiftCode));
                sqlCmd.Parameters.Add(new SqlParameter("@unit", objprp.UnitCode));
                sqlCmd.Parameters.Add(new SqlParameter("@desig", objprp.DesignID));
                sqlCmd.CommandText = "HCM_Rpt_Daily_AttendanceBydate";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.TransID = sqlReader["TransID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.AttdDate = sqlReader["AttdDate"].ToString();
                        p.AttdType = sqlReader["AttdTypeDesc"].ToString();
                        p.PlanShift = sqlReader["PlanShift"].ToString();
                        p.ActualShift = sqlReader["ActualShift"].ToString();
                        p.DesignName = sqlReader["DesignName"].ToString();
                        if (sqlReader["inTime"].ToString() != null && sqlReader["inTime"].ToString() != "")
                        {
                            p.inTime = Convert.ToDateTime(sqlReader["inTime"]).ToString("HH:mm:ss");
                        }
                        else
                        {
                            p.inTime = sqlReader["inTime"].ToString();
                        }
                        if (sqlReader["Outtime"].ToString() != null && sqlReader["Outtime"].ToString() != "")
                        {
                            p.Outtime = Convert.ToDateTime(sqlReader["Outtime"]).ToString("HH:mm:ss");
                        }
                        else
                        {
                            p.Outtime = sqlReader["Outtime"].ToString();
                        }
                        //  p.Outtime= sqlReader["Outtime"].ToString();

                        p.WorkHours = sqlReader["WorkHours"].ToString();
                        p.TotalHours = sqlReader["TotalHours"].ToString();
                        //   p.EmpStatus = sqlReader["EmpStatus"].ToString();
                        p.FullName = sqlReader["FullName"].ToString();

                        // p.DateOFBirth = Convert.ToDateTime(sqlReader["DateOFBirth"]).ToShortDateString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        //   p.SubDeptName = sqlReader["SubDeptName"].ToString();

                        // p.LocationName = sqlReader["LocationName"].ToString();
                        // // p.MainCadre = sqlReader["MainCadre"].ToString();
                        //p.EMPDOJ = sqlReader["EMPDOJ"].ToString();


                        p.LeaveHours = sqlReader["LeaveHours"].ToString();
                        p.ODHours = sqlReader["ODHours"].ToString();
                        p.ShortLeaveHours = sqlReader["ShortLeaveHours"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_Rpt_Daily_Attendance(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[3];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCode", objprp.EmpID));

                sqlCmd.Parameters.Add(new SqlParameter("@cMonth", objprp.month));
                sqlCmd.Parameters.Add(new SqlParameter("@cYear", objprp.year));
                sqlCmd.CommandText = "HCM_Rpt_Daily_Attendance";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        //  p.TransID = sqlReader["TransID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.AttdDate = sqlReader["AttdDate"].ToString();
                        p.AttdType = sqlReader["AttdTypeDesc"].ToString();
                        p.PlanShift = sqlReader["PlanShift"].ToString();
                        p.ActualShift = sqlReader["ActualShift"].ToString();
                        if (sqlReader["inTime"].ToString() != null && sqlReader["inTime"].ToString() != "")
                        {
                            p.inTime = Convert.ToDateTime(sqlReader["inTime"]).ToString("HH:mm:ss");
                        }
                        else
                        {
                            p.inTime = sqlReader["inTime"].ToString();
                        }
                        if (sqlReader["Outtime"].ToString() != null && sqlReader["Outtime"].ToString() != "")
                        {
                            p.Outtime = Convert.ToDateTime(sqlReader["Outtime"]).ToString("HH:mm:ss");
                        }
                        else
                        {
                            p.Outtime = sqlReader["Outtime"].ToString();
                        }
                        //  p.Outtime= sqlReader["Outtime"].ToString();

                        p.WorkHours = sqlReader["WorkHours"].ToString();
                        p.TotalHours = sqlReader["TotalHours"].ToString();
                        //   p.EmpStatus = sqlReader["EmpStatus"].ToString();
                        p.FullName = sqlReader["FullName"].ToString();

                        // p.DateOFBirth = Convert.ToDateTime(sqlReader["DateOFBirth"]).ToShortDateString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        //   p.SubDeptName = sqlReader["SubDeptName"].ToString();

                        // p.LocationName = sqlReader["LocationName"].ToString();
                        // // p.MainCadre = sqlReader["MainCadre"].ToString();
                        //p.EMPDOJ = sqlReader["EMPDOJ"].ToString();


                        p.LeaveHours = sqlReader["LeaveHours"].ToString();
                        p.ODHours = sqlReader["ODHours"].ToString();
                        p.ShortLeaveHours = sqlReader["ShortLeaveHours"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Attendance_Display(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[3];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));

                sqlCmd.Parameters.Add(new SqlParameter("@cMonth", objprp.month));
                sqlCmd.Parameters.Add(new SqlParameter("@cYear", objprp.year));
                sqlCmd.CommandText = "HCM_Attendance_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.TransID = sqlReader["TransID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.AttdDate = sqlReader["AttdDate"].ToString();
                        p.AttdType = sqlReader["AttdType"].ToString();
                        p.PlanShift = sqlReader["PlanShift"].ToString();
                        p.ActualShift = sqlReader["ActualShift"].ToString();
                        if (sqlReader["inTime"].ToString() != null && sqlReader["inTime"].ToString() != "")
                        {
                            p.inTime = Convert.ToDateTime(sqlReader["inTime"]).ToShortTimeString();
                        }
                        else
                        {
                            p.inTime = sqlReader["inTime"].ToString();
                        }
                        if (sqlReader["Outtime"].ToString() != null && sqlReader["Outtime"].ToString() != "")
                        {
                            p.Outtime = Convert.ToDateTime(sqlReader["Outtime"]).ToShortTimeString();
                        }
                        else
                        {
                            p.Outtime = sqlReader["Outtime"].ToString();
                        }
                        //  p.Outtime= sqlReader["Outtime"].ToString();

                        p.WorkHours = sqlReader["WorkHours"].ToString();
                        p.TotalHours = sqlReader["TotalHours"].ToString();
                        p.EmpStatus = sqlReader["EmpStatus"].ToString();
                        p.FullName = sqlReader["FullName"].ToString();

                        p.DateOFBirth = Convert.ToDateTime(sqlReader["DateOFBirth"]).ToShortDateString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.SubDeptName = sqlReader["SubDeptName"].ToString();

                        p.LocationName = sqlReader["LocationName"].ToString();
                        p.MainCadre = sqlReader["MainCadre"].ToString();
                        p.EMPDOJ = sqlReader["EMPDOJ"].ToString();


                        p.LeaveHours = sqlReader["LeaveHours"].ToString();
                        p.ODHours = sqlReader["ODHours"].ToString();
                        p.ShortLeaveHours = sqlReader["ShortLeaveHours"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Leave_TransactionDisplay_filter_OD(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[9];
                sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@authtype", objprp.authtype));
                sqlCmd.Parameters.Add(new SqlParameter("@apptype", objprp.apptype));
                sqlCmd.Parameters.Add(new SqlParameter("@hraptype", objprp.hraptype));
                sqlCmd.Parameters.Add(new SqlParameter("@hodapptype", objprp.hodapptype));

                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                sqlCmd.Parameters.Add(new SqlParameter("@from", objprp.FromTime));
                sqlCmd.Parameters.Add(new SqlParameter("@to", objprp.ToTime));
                sqlCmd.Parameters.Add(new SqlParameter("@leaveID", objprp.LeaveID));
                sqlCmd.CommandText = "HCM_Leave_TransactionDisplay_filter_OD";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.TransID = sqlReader["TransID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.LeaveID = sqlReader["LeaveID"].ToString();
                        p.FromTime = sqlReader["FromTime"].ToString();
                        p.ToTime = sqlReader["ToTime"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();

                        p.Reason = sqlReader["Reason"].ToString();
                        p.Place = sqlReader["Place"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.HRAppFlag1 = sqlReader["HRAppFlag1"].ToString();
                        p.HodAppFlag1 = sqlReader["HodAppFlag1"].ToString();
                        p.TotalDays = sqlReader["TotalDays"].ToString();
                        p.FullName = sqlReader["FullName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Leave_TransactionDisplay_filter(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[10];
                sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@authtype", objprp.authtype));
                sqlCmd.Parameters.Add(new SqlParameter("@apptype", objprp.apptype));
                sqlCmd.Parameters.Add(new SqlParameter("@hraptype", objprp.hraptype));
                sqlCmd.Parameters.Add(new SqlParameter("@hodapptype", objprp.hodapptype));

                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                sqlCmd.Parameters.Add(new SqlParameter("@from", objprp.FromTime));
                sqlCmd.Parameters.Add(new SqlParameter("@to", objprp.ToTime));
                sqlCmd.Parameters.Add(new SqlParameter("@leaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@lt", objprp.TimeType));
                sqlCmd.CommandText = "HCM_Leave_TransactionDisplay_filter";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.TransID = sqlReader["TransID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.LeaveID = sqlReader["LeaveID"].ToString();
                        p.FromTime = sqlReader["daydetail"].ToString();
                        p.ToTime = sqlReader["ToTime"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["ToTimea"].ToString();
                        p.Reason = sqlReader["Reason"].ToString();
                        p.HRAppFlag1 = sqlReader["HRAppFlag1"].ToString();
                        p.HodAppFlag1 = sqlReader["HodAppFlag1"].ToString();
                        p.TotalDays = sqlReader["TotalDays"].ToString();
                        p.FullName = sqlReader["FullName"].ToString();
                        p.Place = sqlReader["Place"].ToString();
                        p.CrDate = sqlReader["CrDate"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Leave_TransactionDisplay(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[6];
                sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@authtype", objprp.authtype));
                sqlCmd.Parameters.Add(new SqlParameter("@apptype", objprp.apptype));
                sqlCmd.Parameters.Add(new SqlParameter("@hraptype", objprp.hraptype));
                sqlCmd.Parameters.Add(new SqlParameter("@hodapptype", objprp.hodapptype));

                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                sqlCmd.CommandText = "HCM_Leave_TransactionDisplay";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.TransID = sqlReader["TransID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.LeaveID = sqlReader["LeaveID"].ToString();
                        p.FromTime = sqlReader["daydetail"].ToString();
                        p.ToTime = sqlReader["ToTime"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["ToTimea"].ToString();
                        p.Reason = sqlReader["Reason"].ToString();
                        p.HRAppFlag1 = sqlReader["HRAppFlag1"].ToString();
                        p.HodAppFlag1 = sqlReader["HodAppFlag1"].ToString();
                        p.TotalDays = sqlReader["TotalDays"].ToString();
                        p.Place = sqlReader["Place"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        //[HCM_LeaveMaster_Display_onlyleave_Only_User]

        public List<PRPsetupWork> HCM_LeaveMaster_Display_onlyleave_Only_User(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@LeaveID", objprp.LeaveID));
                sqlCmd.Parameters.Add(new SqlParameter("@Empid", objprp.EmpID));
                sqlCmd.CommandText = "HCM_LeaveMaster_Display_onlyleave_Only_User";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader(); obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.TransID = sqlReader["TransID"].ToString();
                        p.LeaveID = sqlReader["LeaveID"].ToString();
                        p.LeaveDesc = sqlReader["LeaveDesc"].ToString();
                        p.Opening = sqlReader["Opening"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_LeaveMaster_Display_onlyleave(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@LeaveID", objprp.LeaveID));

                sqlCmd.CommandText = "HCM_LeaveMaster_Display_onlyleave";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.TransID = sqlReader["TransID"].ToString();
                        p.LeaveID = sqlReader["LeaveID"].ToString();
                        p.LeaveDesc = sqlReader["LeaveDesc"].ToString();
                        p.Opening = sqlReader["Opening"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_LeaveMaster_Display(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@LeaveID", objprp.LeaveID));

                sqlCmd.CommandText = "HCM_LeaveMaster_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.TransID = sqlReader["TransID"].ToString();
                        p.LeaveID = sqlReader["LeaveID"].ToString();
                        p.LeaveDesc = sqlReader["LeaveDesc"].ToString();
                        p.Opening = sqlReader["Opening"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string SHiftchangeMultiple(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@from", objprp.FromTime));
                sqlCmd.Parameters.Add(new SqlParameter("@to", objprp.ToTime));
                sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@ShiftCode", objprp.ShiftCode));
                sqlCmd.Parameters.Add(new SqlParameter("@CrBy", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "SHiftchangeMultiple";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }


        }
        public string HCM_HOD_ShiftChangeUpdate(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                sqlCmd.Parameters.Add(new SqlParameter("@NewShiftCode", objprp.ShiftCode));
                sqlCmd.Parameters.Add(new SqlParameter("@HODID", objprp.Hod));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));

                sqlCmd.CommandText = "HCM_HOD_ShiftChangeUpdate";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }


        }
        public string HCM_CompanyMaster_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[9];
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyName", objprp.CompanyName));
                sqlCmd.Parameters.Add(new SqlParameter("@Address", objprp.Address));
                sqlCmd.Parameters.Add(new SqlParameter("@City", objprp.City));
                sqlCmd.Parameters.Add(new SqlParameter("@StateCode", objprp.StateCode));
                sqlCmd.Parameters.Add(new SqlParameter("@CountryCode", objprp.CountryCode));
                sqlCmd.Parameters.Add(new SqlParameter("@GSTNo", objprp.GSTNo));
                sqlCmd.Parameters.Add(new SqlParameter("@ContactNo", objprp.ContactNo));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));

                sqlCmd.CommandText = "HCM_CompanyMaster_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }

        public string HCM_CompanyMaster_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[10];
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyCode", objprp.CompanyCode));
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyName", objprp.CompanyName));
                sqlCmd.Parameters.Add(new SqlParameter("@Address", objprp.Address));
                sqlCmd.Parameters.Add(new SqlParameter("@City", objprp.City));
                sqlCmd.Parameters.Add(new SqlParameter("@StateCode", objprp.StateCode));
                sqlCmd.Parameters.Add(new SqlParameter("@CountryCode", objprp.CountryCode));
                sqlCmd.Parameters.Add(new SqlParameter("@GSTNo", objprp.GSTNo));
                sqlCmd.Parameters.Add(new SqlParameter("@ContactNo", objprp.ContactNo));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));

                sqlCmd.CommandText = "HCM_CompanyMaster_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_fetchcountry()
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                
                
                sqlCmd.CommandText = "HCM_fetchcountry";

          
            //    List<PRPsetupWork> obj = new List<PRPsetupWork>();


            SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
            {

                while (sqlReader.Read())
                {
                    PRPsetupWork p = new PRPsetupWork();
                    p.CountryCode = sqlReader["CountryID"].ToString();
                    p.CountryName = sqlReader["CountryName"].ToString();
                    obj.Add(p);
                }
            }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_fetchstate()
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
               
                sqlCmd.CommandText = "HCM_fetchstate";
                
            //    List<PRPsetupWork> obj = new List<PRPsetupWork>();


            SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
            {

                while (sqlReader.Read())
                {
                    PRPsetupWork p = new PRPsetupWork();
                    p.StateName = sqlReader["StateName"].ToString();
                    p.StateID = sqlReader["StateID"].ToString();
                    obj.Add(p);
                }
            }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_fetchcity()
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];

                sqlCmd.CommandText = "HCM_fetchcity";
                
            //    List<PRPsetupWork> obj = new List<PRPsetupWork>();


            SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
            {

                while (sqlReader.Read())
                {
                    PRPsetupWork p = new PRPsetupWork();
                    p.CityID = sqlReader["CityID"].ToString();
                    p.CityName = sqlReader["CityName"].ToString();
                    obj.Add(p);
                }
            }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> sp_searchcompany(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@active", objprp.Active));
                sqlCmd.Parameters.Add(new SqlParameter("@name", objprp.name));

                sqlCmd.CommandText = "sp_searchcompany";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {

                        PRPsetupWork p = new PRPsetupWork();
                        p.CompanyCode = sqlReader["CompanyCode"].ToString();
                        p.CompanyName = sqlReader["CompanyName"].ToString();
                        p.Address = sqlReader["Address"].ToString();
                        p.City = sqlReader["cityName"].ToString();
                        p.StateCode = sqlReader["StateName"].ToString();
                        p.CountryCode = sqlReader["CountryName"].ToString();
                        p.GSTNo = sqlReader["GSTNo"].ToString();
                        p.ContactNo = sqlReader["ContactNo"].ToString();
                        p.ID = sqlReader["id"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> sp_select_companymaster(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.CompanyCode));

                sqlCmd.CommandText = "sp_select_companymaster";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.CompanyCode = sqlReader["CompanyCode"].ToString();
                        p.CompanyName = sqlReader["CompanyName"].ToString();
                        p.Address = sqlReader["Address"].ToString();
                        p.City = sqlReader["City"].ToString();
                        p.StateCode = sqlReader["StateCode"].ToString();
                        p.CountryCode = sqlReader["CountryCode"].ToString();
                        p.GSTNo = sqlReader["GSTNo"].ToString();
                        p.ContactNo = sqlReader["ContactNo"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_CompanyMaster_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyCode", objprp.CompanyCode));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));


                sqlCmd.CommandText = "HCM_CompanyMaster_Delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }


        public string HCM_UnitMaster_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[10];

                sqlCmd.Parameters.Add(new SqlParameter("@CompanyCode", objprp.CompanyCode));
                sqlCmd.Parameters.Add(new SqlParameter("@UnitName", objprp.UnitName));
                sqlCmd.Parameters.Add(new SqlParameter("@Address", objprp.Address));
                sqlCmd.Parameters.Add(new SqlParameter("@City", objprp.City));
                sqlCmd.Parameters.Add(new SqlParameter("@StateCode", objprp.StateCode));
                sqlCmd.Parameters.Add(new SqlParameter("@CountryCode", objprp.CountryCode));
                sqlCmd.Parameters.Add(new SqlParameter("@GSTNo", objprp.GSTNo));
                sqlCmd.Parameters.Add(new SqlParameter("@ContactNo", objprp.ContactNo));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_UnitMaster_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_select_Unitmaster(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.UnitCode));
                sqlCmd.CommandText = "HCM_select_Unitmaster";
                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.CompanyCode = sqlReader["CompanyCode"].ToString();
                        p.UnitCode = sqlReader["UnitCode"].ToString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.CompanyName = sqlReader["CompanyName"].ToString();
                        p.Address = sqlReader["Address"].ToString();
                        p.City = sqlReader["City"].ToString();
                        p.StateCode = sqlReader["StateCode"].ToString();
                        p.CountryCode = sqlReader["CountryCode"].ToString();
                        p.GSTNo = sqlReader["GSTNo"].ToString();
                        p.ContactNo = sqlReader["ContactNo"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }


        }


        public List<PRPsetupWork> sp_searchUnit(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@active", objprp.Active));
                sqlCmd.Parameters.Add(new SqlParameter("@name", objprp.name));

                sqlCmd.CommandText = "sp_searchUnit";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.CompanyCode = sqlReader["CompanyCode"].ToString();
                        p.UnitCode = sqlReader["UnitCode"].ToString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.Address = sqlReader["Address"].ToString();
                        p.City = sqlReader["cityName"].ToString();
                        p.StateCode = sqlReader["StateName"].ToString();
                        p.CountryCode = sqlReader["CountryName"].ToString();
                        p.GSTNo = sqlReader["GSTNo"].ToString();
                        p.ContactNo = sqlReader["ContactNo"].ToString();
                        p.ID = sqlReader["id"].ToString();
                        p.CompanyName = sqlReader["CompanyName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_UnitMaster_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[11];
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyCode", objprp.CompanyCode));
                sqlCmd.Parameters.Add(new SqlParameter("@UnitCode", objprp.UnitCode));
                sqlCmd.Parameters.Add(new SqlParameter("@UnitName", objprp.UnitName));
                sqlCmd.Parameters.Add(new SqlParameter("@Address", objprp.Address));
                sqlCmd.Parameters.Add(new SqlParameter("@City", objprp.City));
                sqlCmd.Parameters.Add(new SqlParameter("@StateCode", objprp.StateCode));
                sqlCmd.Parameters.Add(new SqlParameter("@CountryCode", objprp.CountryCode));
                sqlCmd.Parameters.Add(new SqlParameter("@GSTNo", objprp.GSTNo));
                sqlCmd.Parameters.Add(new SqlParameter("@ContactNo", objprp.ContactNo));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));

                sqlCmd.CommandText = "HCM_UnitMaster_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_UnitMaster_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];
                sqlCmd.Parameters.Add(new SqlParameter("@UnitCode", objprp.UnitCode));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_UnitMaster_Delete";
                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_DepartmentMaster_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[4];

                sqlCmd.Parameters.Add(new SqlParameter("@DeptName", objprp.DeptName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@DeptDesc", objprp.deptdesc));
                sqlCmd.CommandText = "HCM_DepartmentMaster_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_DepartmentMaster_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[5];
                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@DeptName", objprp.DeptName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@DeptDesc", objprp.deptdesc));
                sqlCmd.CommandText = "HCM_DepartmentMaster_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_DepartmentMaster_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_DepartmentMaster_Delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_DepartmentMaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.DeptID));


                sqlCmd.CommandText = "HCM_DepartmentMaster_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.DeptID = sqlReader["deptid"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.deptdesc = sqlReader["Dept_Desc"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_SubDepartment_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[4];

                sqlCmd.Parameters.Add(new SqlParameter("@SubDeptName", objprp.DeptName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.type));
                sqlCmd.CommandText = "HCM_SubDepartment_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_SubDepartment_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[5];
                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@SubDeptID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@SubDeptName", objprp.DeptName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_SubDepartment_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_SubDepartment_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@SubDeptID", objprp.DeptID));


                sqlCmd.CommandText = "HCM_SubDepartment_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.type = sqlReader["DeptID"].ToString();
                        p.PositionName = sqlReader["DeptName"].ToString();
                        p.DeptID = sqlReader["SubDeptID"].ToString();
                        p.DeptName = sqlReader["SubDeptName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_SubDepartment_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@SubDeptID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_SubDepartment_Delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_LocationMaster_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@LocationID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@LocationName", objprp.DeptName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_LocationMaster_Update";

                return sqlCmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_LocationMaster_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@LocationName", objprp.DeptName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_LocationMaster_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_LocationMaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@LocationID", objprp.DeptID));


                sqlCmd.CommandText = "HCM_LocationMaster_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.DeptID = sqlReader["LocationID"].ToString();
                        p.DeptName = sqlReader["LocationName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> hcm_Get_position(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[6];
                                                                                                                                       //sqlCmd.Parameters.Add( new SqlParameter("@PositionID", objprp.PositionID);
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyCode", objprp.CompanyCode));
                sqlCmd.Parameters.Add(new SqlParameter("@UnitCode", objprp.UnitCode));
                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@SubDeptID", objprp.SubDeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@CostCenter", objprp.CostCenter));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCadre", objprp.EmpCadre));

                sqlCmd.CommandText = "hcm_Get_position";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        //p.CompanyCode = sqlReader["CompanyCode"].ToString();
                        //p.UnitCode = sqlReader["UnitCode"].ToString();
                        //p.DeptID = sqlReader["DeptID"].ToString();
                        //p.SubDeptID = sqlReader["SubDeptID"].ToString();
                        //p.CostCenter = sqlReader["CostCenter"].ToString();
                        p.PositionID = sqlReader["PositionID"].ToString();
                        p.PositionName = sqlReader["PositionName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }


        public string HCM_LocationMaster_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@LocationID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_LocationMaster_Delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }

        public List<PRPsetupWork> HCM_CostCenter_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@CostCenterID", objprp.DeptID));


                sqlCmd.CommandText = "HCM_CostCenter_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.DeptID = sqlReader["CostCenterID"].ToString();
                        p.DeptName = sqlReader["CostCenterName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_CostCenter_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@CostCenterID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_CostCenter_Delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_CostCenter_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@CostCenterName", objprp.DeptName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_CostCenter_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }

        public string HCM_CostCenter_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@CostCenterID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@CostCenterName", objprp.DeptName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_CostCenter_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_Position_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[14];

                sqlCmd.Parameters.Add(new SqlParameter("@PositionName", objprp.PositionName));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyCode", objprp.CompanyCode));
                sqlCmd.Parameters.Add(new SqlParameter("@UnitCode", objprp.UnitCode));
                sqlCmd.Parameters.Add(new SqlParameter("@LocationID", objprp.LocationID));
                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@SubDeptID", objprp.SubDeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@CostCenter", objprp.CostCenter));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCadre", objprp.EmpCadre));
                sqlCmd.Parameters.Add(new SqlParameter("@DesinID", objprp.DesinID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@PositionCode", objprp.PositionCode));
                sqlCmd.CommandText = "HCM_Position_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }

        public string HCM_Position_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@PositionID", objprp.PositionID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Position_Delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_position_gridfill(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@active", objprp.Active));
                sqlCmd.Parameters.Add(new SqlParameter("@name", objprp.name));


                sqlCmd.CommandText = "HCM_position_gridfill";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {


                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.PositionID = sqlReader["PositionID"].ToString();
                        p.PositionCode = sqlReader["PositionCode"].ToString();
                        p.PositionName = sqlReader["PositionName"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.CompanyName = sqlReader["CompanyName"].ToString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.LocationName = sqlReader["LocationName"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.SubDeptName = sqlReader["SubDeptName"].ToString();
                        p.CostCenterName = sqlReader["CostCenterName"].ToString();
                        p.EmpCadrename = sqlReader["EmpCadreName"].ToString();
                        p.DesignName = sqlReader["DesignName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_Position_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[15];

                sqlCmd.Parameters.Add(new SqlParameter("@PositionName", objprp.PositionName));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyCode", objprp.CompanyCode));
                sqlCmd.Parameters.Add(new SqlParameter("@UnitCode", objprp.UnitCode));
                sqlCmd.Parameters.Add(new SqlParameter("@LocationID", objprp.LocationID));
                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@SubDeptID", objprp.SubDeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@CostCenter", objprp.CostCenter));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCadre", objprp.EmpCadre));
                sqlCmd.Parameters.Add(new SqlParameter("@DesinID", objprp.DesinID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@PositionID", objprp.PositionID));
                sqlCmd.Parameters.Add(new SqlParameter("@PositionCode", objprp.PositionCode));

                sqlCmd.CommandText = "HCM_Position_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }

        public List<PRPsetupWork> hcm_getunibycompany(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@companycode", objprp.CompanyCode));


                sqlCmd.CommandText = "hcm_getunibycompany";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.UnitCode = sqlReader["unitcode"].ToString();
                        p.UnitName = sqlReader["unitname"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> hcm_Get_subdept_by_dept(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.DeptID));


                sqlCmd.CommandText = "hcm_Get_subdept_by_dept";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.SubDeptID = sqlReader["SubDeptID"].ToString();
                        p.SubDeptName = sqlReader["SubDeptName"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.DeptID = sqlReader["DeptID"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }


        public List<PRPsetupWork> HCM_empcadremaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@empcadre", objprp.DeptID));


                sqlCmd.CommandText = "HCM_empcadremaster_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {
                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.DeptID = sqlReader["empcadre"].ToString();
                        p.DeptName = sqlReader["empcadrename"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Position_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@PositionID", objprp.PositionID));


                sqlCmd.CommandText = "HCM_Position_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.PositionID = sqlReader["PositionID"].ToString();
                        p.PositionName = sqlReader["PositionName"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.CompanyCode = sqlReader["CompanyCode"].ToString();
                        p.CompanyName = sqlReader["CompanyName"].ToString();
                        p.UnitCode = sqlReader["UnitCode"].ToString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.LocationID = sqlReader["LocationID"].ToString();
                        p.LocationName = sqlReader["LocationName"].ToString();
                        p.DeptID = sqlReader["DeptId"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.SubDeptID = sqlReader["SubDeptID"].ToString();
                        p.SubDeptName = sqlReader["SubDeptName"].ToString();
                        p.CostCenter = sqlReader["CostCenter"].ToString();
                        p.CostCenterName = sqlReader["CostCenterName"].ToString();
                        p.EmpCadre = sqlReader["EmpCadre"].ToString();
                        p.EmpCadrename = sqlReader["EmpCadreName"].ToString();
                        p.DesinID = sqlReader["DesinID"].ToString();
                        p.DesignName = sqlReader["DesignName"].ToString();
                        p.PositionCode = sqlReader["PositionCode"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_BankMaster_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@BankID", objprp.BankID));
                sqlCmd.Parameters.Add(new SqlParameter("@BankName", objprp.BankName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_BankMaster_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_BankMaster_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@BankName", objprp.BankName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_BankMaster_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_BankMaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@BankID", objprp.BankID));


                sqlCmd.CommandText = "HCM_BankMaster_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.BankID = sqlReader["BankID"].ToString();
                        p.BankName = sqlReader["BankName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_BankMaster_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@BankID", objprp.BankID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_BankMaster_Delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }


        public string HCM_InstituteMaster_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@InstName", objprp.BankName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_InstituteMaster_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_InstituteMaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@InstID", objprp.BankID));


                sqlCmd.CommandText = "HCM_InstituteMaster_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.BankID = sqlReader["InstID"].ToString();
                        p.BankName = sqlReader["InstName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_InstituteMaster_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@InstID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@InstName", objprp.BankName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_InstituteMaster_Update";

                return sqlCmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_InstituteMaster_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@InstID", objprp.BankID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_InstituteMaster_Delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }



        public string HCM_DesignationtMaster_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@DesignName", objprp.DeptName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_DesignationtMaster_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_DesignationtMaster_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@DesignID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@DesignName", objprp.DeptName));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_DesignationtMaster_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_DesignationtMaster_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@DesignID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_DesignationtMaster_Delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }

        public List<PRPsetupWork> HCM_DesignationtMaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@DesignID", objprp.DeptID));


                sqlCmd.CommandText = "HCM_DesignationtMaster_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.DeptID = sqlReader["DesignID"].ToString();
                        p.DeptName = sqlReader["DesignName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }


        public string HCM_Employee_PersonalData_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[16];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@Title ", objprp.Title));
                sqlCmd.Parameters.Add(new SqlParameter("@FirstName", objprp.FirstName));
                sqlCmd.Parameters.Add(new SqlParameter("@MiddleName", objprp.MiddleName));
                sqlCmd.Parameters.Add(new SqlParameter("@LastName", objprp.LastName));

                sqlCmd.Parameters.Add(new SqlParameter("@BirthPlace", objprp.BirthPlace));
                sqlCmd.Parameters.Add(new SqlParameter("@MaritalStatus", objprp.MaritalStatus));
                sqlCmd.Parameters.Add(new SqlParameter("@WeddingDate", objprp.Weddingdate));
                sqlCmd.Parameters.Add(new SqlParameter("@Gender", objprp.Gender));
                sqlCmd.Parameters.Add(new SqlParameter("@Nationality", objprp.CountryName));
                sqlCmd.Parameters.Add(new SqlParameter("@Religion", objprp.Religion));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@DateOfBirth", objprp.DateOfBirth));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_PersonalData_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }



        public string HCM_Employee_OrgAssignment_InsertHiring(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[13];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyCode ", objprp.CompanyCode));
                sqlCmd.Parameters.Add(new SqlParameter("@UnitCode", objprp.UnitCode));
                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@SubDeptID", objprp.SubDeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@CostCenter", objprp.CostCenter));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCadre", objprp.EmpCadre));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpStatus", objprp.EmpStatus));
                sqlCmd.Parameters.Add(new SqlParameter("@Position", objprp.PositionID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_OrgAssignment_InsertHiring";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_Employee_Address_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[14];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@AdrType ", objprp.addresstype));
                sqlCmd.Parameters.Add(new SqlParameter("@Address1", objprp.Address));
                sqlCmd.Parameters.Add(new SqlParameter("@Address2", objprp.Address1));
                sqlCmd.Parameters.Add(new SqlParameter("@Address3", objprp.Address2));
                sqlCmd.Parameters.Add(new SqlParameter("@City", objprp.CityID));
                sqlCmd.Parameters.Add(new SqlParameter("@StateID", objprp.StateID));
                sqlCmd.Parameters.Add(new SqlParameter("@CountryID", objprp.CountryID));
                sqlCmd.Parameters.Add(new SqlParameter("@TelePhone1", objprp.ContactNo));
                sqlCmd.Parameters.Add(new SqlParameter("@TelePhone2", objprp.ContactNo1));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_Address_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_AddressTypes_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@AdrType", objprp.DeptID));


                sqlCmd.CommandText = "HCM_AddressTypes_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.DeptID = sqlReader["AdrType"].ToString();
                        p.DeptName = sqlReader["AdrTypeName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Employee_BankDetails_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[9];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@BankID ", objprp.BankID));
                sqlCmd.Parameters.Add(new SqlParameter("@BankAccountNo", objprp.Bankaccno));
                sqlCmd.Parameters.Add(new SqlParameter("@PaymentMode", objprp.paymode));
                sqlCmd.Parameters.Add(new SqlParameter("@Remarks", objprp.Remarks));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_BankDetails_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_FamilyType_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@FTypeID", objprp.EmpID));


                sqlCmd.CommandText = "HCM_FamilyType_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.EmpID = sqlReader["FTypeID"].ToString();
                        p.name = sqlReader["FTypeDesc"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Employee_FamilyDetails_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[7];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@FTypeID", objprp.FTypeID));
                sqlCmd.Parameters.Add(new SqlParameter("@FMName ", objprp.name));
                sqlCmd.Parameters.Add(new SqlParameter("@Gender", objprp.Gender));
                sqlCmd.Parameters.Add(new SqlParameter("@DOB", objprp.DateOfBirth));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_FamilyDetails_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }


        public string HCM_Employee_EducationDetails_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[10];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@InstID ", objprp.InstID));
                sqlCmd.Parameters.Add(new SqlParameter("@EduID", objprp.EduID));
                sqlCmd.Parameters.Add(new SqlParameter("@StudyBranchID1", objprp.StudyBranchID1));
                sqlCmd.Parameters.Add(new SqlParameter("@StudyBranchID2", objprp.StudyBranchID2));
                sqlCmd.Parameters.Add(new SqlParameter("@FinalGrade", objprp.FinalGrade));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_EducationDetails_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Employee_MedicalData_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[17];

                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@LastExamination ", objprp.LastExamination));
                sqlCmd.Parameters.Add(new SqlParameter("@BloodGroup", objprp.BloodGroup));
                sqlCmd.Parameters.Add(new SqlParameter("@BPHigh", objprp.BPHigh));
                sqlCmd.Parameters.Add(new SqlParameter("@BpLow", objprp.BpLow));
                sqlCmd.Parameters.Add(new SqlParameter("@Height", objprp.Height));
                sqlCmd.Parameters.Add(new SqlParameter("@Weight ", objprp.Weight));
                sqlCmd.Parameters.Add(new SqlParameter("@EyesColor", objprp.EyesColor));
                sqlCmd.Parameters.Add(new SqlParameter("@EyeDistantVision", objprp.EyeDistantVision));
                sqlCmd.Parameters.Add(new SqlParameter("@EyeNearVision", objprp.EyeNearVision));
                sqlCmd.Parameters.Add(new SqlParameter("@HairColor", objprp.haircolor));
                sqlCmd.Parameters.Add(new SqlParameter("@IdentityMark", objprp.IdentityMark));
                sqlCmd.Parameters.Add(new SqlParameter("@ColourBlindness", objprp.ColourBlindness));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_MedicalData_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }



        public List<PRPsetupWork> HCM_EducationGradeMaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@EGID", objprp.BankID));


                sqlCmd.CommandText = "HCM_EducationGradeMaster_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.BankID = sqlReader["EGID"].ToString();
                        p.BankName = sqlReader["EGName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }



        public List<PRPsetupWork> HCM_StudyBranch_display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@StudyBranchID", objprp.BankID));


                sqlCmd.CommandText = "HCM_StudyBranch_display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.BankID = sqlReader["StudyBranchID"].ToString();
                        p.BankName = sqlReader["StudyBranchName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_EducationMaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@EduID", objprp.BankID));


                sqlCmd.CommandText = "HCM_EducationMaster_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.BankID = sqlReader["EduID"].ToString();
                        p.BankName = sqlReader["EduName"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }



        public string HCM_Employee_PersonalIDs_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[7];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@IDType ", objprp.IDType));
                sqlCmd.Parameters.Add(new SqlParameter("@IDValue", objprp.IDValue));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_PersonalIDs_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_Employee_PerviousExperience_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[10];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyName ", objprp.CompanyName));
                sqlCmd.Parameters.Add(new SqlParameter("@Department", objprp.DeptName));
                sqlCmd.Parameters.Add(new SqlParameter("@Industry", objprp.Industry));
                sqlCmd.Parameters.Add(new SqlParameter("@Salary", objprp.Salary));
                sqlCmd.Parameters.Add(new SqlParameter("@TotalExp", objprp.TotalExp));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_PerviousExperience_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }


        public string HCM_Employee_CommunicationDetails_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[7];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@CommType ", objprp.CommType));
                sqlCmd.Parameters.Add(new SqlParameter("@CommValue", objprp.CommValue));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_CommunicationDetails_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }


        public List<PRPsetupWork> HCM_PayScaleMaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@ScaleID", objprp.DeptID));


                sqlCmd.CommandText = "HCM_PayScaleMaster_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.DeptID = sqlReader["ScaleID"].ToString();
                        p.DeptName = sqlReader["ScaleName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_Employee_BasicPay_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[7];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@ScaleID ", objprp.ScaleID));
                sqlCmd.Parameters.Add(new SqlParameter("@AnnualSalary", objprp.ctc));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_BasicPay_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }


        public string HCM_Employee_DailyWorkingSchedule_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[9];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@TimeType ", objprp.TimeType));
                sqlCmd.Parameters.Add(new SqlParameter("@ShiftCode", objprp.ShiftCode));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@WeekOff", objprp.WeekOff));
                sqlCmd.Parameters.Add(new SqlParameter("@overtime", objprp.Overtime));
                sqlCmd.CommandText = "HCM_Employee_DailyWorkingSchedule_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Employee_ReportingStructure_Insert(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[8];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@SupervisorID ", objprp.Supervisor));
                sqlCmd.Parameters.Add(new SqlParameter("@HODID", objprp.Hod));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@CPOID", objprp.Cpo));

                sqlCmd.CommandText = "HCM_Employee_ReportingStructure_Insert";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Employee_ReportingStructure_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[9];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@SupervisorID ", objprp.Supervisor));
                sqlCmd.Parameters.Add(new SqlParameter("@HODID", objprp.Hod));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@CPOID", objprp.Cpo));
                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.ID));

                sqlCmd.CommandText = "HCM_Employee_ReportingStructure_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_Employee_ReportingStructure_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));


                sqlCmd.CommandText = "HCM_Employee_ReportingStructure_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();

                        p.Supervisor = sqlReader["SupervisorID"].ToString();
                        p.Hod = sqlReader["HODID"].ToString();
                        p.Cpo = sqlReader["CPOID"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_TimeTypeMaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@TimeType", objprp.DeptID));


                sqlCmd.CommandText = "HCM_TimeTypeMaster_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();

                        p.DeptID = sqlReader["TimeType"].ToString();
                        p.DeptName = sqlReader["TimeTypeDesc"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_ShiftMaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@ShiftCode", objprp.DeptID));


                sqlCmd.CommandText = "HCM_ShiftMaster_Display";
                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.DeptID = sqlReader["ShiftCode"].ToString();
                        p.DeptName = sqlReader["ShiftDesc"].ToString();
                        p.StartDate = sqlReader["StartTime"].ToString();
                        p.EndDate = sqlReader["EndTime"].ToString();
                        p.type = sqlReader["TotWorkingHours"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_Employee_Address_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[15];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@AdrType ", objprp.addresstype));
                sqlCmd.Parameters.Add(new SqlParameter("@Address1", objprp.Address));
                sqlCmd.Parameters.Add(new SqlParameter("@Address2", objprp.Address1));
                sqlCmd.Parameters.Add(new SqlParameter("@Address3", objprp.Address2));
                sqlCmd.Parameters.Add(new SqlParameter("@City", objprp.CityID));
                sqlCmd.Parameters.Add(new SqlParameter("@StateID", objprp.StateID));
                sqlCmd.Parameters.Add(new SqlParameter("@CountryID", objprp.CountryID));
                sqlCmd.Parameters.Add(new SqlParameter("@TelePhone1", objprp.ContactNo));
                sqlCmd.Parameters.Add(new SqlParameter("@TelePhone2", objprp.ContactNo1));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));

                sqlCmd.CommandText = "HCM_Employee_Address_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> HCM_Employee_Address_display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));



                sqlCmd.CommandText = "HCM_Employee_Address_display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();

                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.addresstype = sqlReader["AdrType"].ToString();
                        p.addresstypename = sqlReader["AdrTypeName"].ToString();
                        p.Address = sqlReader["Address1"].ToString();
                        p.Address1 = sqlReader["Address2"].ToString();
                        p.Address2 = sqlReader["Address3"].ToString();
                        p.City = sqlReader["City"].ToString();
                        p.CityName = sqlReader["CityName"].ToString();
                        p.StateID = sqlReader["StateID"].ToString();
                        p.StateName = sqlReader["StateName"].ToString();
                        p.CountryID = sqlReader["CountryID"].ToString();
                        p.CountryName = sqlReader["CountryName"].ToString();
                        p.ContactNo = sqlReader["TelePhone1"].ToString();
                        p.ContactNo1 = sqlReader["TelePhone2"].ToString();
                        p.ID = sqlReader["ID"].ToString();
                        obj.Add(p);
                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Employee_Address_delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[4];

                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_Address_delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_Employee_ReportingStructure_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[4];

                sqlCmd.Parameters.Add(new SqlParameter("@TransID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_ReportingStructure_Delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }

        public string HCM_Employee_PersonalData_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[17];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@Title ", objprp.Title));
                sqlCmd.Parameters.Add(new SqlParameter("@FirstName", objprp.FirstName));
                sqlCmd.Parameters.Add(new SqlParameter("@MiddleName", objprp.MiddleName));
                sqlCmd.Parameters.Add(new SqlParameter("@LastName", objprp.LastName));
                sqlCmd.Parameters.Add(new SqlParameter("@BirthPlace", objprp.BirthPlace));
                sqlCmd.Parameters.Add(new SqlParameter("@MaritalStatus", objprp.MaritalStatus));
                sqlCmd.Parameters.Add(new SqlParameter("@WeddingDate", objprp.Weddingdate));
                sqlCmd.Parameters.Add(new SqlParameter("@Gender", objprp.Gender));
                sqlCmd.Parameters.Add(new SqlParameter("@Nationality", objprp.CountryName));
                sqlCmd.Parameters.Add(new SqlParameter("@Religion", objprp.Religion));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@DateOfBirth", objprp.DateOfBirth));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));

                sqlCmd.CommandText = "HCM_Employee_PersonalData_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }


        public List<PRPsetupWork> HCM_Employee_PersonalData_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));



                sqlCmd.CommandText = "HCM_Employee_PersonalData_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.Title = sqlReader["Title"].ToString();
                        p.FirstName = sqlReader["FirstName"].ToString();
                        p.MiddleName = sqlReader["MiddleName"].ToString();
                        p.LastName = sqlReader["LastName"].ToString();
                        p.DateOfBirth = sqlReader["DateOfBirth"].ToString();
                        p.BirthPlace = sqlReader["BirthPlace"].ToString();
                        p.MaritalStatus = sqlReader["MaritalStatus"].ToString();
                        p.Weddingdate = sqlReader["Weddingdate"].ToString();
                        p.Gender = sqlReader["Gender"].ToString();
                        p.CountryID = sqlReader["CountryID"].ToString();
                        p.CountryName = sqlReader["CountryName"].ToString();
                        p.Religion = sqlReader["Religion"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Employee_BankDetails_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[1];

                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));

                sqlCmd.CommandText = "HCM_Employee_BankDetails_Delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }

        public string HCM_Employee_BankDetails_Update(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[10];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@BankID ", objprp.BankID));
                sqlCmd.Parameters.Add(new SqlParameter("@BankAccountNo", objprp.Bankaccno));
                sqlCmd.Parameters.Add(new SqlParameter("@PaymentMode", objprp.paymode));
                sqlCmd.Parameters.Add(new SqlParameter("@Remarks", objprp.Remarks));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.CommandText = "HCM_Employee_BankDetails_Update";
                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_Employee_BankDetails_display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));

                sqlCmd.CommandText = "HCM_Employee_BankDetails_display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.BankID = sqlReader["BankID"].ToString();
                        p.BankName = sqlReader["BankName"].ToString();
                        p.Bankaccno = sqlReader["BankAccountNo"].ToString();
                        p.paymode = sqlReader["PaymentMode"].ToString();
                        p.Remarks = sqlReader["Remarks"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_Employee_OrgAssignment_display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));


                sqlCmd.CommandText = "HCM_Employee_OrgAssignment_display";
                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {
                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.CompanyCode = sqlReader["CompanyCode"].ToString();
                        p.CompanyName = sqlReader["CompanyName"].ToString();
                        p.UnitCode = sqlReader["UnitCode"].ToString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        p.DeptID = sqlReader["DeptID"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.SubDeptID = sqlReader["SubDeptID"].ToString();
                        p.SubDeptName = sqlReader["SubDeptName"].ToString();
                        p.CostCenter = sqlReader["CostCenter"].ToString();
                        p.CostCenterName = sqlReader["CostCenterName"].ToString();
                        p.EmpCadre = sqlReader["EmpCadre"].ToString();
                        p.EmpCadrename = sqlReader["EmpCadreName"].ToString();
                        p.EmpStatus = sqlReader["EmpStatus"].ToString();
                        p.PositionID = sqlReader["Position"].ToString();
                        p.PositionName = sqlReader["PositionName"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_Employee_OrgAssignment_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[14];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyCode ", objprp.CompanyCode));
                sqlCmd.Parameters.Add(new SqlParameter("@UnitCode", objprp.UnitCode));
                sqlCmd.Parameters.Add(new SqlParameter("@DeptID", objprp.DeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@SubDeptID", objprp.SubDeptID));
                sqlCmd.Parameters.Add(new SqlParameter("@CostCenter", objprp.CostCenter));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpCadre", objprp.EmpCadre));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpStatus", objprp.EmpStatus));
                sqlCmd.Parameters.Add(new SqlParameter("@Position", objprp.PositionID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.CommandText = "HCM_Employee_OrgAssignment_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Employee_OrgAssignment_Delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));

                sqlCmd.CommandText = "HCM_Employee_OrgAssignment_Delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public string HCM_Employee_CommunicationDetails_delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[1];

                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));


                sqlCmd.CommandText = "HCM_Employee_CommunicationDetails_delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }

        public List<PRPsetupWork> HCM_Employee_CommunicationDetails_display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));

                sqlCmd.CommandText = "HCM_Employee_CommunicationDetails_display";
                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {
                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.CommType = sqlReader["CommType"].ToString();
                        p.CommValue = sqlReader["CommValue"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_Employee_CommunicationDetails_update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[8];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@CommType ", objprp.CommType));
                sqlCmd.Parameters.Add(new SqlParameter("@CommValue", objprp.CommValue));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.CommandText = "HCM_Employee_CommunicationDetails_update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_Employee_PersonalIDs_delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_PersonalIDs_delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }


        }

        public List<PRPsetupWork> HCM_Employee_PersonalIDs_display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));

                sqlCmd.CommandText = "HCM_Employee_PersonalIDs_display";
                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {
                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.IDType = sqlReader["IDType"].ToString();
                        p.IDTypeName = sqlReader["IDTypeName"].ToString();
                        p.IDValue = sqlReader["IDValue"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }


        public string HCM_Employee_PersonalIDs_update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[8];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@IDType ", objprp.IDType));
                sqlCmd.Parameters.Add(new SqlParameter("@IDValue", objprp.IDValue));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.CommandText = "HCM_Employee_PersonalIDs_update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_IDTypeMaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@IDType", objprp.IDType));


                sqlCmd.CommandText = "HCM_IDTypeMaster_Display";
                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {
                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.IDType = sqlReader["IDType"].ToString();
                        p.IDTypeName = sqlReader["IDTypeName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_CommType_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@CommType", objprp.IDType));


                sqlCmd.CommandText = "HCM_CommType_Display";
                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {
                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.IDType = sqlReader["CommType"].ToString();
                        p.IDTypeName = sqlReader["CommTypeName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Employee_PerviousExperience_delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_PerviousExperience_delete";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }

        public string HCM_Employee_PerviousExperience_update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[11];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyName ", objprp.CompanyName));
                sqlCmd.Parameters.Add(new SqlParameter("@Department", objprp.DeptName));
                sqlCmd.Parameters.Add(new SqlParameter("@Industry", objprp.Industry));
                sqlCmd.Parameters.Add(new SqlParameter("@Salary", objprp.Salary));
                sqlCmd.Parameters.Add(new SqlParameter("@TotalExp", objprp.TotalExp));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));

                sqlCmd.CommandText = "HCM_Employee_PerviousExperience_update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Employee_PerviousExperience_display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));


                sqlCmd.CommandText = "HCM_Employee_PerviousExperience_display";
                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {
                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.CompanyName = sqlReader["CompanyName"].ToString();
                        p.DeptName = sqlReader["Department"].ToString();
                        p.Industry = sqlReader["Industry"].ToString();
                        p.Salary = sqlReader["Salary"].ToString();
                        p.TotalExp = sqlReader["TotalExp"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Employee_MedicalData_update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[18];

                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@LastExamination ", objprp.LastExamination));
                sqlCmd.Parameters.Add(new SqlParameter("@BloodGroup", objprp.BloodGroup));
                sqlCmd.Parameters.Add(new SqlParameter("@BPHigh", objprp.BPHigh));
                sqlCmd.Parameters.Add(new SqlParameter("@BpLow", objprp.BpLow));
                sqlCmd.Parameters.Add(new SqlParameter("@Height", objprp.Height));
                sqlCmd.Parameters.Add(new SqlParameter("@Weight ", objprp.Weight));
                sqlCmd.Parameters.Add(new SqlParameter("@EyesColor", objprp.EyesColor));
                sqlCmd.Parameters.Add(new SqlParameter("@EyeDistantVision", objprp.EyeDistantVision));
                sqlCmd.Parameters.Add(new SqlParameter("@EyeNearVision", objprp.EyeNearVision));
                sqlCmd.Parameters.Add(new SqlParameter("@HairColor", objprp.haircolor));
                sqlCmd.Parameters.Add(new SqlParameter("@IdentityMark", objprp.IdentityMark));
                sqlCmd.Parameters.Add(new SqlParameter("@ColourBlindness", objprp.ColourBlindness));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.CommandText = "HCM_Employee_MedicalData_update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_Employee_MedicalData_display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));


                sqlCmd.CommandText = "HCM_Employee_MedicalData_display";
                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {
                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.LastExamination = sqlReader["LastExamination"].ToString();
                        p.BloodGroup = sqlReader["BloodGroup"].ToString();
                        p.BPHigh = sqlReader["BPHigh"].ToString();
                        p.BpLow = sqlReader["BpLow"].ToString();
                        p.Height = sqlReader["Height"].ToString();
                        p.Weight = sqlReader["Weight"].ToString();
                        p.EyesColor = sqlReader["EyesColor"].ToString();
                        p.EyeDistantVision = sqlReader["EyeDistantVision"].ToString();
                        p.EyeNearVision = sqlReader["EyeNearVision"].ToString(); p.TotalExp = sqlReader["Height"].ToString();
                        p.haircolor = sqlReader["HairColor"].ToString();
                        p.IdentityMark = sqlReader["IdentityMark"].ToString();
                        p.ColourBlindness = sqlReader["ColourBlindness"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Employee_MedicalData_delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_MedicalData_delete";

                return sqlCmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_Employee_FamilyDetails_display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));


                sqlCmd.CommandText = "HCM_Employee_FamilyDetails_display";
                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {
                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.FTypeID = sqlReader["FTypeID"].ToString();
                        p.FTypeDesc = sqlReader["FTypeDesc"].ToString();
                        p.name = sqlReader["FMName"].ToString();
                        p.Gender = sqlReader["Gender"].ToString();
                        p.DateOfBirth = sqlReader["DOB"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_Employee_FamilyDetails_delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_FamilyDetails_delete";

                return sqlCmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public string HCM_Employee_FamilyDetails_update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[8];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@FTypeID", objprp.FTypeID));
                sqlCmd.Parameters.Add(new SqlParameter("@FMName ", objprp.name));
                sqlCmd.Parameters.Add(new SqlParameter("@Gender", objprp.Gender));
                sqlCmd.Parameters.Add(new SqlParameter("@DOB", objprp.DateOfBirth));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.CommandText = "HCM_Employee_FamilyDetails_update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_Employee_EducationDetails_Update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[11];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@InstID ", objprp.InstID));
                sqlCmd.Parameters.Add(new SqlParameter("@EduID", objprp.EduID));
                sqlCmd.Parameters.Add(new SqlParameter("@StudyBranchID1", objprp.StudyBranchID1));
                sqlCmd.Parameters.Add(new SqlParameter("@StudyBranchID2", objprp.StudyBranchID2));
                sqlCmd.Parameters.Add(new SqlParameter("@FinalGrade", objprp.FinalGrade));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.CommandText = "HCM_Employee_EducationDetails_Update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Employee_EducationDetails_display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));


                sqlCmd.CommandText = "HCM_Employee_EducationDetails_display";
                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {
                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.InstID = sqlReader["InstID"].ToString();
                        p.InstName = sqlReader["InstName"].ToString();
                        p.EduID = sqlReader["EduID"].ToString();
                        p.EduName = sqlReader["EduName"].ToString();
                        p.StudyBranchID1 = sqlReader["StudyBranchID1"].ToString();
                        p.StudyBranchName = sqlReader["StudyBranchName"].ToString();
                        p.StudyBranchID2 = sqlReader["StudyBranchID2"].ToString();
                        p.StudyBranchName2 = sqlReader["StudyBranchName"].ToString();
                        p.FinalGrade = sqlReader["FinalGrade"].ToString();
                        p.EGName = sqlReader["EGName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_Employee_EducationDetails_delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_EducationDetails_delete";

                return sqlCmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_Employee_DailyWorkingSchedule_update(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[10];


                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@StartDate", objprp.StartDate));
                sqlCmd.Parameters.Add(new SqlParameter("@EndDate", objprp.EndDate));
                sqlCmd.Parameters.Add(new SqlParameter("@TimeType ", objprp.TimeType));
                sqlCmd.Parameters.Add(new SqlParameter("@ShiftCode", objprp.ShiftCode));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.Parameters.Add(new SqlParameter("@WeekOff", objprp.WeekOff));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@overtime", objprp.Overtime));
                sqlCmd.CommandText = "HCM_Employee_DailyWorkingSchedule_update";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_Employee_DailyWorkingSchedule_display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));
                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));


                sqlCmd.CommandText = "HCM_Employee_DailyWorkingSchedule_display";
                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {
                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.StartDate = sqlReader["StartDate"].ToString();
                        p.EndDate = sqlReader["EndDate"].ToString();
                        p.TimeType = sqlReader["TimeType"].ToString();
                        p.ShiftCode = sqlReader["ShiftCode"].ToString();
                        p.ShiftDesc = sqlReader["ShiftDesc"].ToString();
                        p.WeekOff = sqlReader["WeekOff"].ToString();
                        p.WeekOffName = sqlReader["WeekOffName"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public string HCM_Employee_DailyWorkingSchedule_delete(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure; //ADOprp.ArrayPram =  new SqlParameter[3];

                sqlCmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@Crby", objprp.Crby));
                sqlCmd.Parameters.Add(new SqlParameter("@CrIP", ipad.GetLocalIpAddress()));
                sqlCmd.CommandText = "HCM_Employee_DailyWorkingSchedule_delete";

                return sqlCmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_WeekOffMaster_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@weekoff", objprp.DeptID));


                sqlCmd.CommandText = "HCM_WeekOffMaster_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.DeptID = sqlReader["weekoff"].ToString();
                        p.DeptName = sqlReader["WeekOffName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_LeaveMaster_opening_Display(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@LeaveID", objprp.DeptID));


                sqlCmd.CommandText = "HCM_LeaveMaster_opening_Display";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.DeptID = sqlReader["LeaveID"].ToString();
                        p.DeptName = sqlReader["Opening"].ToString();
                        p.DeptLevel = sqlReader["Avail"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        PRPsetupWork p = new PRPsetupWork();
        public PRPsetupWork hCM_login_chevk(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[3];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@pwd", objprp.name));
                sqlCmd.Parameters.Add(new SqlParameter("@ip", objprp.type));
                sqlCmd.CommandText = "hCM_login_chevk";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);



                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        p.ID = sqlReader["id"].ToString();
                        p.name = sqlReader["msg"].ToString();
                        p.logid = sqlReader["loginid"].ToString();
                        p.role = sqlReader["role"].ToString();
                        p.name = sqlReader["UserName"].ToString();

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return p;
            }
            catch (Exception ex)
            {
                return p;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> HCM_leave_dashboard(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.ID));


                sqlCmd.CommandText = "HCM_leave_dashboard";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.TotalDays = sqlReader["total"].ToString();
                        p.CASUAL_LEAVE = sqlReader["avail"].ToString();
                        p.SICK_LEAVE = sqlReader["balance"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_sp_ChkLoanBal(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));


                sqlCmd.CommandText = "HCM_sp_ChkLoanBal";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.BankID = sqlReader["Bal"].ToString();
                        p.BankName = sqlReader["LastLoanAmount"].ToString();
                        p.paymode = sqlReader["TotalPaidInstls"].ToString();
                        p.HodAppFlag1 = sqlReader["flag"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> sp_MedReimDashBoard(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
                sqlCmd.Parameters.Add(new SqlParameter("@EmpID", objprp.EmpID));


                sqlCmd.CommandText = "sp_MedReimDashBoard";

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.AllowName = sqlReader["AllowName"].ToString();
                        p.monthname = sqlReader["monthname"].ToString();
                        p.ToYr = sqlReader["ToYr"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> sp_LoadFestivalMaster(PRPsetupWork objprp)
        {
            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[1];
               sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));


                sqlCmd.CommandText = "sp_LoadFestivalMaster";



                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["id"].ToString();
                        p.FestivalDate = sqlReader["FestivalDate"].ToString();
                        p.FestivalName = sqlReader["FestivalName"].ToString();

                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }

        }
        public List<PRPsetupWork> Get_RetirementPerson(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                //sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                //sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));

                sqlCmd.CommandText = "Get_RetirementPerson";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader(); obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.ID = sqlReader["ID"].ToString();

                        p.EmpID = sqlReader["EmpID"].ToString();
                        p.name = sqlReader["Name"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.SubDeptName = sqlReader["SubDeptName"].ToString();
                        p.DateOFBirth = sqlReader["DOB"].ToString();
                        p.TotalExp = sqlReader["exp"].ToString();
                        p.UnitName = sqlReader["UnitName"].ToString();

                        p.StartDate = sqlReader["StartDate"].ToString(); obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> VPL_HCM_Dashboard_dOB_anniversary(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@empid", objprp.EmpID));

                sqlCmd.CommandText = "VPL_HCM_Dashboard_dOB_anniversary";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.name = sqlReader["Name"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.SubDeptName = sqlReader["SubDeptName"].ToString();
                        p.StartDate = sqlReader["DOB"].ToString();
                        p.TotalExp = sqlReader["exp"].ToString();
                        p.UnitName = sqlReader["UnitName"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }
        public List<PRPsetupWork> HCM_get_Dashbord(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));


                sqlCmd.CommandText = "HCM_get_Dashbord";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.name = sqlReader["name"].ToString();
                        p.ID = sqlReader["id"].ToString();
                        obj.Add(p);

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }

        public List<PRPsetupWork> Hcm_GetEmpid(PRPsetupWork objprp)
        {

            try
            {
                sqlCnn.Open(); sqlCmd = new SqlCommand(); sqlCmd.Connection = sqlCnn; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@unitcode", objprp.UnitCode));
                sqlCmd.Parameters.Add(new SqlParameter("@CompanyCode", objprp.CompanyCode));


                sqlCmd.CommandText = "Hcm_GetEmpid";

                // ADO.ReaderWithProceduresandParam(ADOprpDL);

                //    List<PRPsetupWork> obj = new List<PRPsetupWork>();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();  obj = new List<PRPsetupWork>();
                {

                    while (sqlReader.Read())
                    {
                        PRPsetupWork p = new PRPsetupWork();
                        p.EmpID = sqlReader["EmpID"].ToString();
                        obj.Add(p);

                    }
                }
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;

            }
            finally
            {
                sqlCmd.Dispose();
                sqlCnn.Close();

            }
        }


    }


}