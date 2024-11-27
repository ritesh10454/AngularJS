using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCM.Models;


namespace LCM
{
    public class BL : Models.db_connection_compliance
    {
        public BL() : base(true)
        { }

        GetLocalIP ipad = new GetLocalIP();
       // SqlConnection sqlCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

        SqlCommand sqlCmd;

        List<PRPSetup> obj;
        public string hCM_login_chevkLogout(PRPSetup objprp)
        {
            ConnectionOpen();
            try
            {
                //con.Open(); 
                sqlCmd = new SqlCommand(); sqlCmd.Connection = con; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[6]; // ADOprpDL.ArrayPram = new SqlParameter[1];//ADOprp.ArrayPram = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@ip", objprp.type));

                sqlCmd.CommandText = "hCM_login_chevkLogout";

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex) { return ex.ToString(); }
            finally { sqlCmd.Dispose(); ConnectionClose(); } // con.Close(); }

        }
        PRPSetup p = new PRPSetup();
        public PRPSetup hCM_login_chevk(PRPSetup objprp)
        {
            ConnectionOpen();
            try
            {
                sqlCmd = new SqlCommand(); sqlCmd.Connection = con; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[6]; // ADOprpDL.ArrayPram = new SqlParameter[4];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@pwd", objprp.name));
                sqlCmd.Parameters.Add(new SqlParameter("@ip", objprp.type));
                sqlCmd.Parameters.Add(new SqlParameter("@ismobile", objprp.Active));
                sqlCmd.CommandText = "hCM_login_chevk";

                SqlDataReader sqlReader = sqlCmd.ExecuteReader(); obj = new List<PRPSetup>();



                if (sqlReader.HasRows)
                {

                    while (sqlReader.Read())
                    {
                        p.ID = sqlReader["id"].ToString();
                        p.name = sqlReader["msg"].ToString();
                        p.logid = sqlReader["loginid"].ToString();
                        p.Role = sqlReader["role"].ToString();
                        p.UnitCode = sqlReader["UnitCode"].ToString();
                        p.userid = sqlReader["UserName"].ToString();
                        p.DeptName = sqlReader["DeptName"].ToString();
                        p.Gender = sqlReader["Gender"].ToString();
                        p.InstName = sqlReader["A_Image"].ToString();

                    }
                }
                // ADO.ReaderClose(ADOprpDL);
                sqlReader.Close(); sqlCmd.Dispose();  // con.Close(); 
                return p;
            }
            catch (Exception ex) { return p; }
            finally { sqlCmd.Dispose(); ConnectionClose(); }

        }
        SqlDataAdapter adp;
        DataTable dtable = new DataTable();
        public DataTable Get_Mastertable(PRPSetup objprp)
        {
            ConnectionOpen();
            try
            {
                sqlCmd = new SqlCommand(); sqlCmd.Connection = con; sqlCmd.CommandType = CommandType.StoredProcedure;// ADOprpDL.ArrayPram = = new SqlParameter[6]; // ADOprpDL.ArrayPram = new SqlParameter[2];
                sqlCmd.Parameters.Add(new SqlParameter("@id", objprp.ID));
                sqlCmd.Parameters.Add(new SqlParameter("@type", objprp.type));

                sqlCmd.CommandText = "Get_Master";
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
                ConnectionClose();

            }
        }
    }
}
