using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpikeRest.Models;
using SpikeRest.DAL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SpikeRest.Controllers
{
    public class SalesOrderApprovalController : ApiController
    {
        // GET: api/Quote
        public SalesOrderApproval Get()
        {
            return new SalesOrderApproval
            {
                Success = ""
            };
        }
        // GET: api/SalesOrderApproval
        public SalesOrderApproval Get(string soaid, string approve, string userid)
        {
            string result = "true";

            bool bapprove = true;

            if (approve.ToUpper() == "false")
            {
                bapprove = false;
            }

            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            string cnToUse = "";

            foreach (ConnectionStringSettings connection in connectionStrings)
            {
                if (connection.Name == "CRMConnectionString")
                {
                    cnToUse = connection.ConnectionString;

                    break;
                }
            }

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = cnToUse;
                cn.Open();


                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SalesOrderApproval_ApproveDeny";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@id", soaid));
                cmd.Parameters.Add(new SqlParameter("@approve", bapprove));
                cmd.Parameters.Add(new SqlParameter("@userid", userid));

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();
                result = "true";

            }
            catch (Exception e2)
            {
                result = "false: " + e2.Message;
            }

            return new SalesOrderApproval
            {
                Success = "An email will be sent to the salesman and accounting informing them of your choice."
            };
        }

        

        // POST: api/SalesOrderApproval
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SalesOrderApproval/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SalesOrderApproval/5
        public void Delete(int id)
        {
        }
    }
}
