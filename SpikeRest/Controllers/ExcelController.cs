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
    public class ExcelController : ApiController
    {
        // GET: api/Excel
        public ExcelSend Get()
        {
            return new ExcelSend
            {
                Success = "12345"
            };
        }

        // GET: api/Excel/5
        public ExcelSend Get(string tasktype, 
            int keyvalue,
            int requestedby)
        {
            string result = "true";

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
                cmd.CommandText = "BackEndRequest_Insert";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@tasktype", tasktype));
                cmd.Parameters.Add(new SqlParameter("@keyvalue", keyvalue));
                cmd.Parameters.Add(new SqlParameter("@requestedby", requestedby));

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

            return new ExcelSend
            {
                Success = result
            };
        }

        // POST: api/Excel
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Excel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Excel/5
        public void Delete(int id)
        {
        }
    }
}
