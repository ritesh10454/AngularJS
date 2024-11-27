using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace LCM.Models
{
    public class Legalcases : db_connection_compliance 
    {
        GetLocalIP ipad = new GetLocalIP();
        public Legalcases() : base(false,false,true)
        { }

        public List<CaseList> getLegalCaseDashboard()
        {
            DataSet ds = new DataSet();
            List<CaseList> cl = new List<CaseList>();
            ConnectionOpen();
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DashboardUndatedCase";
                dat = new SqlDataAdapter(cmd);
                dat.Fill(ds);
                if (ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        cl.Add(new CaseList { TotalCase = Convert.ToInt32(drow[0].ToString()), CaseDesc= drow[1].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ds.Clear();
                dat.Dispose();
                cmd.Dispose();
                con.Close();
            }
            return cl;
        }

        public List<LegalCaseDashboard_details> Get_Dashboard_cases(string textup)
        {
            DataSet ds = new DataSet();
            List<LegalCaseDashboard_details> cl = new List<LegalCaseDashboard_details>();
            ConnectionOpen();
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LC_DashboardUndatedCase_Details";
                cmd.Parameters.AddWithValue("@textup", textup.ToString().Trim());
                dat = new SqlDataAdapter(cmd);
                dat.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        cl.Add(new LegalCaseDashboard_details { 
                            sr_no= Convert.ToInt32( drow["sr_no"].ToString()),
                            Court= drow["Court"].ToString(),
                            Amount = drow["Amount"].ToString(),
                            Case_no = drow["Case_no"].ToString(),
                            Last_Date = drow["Last_Date"].ToString(),
                            Next_Date = drow["Next_Date"].ToString(),
                            Nature_of_Case = drow["Nature_of_Case"].ToString(),
                            Petitioner = drow["Petitioner"].ToString(),
                            Respondent = drow["Respondent"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ds.Clear();
                dat.Dispose();
                cmd.Dispose();
                ConnectionClose();
            }
            return cl;
        }

        List<PRPSetup> obj;

        public string AllinOneJudgeMasterMaster(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string colnm = "";
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@JudgeId", objprp.JudgeId));
                cmd.Parameters.Add(new SqlParameter("@JudgeName", objprp.JudgeName));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@crip", ipad.GetLocalIpAddress()));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "AllinOneJudgeMasterMaster";
                colnm= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return colnm;
        }
        public List<PRPSetup> GetJudgeMasterList(PRPSetup objprp)
        {
            ConnectionOpen();
            obj = new List<PRPSetup>();
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", objprp.JudgeId));
                cmd.CommandText = "GetJudgeMasterList";
                dr = cmd.ExecuteReader(); 
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dr["ID"].ToString();
                        p.JudgeId = dr["JudgeId"].ToString();
                        p.JudgeName = dr["JudgeName"].ToString();
                        obj.Add(p);
                    }                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                dr.Close();                 
                cmd.Dispose();
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> GetCourtCityList(PRPSetup objprp)
        {
            ConnectionOpen();
            obj = new List<PRPSetup>();
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", objprp.CityID));
                cmd.CommandText = "GetCourtCityList";
                dr = cmd.ExecuteReader(); 
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dr["ID"].ToString();
                        p.CityID = dr["CityID"].ToString();
                        p.City = dr["City"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                dr.Close();
                cmd.Dispose();
                ConnectionClose();
            }
            return obj;
        }
        public string AllinOneCourtCity(PRPSetup objprp)
        {
            ConnectionOpen();
            obj = new List<PRPSetup>();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[6]; // ADOprpDL.ArrayPram = new SqlParameter[2];
                cmd.Parameters.Add(new SqlParameter("@CityID", objprp.CityID));
                cmd.Parameters.Add(new SqlParameter("@City", objprp.City));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@crip", ipad.GetLocalIpAddress()));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "AllinOneCourtCity";
                str = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return str;
        }
        public string AllinOneCaseTypeMaster(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CaseId", objprp.CaseId));
                cmd.Parameters.Add(new SqlParameter("@CaseTypeName", objprp.CaseTypeName));
                cmd.Parameters.Add(new SqlParameter("@CaseTypeShort", objprp.CaseTypeShort));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@crip", ipad.GetLocalIpAddress()));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "AllinOneCaseTypeMaster";
                str= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return str;
        }
        public List<PRPSetup> GetCaseTypelIst(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", objprp.CaseId));
                cmd.CommandText = "GetCaseTypelIst";
                dr = cmd.ExecuteReader(); 
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dr["ID"].ToString();
                        p.CaseId = dr["CaseId"].ToString();
                        p.CaseTypeName = dr["CaseTypeName"].ToString();
                        p.CaseTypeShort = dr["CaseTypeShort"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                dr.Close();
                cmd.Dispose();
                ConnectionClose();
            }
            return obj;
        }

        DataTable dtable = new DataTable();
        SqlDataAdapter adp;
        public DataTable Get_Mastertable(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = con; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", objprp.ID));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "Get_Master";
                dat = new SqlDataAdapter(cmd);
                dat.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                dat.Dispose();
                ConnectionClose();
            }
            return dtable;
        }
        public class Legalcases_Login : db_connection_compliance
        { 

            PRPSetup p = new PRPSetup();
            public Legalcases_Login(): base(true) { }
            public PRPSetup hCM_login_chevk(PRPSetup objprp)
            {
                ConnectionOpen();
                cmd = new SqlCommand();
                List<PRPSetup> obj = new List<PRPSetup>();
                try
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", objprp.ID));
                    cmd.Parameters.Add(new SqlParameter("@pwd", objprp.name));
                    cmd.Parameters.Add(new SqlParameter("@ip", objprp.type));
                    cmd.Parameters.Add(new SqlParameter("@ismobile", objprp.Active));
                    cmd.CommandText = "hCM_login_chevk";
                    dr = cmd.ExecuteReader(); 
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            p.ID = dr["id"].ToString();
                            p.name = dr["msg"].ToString();
                            p.logid = dr["loginid"].ToString();
                            p.Role = dr["role"].ToString();
                            p.UnitCode = dr["UnitCode"].ToString();
                            p.userid = dr["UserName"].ToString();
                            p.DeptName = dr["DeptName"].ToString();
                            p.Gender = dr["Gender"].ToString();
                            p.InstName = dr["A_Image"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    dr.Close();
                    cmd.Dispose();
                    ConnectionClose();
                }
                return p;
            }
        }

        public PRPSetup hCM_login_chevk(PRPSetup objprp)
        {
            PRPSetup p = new PRPSetup();
            Legalcases_Login log = new Legalcases_Login();
            p = log.hCM_login_chevk(objprp);
            return p;
        }

        public List<PRPSetup> GetUnderActmasterlIst(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", objprp.CaseId));
                cmd.CommandText = "GetUnderActmasterlIst";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dr["ID"].ToString();
                        p.UnderActID = dr["UnderActID"].ToString();
                        p.UnderActName = dr["UnderActName"].ToString();
                        p.UnderActDesc = dr["UnderActDesc"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                dr.Close();
                cmd.Dispose();
                ConnectionClose();
            }
            return obj;
        }
        public string AllinOneUnderActmaster(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UnderActID", objprp.UnderActID));
                cmd.Parameters.Add(new SqlParameter("@UnderActName", objprp.UnderActName));
                cmd.Parameters.Add(new SqlParameter("@UnderActDesc", objprp.UnderActDesc));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@crip", ipad.GetLocalIpAddress()));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "AllinOneUnderActmaster";
                str= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return str;
        }

        public List<PRPSetup> GetCaseDocumentslIst(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            DataSet ds1 = new DataSet();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", objprp.did));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "GetCaseDocumentslIst";
                dat = new SqlDataAdapter(cmd);
                dat.Fill(ds1);
                if (ds1.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow dRow in ds1.Tables[0].Rows)
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dRow["ID"].ToString();
                        p.did = dRow["did"].ToString();
                        p.TypeName = dRow["TypeName"].ToString();
                        p.document = dRow["Document"].ToString();
                        p.Udate =(dRow["Udate"].ToString() !=null)? Convert.ToDateTime( dRow["Udate"].ToString()).ToString("dd/MM/yyyy") :"";
                        p.Dtype = dRow["Dtype"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                dat.Dispose();
                ds1.Clear();
                cmd.Dispose();
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> GetDocumenttypelIst(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            DataSet ds = new DataSet();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", objprp.CaseId));
                cmd.CommandText = "GetDocumenttypelIst";
                dat = new SqlDataAdapter(cmd);
                dat.Fill(ds);
                if (ds.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow dRow in ds.Tables[0].Rows)
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dRow["ID"].ToString();
                        p.UnderActID = dRow["TypeID"].ToString();
                        p.UnderActName = dRow["TypeName"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ds.Clear();
                dat.Dispose();
                cmd.Dispose();
                ConnectionClose();
            }
            return obj;
        }
        public string AllinOneDocumenttype(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TypeID", objprp.UnderActID));
                cmd.Parameters.Add(new SqlParameter("@TypeName", objprp.UnderActName));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "AllinOneDocumenttype";
                str= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return str;
        }


        public List<PRPSetup> GetUnderSectionmasterlIst(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", objprp.CaseId));
                cmd.CommandText = "GetUnderSectionmasterlIst";
                dr = cmd.ExecuteReader(); 
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dr["ID"].ToString();
                        p.UnderSectionID = dr["UnderSectionID"].ToString();
                        p.UnderSectionName = dr["UnderSectionName"].ToString();
                        p.UnderSectionDesc = dr["UnderSectionDesc"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                dr.Close();
                ConnectionClose();
            }
            return obj;
        }
        public string AllinOneUnderSectionmaster(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UnderSectionID", objprp.UnderSectionID));
                cmd.Parameters.Add(new SqlParameter("@UnderSectionName", objprp.UnderSectionName));
                cmd.Parameters.Add(new SqlParameter("@UnderSectionDesc", objprp.UnderSectionDesc));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@crip", ipad.GetLocalIpAddress()));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "AllinOneUnderSectionmaster";
                str= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return str;
        }

        public List<PRPSetup> GetStageofCasemasterlIst(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", objprp.CaseId));
                cmd.CommandText = "GetStageofCasemasterlIst";
                dr = cmd.ExecuteReader(); obj = new List<PRPSetup>();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dr["ID"].ToString();
                        p.StageofCaseID = dr["StageofCaseID"].ToString();
                        p.StageofCaseName = dr["StageofCaseName"].ToString();
                        p.StageofCaseDesc = dr["StageofCaseDesc"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                dr.Close();
                ConnectionClose();
            }
            return obj;
        }
        public string AllinOneStageofCasemaster(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@StageofCaseID", objprp.StageofCaseID));
                cmd.Parameters.Add(new SqlParameter("@StageofCaseName", objprp.StageofCaseName));
                cmd.Parameters.Add(new SqlParameter("@StageofCaseDesc", objprp.StageofCaseDesc));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@crip", ipad.GetLocalIpAddress()));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "AllinOneStageofCasemaster";
                str= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return str;
        }


        public List<PRPSetup> GetPetitioner_Cum_RespondentlIst(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", objprp.Petitioner_Cum_RespondentID));
                cmd.Parameters.Add(new SqlParameter("@Ptype", objprp.Ptype));
                cmd.CommandText = "GetPetitioner_Cum_RespondentlIst";
                dr = cmd.ExecuteReader(); 
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dr["ID"].ToString();
                        p.Petitioner_Cum_RespondentID = dr["Petitioner_Cum_RespondentID"].ToString();
                        p.Fullname = dr["FullName"].ToString();
                        p.Relation = dr["Relation"].ToString();
                        p.Empid = dr["Empid"].ToString();
                        p.Address = dr["Address"].ToString();
                        p.ContactNo = dr["contactno"].ToString();
                        p.emailid = dr["emailid"].ToString();
                        p.CrDate = dr["crdate"].ToString();
                        p.Ptype = dr["Ptype"].ToString();
                        p.PtypeName = dr["PtypeName"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                dr.Close();
                ConnectionClose();
            }
            return obj;
        }
        public string AllinOnePetitioner_Cum_Respondent(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Petitioner_Cum_RespondentID", objprp.Petitioner_Cum_RespondentID));
                cmd.Parameters.Add(new SqlParameter("@FullName", objprp.Fullname));
                cmd.Parameters.Add(new SqlParameter("@Ptype", objprp.Ptype));
                cmd.Parameters.Add(new SqlParameter("@Relation", objprp.Relation));
                cmd.Parameters.Add(new SqlParameter("@Empid", objprp.Empid));
                cmd.Parameters.Add(new SqlParameter("@Address", objprp.Address));
                cmd.Parameters.Add(new SqlParameter("@contactno", objprp.ContactNo));
                cmd.Parameters.Add(new SqlParameter("@emailid", objprp.emailid));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@crip", ipad.GetLocalIpAddress()));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "AllinOnePetitioner_Cum_Respondent";
                str= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return str;
        }

        public string AllinOneCaseHeader(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                cmd.Parameters.Add(new SqlParameter("@CaseType", objprp.CaseType));
                cmd.Parameters.Add(new SqlParameter("@FilingNumber", objprp.FilingNumber));
                cmd.Parameters.Add(new SqlParameter("@FilingDate", objprp.FilingDate));
                cmd.Parameters.Add(new SqlParameter("@RegistrationNumber", objprp.RegistrationNumber));
                cmd.Parameters.Add(new SqlParameter("@RegistrationDate", objprp.RegistrationDate));
                cmd.Parameters.Add(new SqlParameter("@CNRNumber", objprp.CNRNumber));
                cmd.Parameters.Add(new SqlParameter("@Petitioner", objprp.Petitioner));
                cmd.Parameters.Add(new SqlParameter("@Petitioner_Advocate", objprp.Petitioner_Advocate));
                cmd.Parameters.Add(new SqlParameter("@Respondent", objprp.Respondent));
                cmd.Parameters.Add(new SqlParameter("@Respondent_Advocate", objprp.Respondent_Advocate));
                cmd.Parameters.Add(new SqlParameter("@Judge", objprp.Judge));
                cmd.Parameters.Add(new SqlParameter("@UnderAct", objprp.UnderAct));
                cmd.Parameters.Add(new SqlParameter("@UnderSection", objprp.UnderSection));
                cmd.Parameters.Add(new SqlParameter("@StageofCase", objprp.StageofCase));
                cmd.Parameters.Add(new SqlParameter("@CourtNo", objprp.CourtNo));
                cmd.Parameters.Add(new SqlParameter("@Casesummary", objprp.Casesummary));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@crip", ipad.GetLocalIpAddress()));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.Parameters.Add(new SqlParameter("@caseamount", objprp.caseamount));
                cmd.CommandText = "AllinOneCaseHeader";
                str= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return str;
        }
        public List<PRPSetup> GetCaseHeaderlIst(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                cmd.Parameters.Add(new SqlParameter("@EMpid", objprp.Empid));
                cmd.CommandText = "GetCaseHeaderlIst";
                dr = cmd.ExecuteReader(); 
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dr["ID"].ToString();
                        p.TransID = dr["TransID"].ToString();
                        p.CaseType = dr["CaseType"].ToString();
                        p.CaseTypeName = dr["CaseTypeName"].ToString();
                        p.CaseTypeShort = dr["CaseTypeShort"].ToString();
                        p.FilingNumber = dr["FilingNumber"].ToString();
                        p.FilingDate = Convert.ToDateTime( dr["FilingDate"].ToString()).ToString("dd/MM/yyyy");
                        p.RegistrationDate = Convert.ToDateTime(dr["RegistrationDate"].ToString()).ToString("dd/MM/yyyy");
                        p.RegistrationNumber = dr["RegistrationNumber"].ToString();
                        p.CNRNumber = dr["CNRNumber"].ToString();
                        p.Petitioner = dr["Petitioner"].ToString();
                        p.Petitioner_Advocate = dr["Petitioner_Advocate"].ToString();
                        p.Respondent = dr["Respondent"].ToString();
                        p.Respondent_name = dr["Respondent_name"].ToString();
                        p.Petitioner_NAME = dr["Petitioner_NAME"].ToString();
                        p.Petitioner_Advocate_name = dr["Petitioner_Advocate_name"].ToString();
                        p.Respondent_Advocate = dr["Respondent_Advocate"].ToString();
                        p.Respondent_Advocate_name = dr["Respondent_Advocate_name"].ToString();
                        p.Judge = dr["Judge"].ToString();
                        p.JudgeName = dr["JudgeName"].ToString();
                        p.UnderAct = dr["UnderAct"].ToString();
                        p.UnderActName = dr["UnderActName"].ToString();
                        p.UnderSection = dr["UnderSection"].ToString();
                        p.UnderSectionName = dr["UnderSectionName"].ToString();
                        p.StageofCase = dr["StageofCase"].ToString();
                        p.StageofCaseName = dr["StageofCaseName"].ToString();
                        p.CourtNo = dr["CourtNo"].ToString();
                        p.crbyname = dr["crbyname"].ToString();
                        p.Casesummary = dr["Casesummary"].ToString();
                        p.caseamount = dr["caseamount"].ToString();
                        p.City = dr["City"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                dr.Close();
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> GetCaseHeaderSearch(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CaseType", objprp.CaseType));
                cmd.Parameters.Add(new SqlParameter("@FilingNumber", objprp.FilingNumber));
                cmd.Parameters.Add(new SqlParameter("@FilingDate", (objprp.FilingDate != null) ? Convert.ToDateTime(objprp.FilingDate).ToString("yyyy/MM/dd") : null));
                cmd.Parameters.Add(new SqlParameter("@RegistrationNumber", objprp.RegistrationNumber));
                cmd.Parameters.Add(new SqlParameter("@RegistrationDate", (objprp.RegistrationDate != null) ? Convert.ToDateTime(objprp.RegistrationDate).ToString("yyyy/MM/dd") : null));
                cmd.Parameters.Add(new SqlParameter("@CNRNumber", objprp.CNRNumber));
                cmd.Parameters.Add(new SqlParameter("@Petitioner", objprp.Petitioner));
                cmd.Parameters.Add(new SqlParameter("@Petitioner_Advocate", objprp.Petitioner_Advocate));
                cmd.Parameters.Add(new SqlParameter("@Respondent", objprp.Respondent));
                cmd.Parameters.Add(new SqlParameter("@Respondent_Advocate", objprp.Respondent_Advocate));
                cmd.Parameters.Add(new SqlParameter("@Judge", objprp.Judge));
                cmd.Parameters.Add(new SqlParameter("@UnderAct", objprp.UnderAct));
                cmd.Parameters.Add(new SqlParameter("@UnderSection", objprp.UnderSection));
                cmd.Parameters.Add(new SqlParameter("@StageofCase", objprp.StageofCase));
                cmd.Parameters.Add(new SqlParameter("@CourtNo", objprp.CourtNo));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@from", (objprp.from !=null)? Convert.ToDateTime(objprp.from).ToString("yyyy/MM/dd") : null));
                cmd.Parameters.Add(new SqlParameter("@To", (objprp.To != null) ? Convert.ToDateTime(objprp.To).ToString("yyyy/MM/dd") : null));
                cmd.CommandText = "GetCaseHeaderSearch";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dr["ID"].ToString();
                        p.TransID = dr["TransID"].ToString();
                        p.CaseType = dr["CaseType"].ToString();
                        p.CaseTypeName = dr["CaseTypeName"].ToString();
                        p.CaseTypeShort = dr["CaseTypeShort"].ToString();
                        p.FilingNumber = dr["FilingNumber"].ToString();
                        p.FilingDate = (dr["FilingDate"] != null && dr["FilingDate"] is DateTime) ? Convert.ToDateTime(dr["FilingDate"].ToString()).ToString("dd-MM-yyyy") : null;
                        p.RegistrationDate = (dr["RegistrationDate"] != null && dr["RegistrationDate"] is DateTime) ? Convert.ToDateTime(dr["RegistrationDate"].ToString()).ToString("dd-MM-yyyy") : null;
                        p.RegistrationNumber = dr["RegistrationNumber"].ToString();
                        p.CNRNumber = dr["CNRNumber"].ToString();
                        p.Petitioner = dr["Petitioner"].ToString();
                        p.Petitioner_Advocate = dr["Petitioner_Advocate"].ToString();
                        p.Respondent = dr["Respondent"].ToString();
                        p.Respondent_name = dr["Respondent_name"].ToString();
                        p.Petitioner_NAME = dr["Petitioner_NAME"].ToString();
                        p.Petitioner_Advocate_name = dr["Petitioner_Advocate_name"].ToString();
                        p.Respondent_Advocate = dr["Respondent_Advocate"].ToString();
                        p.Respondent_Advocate_name = dr["Respondent_Advocate_name"].ToString();
                        p.Judge = dr["Judge"].ToString();
                        p.JudgeName = dr["JudgeName"].ToString();
                        p.UnderAct = dr["UnderAct"].ToString();
                        p.UnderActName = dr["UnderActName"].ToString();
                        p.UnderSection = dr["UnderSection"].ToString();
                        p.UnderSectionName = dr["UnderSectionName"].ToString();
                        p.StageofCase = dr["StageofCase"].ToString();
                        p.StageofCaseName = dr["StageofCaseName"].ToString();
                        p.CourtNo = dr["CourtNo"].ToString();
                        p.crbyname = dr["crbyname"].ToString();
                        p.Casesummary = dr["Casesummary"].ToString();
                        p.caseamount = dr["caseamount"].ToString();
                        p.City = dr["City"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                dr.Close();
                ConnectionClose();
            }
            return obj;
        }
        public DataTable GetCaseHeaderSearchTable_1(PRPSetup objprp)
        {
            DataTable dt = new DataTable();
            ConnectionOpen();
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@from", objprp.from));
                cmd.Parameters.Add(new SqlParameter("@To", objprp.To));
                cmd.Parameters.Add(new SqlParameter("@Court", objprp.CourtNo));
                cmd.CommandText = "GetCaseHeaderSearchTable_1";
                dat = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dat.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                dat.Dispose();
                ConnectionClose();
            }
            return dt;
        }

        public DataTable getcount()
        {
            DataTable dt = new DataTable();
            ConnectionOpen();
            cmd = new SqlCommand(); 
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getcount";
                dat = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dat.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                dat.Dispose();                
                ConnectionClose();
            }
            return dt;
        }
        //public DataTable GetCaseHeaderSearchTable(PRPSetup objprp)
        //{
        //    DataTable dt = new DataTable();
        //    ConnectionOpen();
        //    cmd = new SqlCommand();
        //    try
        //    {
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@from", objprp.from));
        //        cmd.Parameters.Add(new SqlParameter("@To", objprp.To));
        //        cmd.Parameters.Add(new SqlParameter("@Court", objprp.CourtNo));
        //        cmd.CommandText = "GetCaseHeaderSearchTable";
        //        dat = new SqlDataAdapter(cmd);

        //        //dt = new DataTable();
        //        //dat.Fill(dt);
        //    }

        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        cmd.Dispose();
        //        dat.Dispose();
        //        ConnectionClose();
        //    }
        //    return dt;
        //}


        public List<caseReport> GetCaseHeaderSearchTable(PRPSetup objprp)
        {
            List<caseReport> res = new List<caseReport>();
            ConnectionOpen();
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@from", (objprp.from==null)?"" : objprp.from));
                cmd.Parameters.Add(new SqlParameter("@To", (objprp.To == null) ? "" : objprp.To));
                cmd.Parameters.Add(new SqlParameter("@Court", objprp.CourtNo));
                cmd.CommandText = "GetCaseHeaderSearchTable";

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        res.Add(new caseReport
                        {
                            SrNo = dr["Sr. No"].ToString(),
                            Amount = dr["Amount"].ToString(),
                            CaseNo = dr["Case No"].ToString(),
                            Court = dr["Court"].ToString(),
                            LastDate = dr["Last Date"].ToString(),
                            Nature_of_case = dr["Nautre of case"].ToString(),
                            NextDate = dr["Next Date"].ToString(),
                            Petitioner = dr["Petitioner"].ToString(),
                            Respondent = dr["Respondent"].ToString(),
                            Status = dr["Status"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                dr.Close();
                cmd.Dispose();
                ConnectionClose();
            }
            return res;
        }


        public string AllinOneCase_Hearing_History(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Case_Hearing_HistoryID", objprp.Case_Hearing_HistoryID));
                cmd.Parameters.Add(new SqlParameter("@CaseId", objprp.CaseId));
                cmd.Parameters.Add(new SqlParameter("@JudgeID", objprp.JudgeId));
                cmd.Parameters.Add(new SqlParameter("@BusinesDate", objprp.BusinesDate));
                cmd.Parameters.Add(new SqlParameter("@HearingDate", objprp.HearingDate));
                cmd.Parameters.Add(new SqlParameter("@BusinessPurpose", objprp.BusinessPurpose));
                cmd.Parameters.Add(new SqlParameter("@HearingPurpose", objprp.HearingPurpose));
                cmd.Parameters.Add(new SqlParameter("@Remarks", objprp.Remarks));
                cmd.Parameters.Add(new SqlParameter("@StageofCase", objprp.StageofCase));
                cmd.Parameters.Add(new SqlParameter("@CourtNumber", objprp.CourtNumber));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@crip", ipad.GetLocalIpAddress()));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.Parameters.Add(new SqlParameter("@ResponsiblePerson", objprp.ResponsiblePerson));
                cmd.CommandText = "AllinOneCase_Hearing_History";
                str= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return str;
        }
        public List<PRPSetup> GetCase_Hearing_HistorylIst(PRPSetup objprp)
        {

            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            try
            {
               // if(objprp.TransID==null && objprp.type == null) {  new Exception("Object is Empty"); }

                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TransID", objprp.TransID));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "GetCase_Hearing_HistorylIst";
                dr = cmd.ExecuteReader(); 
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {                        
                        PRPSetup p = new PRPSetup();
                        p.ID = dr["ID"].ToString();
                        p.Case_Hearing_HistoryID = dr["Case_Hearing_HistoryID"].ToString();
                        p.CaseId = dr["CaseID"].ToString();
                        p.JudgeId = dr["JudgeID"].ToString();
                        p.BusinesDate =  (dr["BusinesDate"] != null && dr["BusinesDate"] is DateTime) ? Convert.ToDateTime(dr["BusinesDate"].ToString()).ToString("dd-MM-yyyy") :null;
                        p.RegistrationNumber = dr["RegistrationNumber"].ToString();
                        p.HearingDate =  (dr["HearingDate"] != null && dr["HearingDate"] is DateTime) ? Convert.ToDateTime(dr["HearingDate"].ToString()).ToString("dd-MM-yyyy") : null;
                        p.BusinessPurpose = dr["BusinessPurpose"].ToString();
                        p.HearingPurpose = dr["HearingPurpose"].ToString();
                        p.BP = dr["BP"].ToString();
                        p.HP = dr["HP"].ToString();
                        p.Remarks = dr["Remarks"].ToString();
                        p.StageofCase = dr["StageofCase"].ToString();
                        p.CourtNumber = dr["CourtNumber"].ToString();
                        p.StageofCaseName = dr["StageofCaseName"].ToString();
                        p.StageofCaseDesc = dr["StageofCaseDesc"].ToString();
                        p.Judge = dr["JudgeID"].ToString();
                        p.JudgeName = dr["JudgeName"].ToString();
                        p.crbyname = dr["crbyname"].ToString();
                        p.CrDate = dr["crdate1"].ToString();
                        p.RegistrationDate = (dr["RegistrationDate"] != null && dr["RegistrationDate"] is DateTime) ? Convert.ToDateTime(dr["RegistrationDate"].ToString()).ToString("dd-MM-yyyy") : null;
                        p.ResponsiblePerson = dr["ResponsiblePerson"].ToString();
                        p.name = dr["resname"].ToString();
                        p.City = dr["City"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                dr.Close();
                ConnectionClose();
            }
            return obj;
        }

        public string AllinOnePurposeMaster(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", objprp.ID));
                cmd.Parameters.Add(new SqlParameter("@Purpose", objprp.BusinessPurpose));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@crip", ipad.GetLocalIpAddress()));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "AllinOnePurposeMaster";
                str= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return str;
        }

        public string GetCaseStatusByEmpid(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CaseId", objprp.CaseId));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@AppID", (objprp.Active !=null) ? objprp.Active : "0"));
                cmd.CommandText = "GetCaseStatusByEmpid";
                str= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return str;
        }
        public List<PRPSetup> GetPurposeMasterlist(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", objprp.ID));
                cmd.CommandText = "GetPurposeMasterlist";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dr["ID1"].ToString();
                        p.CaseId = dr["ID"].ToString();
                        p.BusinessPurpose = dr["Purpose"].ToString();
                        obj.Add(p);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                dr.Close();
                ConnectionClose();
            }
            return obj;
        }

        public string AllinOneCase_Hearing_Order(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con; 
                cmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[6]; // ADOprpDL.ArrayPram = new SqlParameter[2];
                cmd.Parameters.Add(new SqlParameter("@Case_Hearing_Orderid", objprp.Case_Hearing_Orderid));
                cmd.Parameters.Add(new SqlParameter("@Case_Hearing_HistoryID", objprp.Case_Hearing_HistoryID));
                cmd.Parameters.Add(new SqlParameter("@OrderDetail", objprp.OrderDetail));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@crip", ipad.GetLocalIpAddress()));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.Parameters.Add(new SqlParameter("@fileO", objprp.fileO));
                cmd.CommandText = "AllinOneCase_Hearing_Order";

                str= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                ConnectionClose();
            }
            return str;
        }

        public QueryResponse DeleteFile(string Image)
        {
            QueryResponse res = new QueryResponse();
            string filename = System.IO.Path.GetFileName(Image);
            string filePath = HttpContext.Current.Server.MapPath("~/UploadFolder/" + filename);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                res.Response = 1;res.ResponseMsg = "Success";
            }
            else
            {
                res.Response = -1;res.ResponseMsg = "Failed in delete file";
            }
            return res;
        }

        public List<PRPSetup> GetCase_Hearing_Orderlist(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", objprp.ID));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));
                cmd.CommandText = "GetCase_Hearing_Orderlist";
                dr = cmd.ExecuteReader(); 

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PRPSetup p = new PRPSetup();
                        p.ID = dr["ID"].ToString();
                        p.BusinesDate = (dr["BusinesDate"] != null && dr["BusinesDate"] is DateTime) ? Convert.ToDateTime(dr["BusinesDate"].ToString()).ToString("dd-MM-yyyy") : null;
                        p.Case_Hearing_HistoryID = dr["Case_Hearing_HistoryID"].ToString();
                        p.OrderDetail = dr["OrderDetail"].ToString();
                        p.Case_Hearing_Orderid = dr["Case_Hearing_Orderid"].ToString();
                        p.fileO = dr["fileO"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                dr.Close();
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> GetCase_Transfer_Courts_Logs_List(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            obj = new List<PRPSetup>();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", objprp.ID));
                cmd.CommandText = "GetCase_Transfer_Courts_Logs_List";
                dr = cmd.ExecuteReader(); 
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PRPSetup p = new PRPSetup();
                        p.RegistrationNumber = dr["RegistrationNumber"].ToString();
                        p.JudgeName = dr["Fjudge"].ToString();
                        p.Judge_name = dr["Tjudge"].ToString();
                        p.BusinesDate = (dr["Transfer_Date"] != null && dr["Transfer_Date"] is DateTime) ? Convert.ToDateTime(dr["Transfer_Date"].ToString()).ToString("dd-MM-yyyy") : null;
                        p.CourtNo = dr["From_CourtNO"].ToString();
                        p.CourtNumber = dr["To_CourtNO"].ToString();
                        p.TypeID = dr["F_Court"].ToString();
                        p.TypeName = dr["To_Court"].ToString();
                        obj.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                dr.Close();
                ConnectionClose();
            }
            return obj;
        }

        public string AllinOneCaseDocuments(PRPSetup objprp)
        {
            ConnectionOpen();
            cmd = new SqlCommand();
            string str = "";
            try
            {
                cmd.Connection = con; 
                cmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[6]; // ADOprpDL.ArrayPram = new SqlParameter[2];
                cmd.Parameters.Add(new SqlParameter("@did", objprp.did));
                cmd.Parameters.Add(new SqlParameter("@CaseId", objprp.CaseId));
                cmd.Parameters.Add(new SqlParameter("@Dtype", objprp.Dtype));
                cmd.Parameters.Add(new SqlParameter("@Document", objprp.document));
                cmd.Parameters.Add(new SqlParameter("@Udate", objprp.Udate));
                cmd.Parameters.Add(new SqlParameter("@crby", objprp.Crby));
                cmd.Parameters.Add(new SqlParameter("@crip", ipad.GetLocalIpAddress()));
                cmd.Parameters.Add(new SqlParameter("@type", objprp.type));

                cmd.CommandText = "AllinOneCaseDocuments";

                str= cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                //dat.Dispose();
                ConnectionClose();
            }
            return str;
        }

        //public UploadResponse GetCaseDocumentFileName(PRPSetup prp)
        //{
        //    UploadResponse res = new UploadResponse();
        //    string str = "";
        //    string filename, fileexns, newfilenpath;
        //    string[] arr1 = new string[] { "png", "PNG", "jpg", "JPG", "jpeg", "JPEG", "pdf", "PDF", "doc", "DOC", "DOCX", "docx" };
        //    if (prp.filename != null)
        //    {
        //        string nameset = HttpContext.Current.Session["userid"].ToString();
        //        string your_String = nameset + prp.filetype;  //  ddldtype.Text.Replace(" ", "") + txtudate.Text.Replace(" ", "");
        //        string my_String = Regex.Replace(your_String, @"[^0-9a-zA-Z]+", "_");
        //        if (prp.Image  ==null)
        //        {
        //            res.Image = "No Image";
        //        }

        //        filename = System.IO.Path.GetFileNameWithoutExtension(prp.Image);
        //        fileexns = System.IO.Path.GetExtension(prp.Image);
        //        fileexns = fileexns.Replace(".", "");
        //        //int index = filename.LastIndexOf('.');
        //        //fileexns = fileexns.Substring(index + 1);
        //        if (arr1.Contains(fileexns))
        //        {
        //            str = prp.Image.Replace(System.IO.Path.GetExtension(prp.Image), "");  //   System.IO.Path.ChangeExtension(prp.filePath, null);
        //            str = str.Replace(filename, "");
        //            newfilenpath = str  + my_String + "." + fileexns;
        //            res.Response = 1;res.Image = newfilenpath; res.ResponseMsg = "Success";
        //        }
        //        else
        //        {
        //            res.Response = -1; res.Image = "No Image"; res.ResponseMsg = "Please Upload Documentation in PDF/JPG/JPEG/PNG format only.";
        //        }
        //    }
        //    else
        //    {
        //        if (prp.Image !=null)
        //        {
        //            res.Image = prp.Image;
        //        }
        //        else
        //        {
        //            res.Image = "";
        //        }
        //    }
        //    return res;
        //}

        public UploadResponse UploadCaseOrderFile(string Image, HttpPostedFileBase file)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/UploadFolder/");
            UploadResponse res = new UploadResponse();
            string filename, fileexns, fname;
            string[] arr1 = new string[] { "png", "PNG", "jpg", "JPG", "jpeg", "JPEG", "pdf", "PDF", "doc", "DOC", "DOCX", "docx" };
            try
            {
                if (file != null)
                {
                    string nameset = HttpContext.Current.Session["userid"].ToString();
                    string your_String = nameset + "order" + System.DateTime.Now.ToString().Replace(" ", "");  //  ddldtype.Text.Replace(" ", "") + txtudate.Text.Replace(" ", "");
                    string my_String = Regex.Replace(your_String, @"[^0-9a-zA-Z]+", "_");
                    if (Image == null || Image == "undefined")
                    {
                        res.Image = "No Image";
                    }
                    filename = System.IO.Path.GetFileNameWithoutExtension(file.FileName);
                    fileexns = System.IO.Path.GetExtension(file.FileName);
                    fileexns = fileexns.Replace(".", "");
                    if (arr1.Contains(fileexns))
                    {
                        file.SaveAs(path + my_String + "." + fileexns);
                        Uri uri = System.Web.HttpContext.Current.Request.Url;
                        string host = "http" + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                        fname = host + "/UploadFolder/" + my_String + "." + fileexns;
                        res.Response = 1; res.Image = fname; res.FilePath = fname; res.ResponseMsg = "Success";
                    }
                    else
                    {
                        res.Response = -1; res.Image = "No Image"; res.FilePath = ""; res.ResponseMsg = "Please Upload Documentation in PDF/JPG/JPEG/PNG format only.";
                    }
                }
                else
                {
                    if (Image != null)
                    {
                        res.Image = Image;
                        res.Response = 1; res.Image = Image; res.FilePath = Image; res.ResponseMsg = "Already Exist";
                    }
                    else
                    {
                        res.Image = "No Image";
                    }
                }
            }
            catch (Exception ex)
            {
                res.Response = -1; res.Image = "No Image"; res.FilePath = ""; res.ResponseMsg = ex.Message;
            }
            return res;
        }

        public UploadResponse UploadCaseDocumentFile(string filetype, string Image, HttpPostedFileBase file)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/UploadFolder/");
            UploadResponse res = new UploadResponse();
            string filename, fileexns,fname;
            string[] arr1 = new string[] { "png", "PNG", "jpg", "JPG", "jpeg", "JPEG", "pdf", "PDF", "doc", "DOC", "DOCX", "docx" };
            try
            {
                if (file != null)
                {
                    string nameset = HttpContext.Current.Session["userid"].ToString();
                    string your_String = nameset + filetype;  //  ddldtype.Text.Replace(" ", "") + txtudate.Text.Replace(" ", "");
                    string my_String = Regex.Replace(your_String, @"[^0-9a-zA-Z]+", "_");
                    if (Image == null || Image =="undefined")
                    {
                        res.Image = "No Image";
                    }

                    filename = System.IO.Path.GetFileNameWithoutExtension(file.FileName);
                    fileexns = System.IO.Path.GetExtension(file.FileName);
                    fileexns = fileexns.Replace(".", "");
                    if (arr1.Contains(fileexns))
                    {
                        file.SaveAs(path + my_String + "." + fileexns);
                        Uri uri = System.Web.HttpContext.Current.Request.Url;
                      //  string host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                      string host="http" + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                        fname = host + "/UploadFolder/" + my_String + "." + fileexns;
                        //str = file.FileName.Replace(System.IO.Path.GetExtension(file.FileName), "");  //   System.IO.Path.ChangeExtension(prp.filePath, null);
                        //str = str.Replace(filename, "");
                        //newfilenpath = str + my_String + "." + fileexns;
                        res.Response = 1; res.Image = fname; res.FilePath = fname; res.ResponseMsg = "Success";
                    }
                    else
                    {
                        res.Response = -1; res.Image = "No Image"; res.FilePath = ""; res.ResponseMsg = "Please Upload Documentation in PDF/JPG/JPEG/PNG format only.";
                    }
                }
                else
                {
                    if (Image != null)
                    {
                        res.Image = Image;
                        res.Response = 1; res.Image = Image; res.FilePath = Image; res.ResponseMsg = "Already Exist";
                    }
                    else
                    {
                        res.Image = "No Image";
                    }
                }
            }
            catch (Exception ex)
            {
                res.Response = -1; res.Image = "No Image"; res.FilePath = ""; res.ResponseMsg = ex.Message;
            }
            return res;
        }


        public List<PRPSetup> GetCaseTypelIst()
        {
            ConnectionOpen();
            DataSet ds = new DataSet();
            obj = new List<PRPSetup>();
            try
            {
                ds = BaseFunctions.GetData(String.Format("exec GetCaseTypelIst "), con);
                if (ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        obj.Add(new PRPSetup { CaseTypeName = dataRow["CaseTypeName"].ToString(), CaseId = dataRow["CaseId"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> GetPetitioner_Cum_RespondentlIst_P()
        {
            ConnectionOpen();
            DataSet ds = new DataSet();
            obj = new List<PRPSetup>();
            try
            {
                ds = BaseFunctions.GetData(String.Format("exec GetPetitioner_Cum_RespondentlIst '0','P'"), con);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        obj.Add(new PRPSetup { Fullname = dataRow["FullName"].ToString(), Petitioner_Cum_RespondentID = dataRow["Petitioner_Cum_RespondentID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> GetPetitioner_Cum_RespondentlIst_A()
        {
            ConnectionOpen();
            DataSet ds = new DataSet();
            obj = new List<PRPSetup>();
            try
            {
                ds = BaseFunctions.GetData(String.Format("exec GetPetitioner_Cum_RespondentlIst '0','A'"), con);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        obj.Add(new PRPSetup { Fullname = dataRow["FullName"].ToString(), Petitioner_Cum_RespondentID = dataRow["Petitioner_Cum_RespondentID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> Getresponsibleperson()
        {
            ConnectionOpen();
            DataSet ds = new DataSet();
            obj = new List<PRPSetup>();
            try
            {
                ds = BaseFunctions.GetData(String.Format("select EmpID,FullName,FullName+'-'+CAST (EmpID as varchar) as fullname2 from VPLHCM.dbo.HCM_V_CompleteEmpInfo where UnitCode=1110 and MainCadre='Staff' and EmpStatus=0 order by FullName"), con);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        obj.Add(new PRPSetup {  fullname2 = dataRow["fullname2"].ToString(), Empid = dataRow["EmpID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> GetJudgeMasterList()
        {
            ConnectionOpen();
            DataSet ds = new DataSet();
            obj = new List<PRPSetup>();
            try
            {
                ds = BaseFunctions.GetData(String.Format("exec GetJudgeMasterList"), con);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        obj.Add(new PRPSetup { JudgeName = dataRow["JudgeName"].ToString(), JudgeId = dataRow["JudgeId"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> GetUnderActmasterlIst()
        {
            ConnectionOpen();
            DataSet ds = new DataSet();
            obj = new List<PRPSetup>();
            try
            {
                ds = BaseFunctions.GetData(String.Format("exec GetUnderActmasterlIst"), con);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        obj.Add(new PRPSetup { UnderActName = dataRow["UnderActName"].ToString(), UnderActID = dataRow["UnderActID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> GetUnderSectionmasterlIst()
        {
            ConnectionOpen();
            DataSet ds = new DataSet();
            obj = new List<PRPSetup>();
            try
            {
                ds = BaseFunctions.GetData(String.Format("exec GetUnderSectionmasterlIst"), con);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        obj.Add(new PRPSetup { UnderSectionName = dataRow["UnderSectionName"].ToString(), UnderSectionID = dataRow["UnderSectionID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> GetStageofCasemasterlIst()
        {
            ConnectionOpen();
            DataSet ds = new DataSet();
            obj = new List<PRPSetup>();
            try
            {
                ds = BaseFunctions.GetData(String.Format("exec GetStageofCasemasterlIst"), con);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        obj.Add(new PRPSetup { StageofCaseName = dataRow["StageofCaseName"].ToString(), StageofCaseID = dataRow["StageofCaseID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> GetCourtCityList()
        {
            ConnectionOpen();
            DataSet ds = new DataSet();
            obj = new List<PRPSetup>();
            try
            {
                ds = BaseFunctions.GetData(String.Format("exec GetCourtCityList"), con);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        obj.Add(new PRPSetup { City = dataRow["City"].ToString(), CityID = dataRow["CityID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
            return obj;
        }

        public List<PRPSetup> case_Responsibility()
        {
            ConnectionOpen();
            DataSet ds = new DataSet();
            obj = new List<PRPSetup>();
            try
            {
                ds = BaseFunctions.GetData(String.Format("select EmpID,FullName,FullName+'-'+CAST (EmpID as varchar) as fullname2 from VPLHCM.dbo.HCM_V_CompleteEmpInfo where UnitCode=1110 and MainCadre='Staff' and EmpStatus=0 order by FullName"), con);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        obj.Add(new PRPSetup { City = dataRow["fullname2"].ToString(), CityID = dataRow["EmpID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
            return obj;
        }

    }
    public class Legalcompliances : db_connection_compliance
    {
        public Legalcompliances() : base(false, true, false) { }

        public List<ComplianceDashboard_details> Get_Dashboard_Compliances(string color)
        {
            DataSet ds = new DataSet();
            List<ComplianceDashboard_details> cl = new List<ComplianceDashboard_details>();
            ConnectionOpen();
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Comp_Dashboard_Details";
                cmd.Parameters.AddWithValue("@color", color.ToString().Trim());
                dat = new SqlDataAdapter(cmd);
                dat.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        cl.Add(new ComplianceDashboard_details
                        {
                            Alertbefore=Convert.ToInt32( drow["Alertbefore"].ToString()),
                            CID= Convert.ToDecimal(drow["CID"].ToString()),
                            color= drow["color"].ToString(),
                            CompanyID= Convert.ToInt32(drow["CompanyID"].ToString()),
                            CompanyName = drow["CompanyName"].ToString(),
                            Deadline = Convert.ToDateTime(drow["Deadline"].ToString()),
                            DeptID = Convert.ToInt32(drow["DeptID"].ToString()),
                            Deadlinea = drow["Deadlinea"].ToString(),
                            DeptName = drow["DeptName"].ToString(),
                            Frequency = Convert.ToInt32(drow["Frequency"].ToString()),
                            FrequencyName =drow["FrequencyName"].ToString(),
                            FullName = drow["FullName"].ToString(),
                            ID = Convert.ToInt32(drow["ID"].ToString()),
                            Isactive = Convert.ToInt32(drow["Isactive"].ToString()),
                            Name = drow["Name"].ToString(),
                            Regulate_For = drow["Regulate_For"].ToString(),
                            Regulate_Ref = drow["Regulate_Ref"].ToString(),
                            responsiblemep = Convert.ToDecimal( drow["responsiblemep"].ToString()),
                            UnitID = Convert.ToInt32(drow["UnitID"].ToString()),
                            UnitName = drow["UnitName"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ds.Clear();
                dat.Dispose();
                cmd.Dispose();
                con.Close();
            }
            return cl;
        }
    }
    public class CaseList
    {
        public CaseList() { }
        public int TotalCase { get; set; }
        public string CaseDesc { get; set; }
    }
    public static class BaseFunctions 
    {
        public static List<Control> lstControl = new List<Control>();
        public static string Selectbyquery(String Query, SqlConnection connection)
        {
            string stt = "";
            SqlCommand command = new SqlCommand(); ;
            connection.Open();
            try
            {
                command = new SqlCommand(Query, connection);
                stt = command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return stt;
        }

        public static void UpdatebyQuesry(String Query,SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();
            connection.Open();
            try
            {
                command = new SqlCommand(Query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }
        public static DataSet GetData(String Query, SqlConnection con)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand command = new SqlCommand();
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand(Query, con);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                adapter.Dispose();
                command.Dispose();
                //con.Close();
            }
            return ds;
        }
    }
}


