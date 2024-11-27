using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LCM.Models
{
    public abstract class db_connection_compliance
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataAdapter dat;
        protected SqlDataReader dr;
        private SqlConnection _SqlConn { get; set; }

        public db_connection_compliance(bool hcmDb=false, bool complianceDB=false, bool legalcaseDB=false)
        {
            VPLComplianceEntities ctxCompl = new VPLComplianceEntities();
            LegalCaseEntities ctxLegal = new LegalCaseEntities();
            SqlConnection con = new SqlConnection();
            _SqlConn = con;

            VPLComplianceEntities ctx = new VPLComplianceEntities();
            if (hcmDb == true)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            }
            else if (complianceDB == true)
            {
                con.ConnectionString = ctxCompl.Database.Connection.ConnectionString;  //  ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            }
            else if(legalcaseDB==true)
            {
                con.ConnectionString = ctxLegal.Database.Connection.ConnectionString;  //  ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            }
            _SqlConn = con;
        }

        public void ConnectionOpen()
        {
            if (con == null) { con = _SqlConn; }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void ConnectionClose()
        {
            con.Close();
        }
    }
}