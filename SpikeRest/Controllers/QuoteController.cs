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
    public class QuoteController : ApiController
    {
        // GET: api/Quote
        public QuoteSend Get()
        {
            return new QuoteSend
            {
                Success = "12345"
            };
        }

        // GET: api/Quote/5
        public QuoteSend Get(string cstno, string emailTo,
            string userIdFrom, string invnoToQuote,
            string QuoteAmount, string QuoteNote)
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
                cmd.CommandText = "QuoteCreateInsert_Mobile";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@cstno", cstno));
                cmd.Parameters.Add(new SqlParameter("@emailTo", emailTo));
                cmd.Parameters.Add(new SqlParameter("@userIdFrom", userIdFrom));
                cmd.Parameters.Add(new SqlParameter("@invnoToQuote", invnoToQuote));
                cmd.Parameters.Add(new SqlParameter("@QuoteAmount", QuoteAmount));
                cmd.Parameters.Add(new SqlParameter("@QuoteNote", QuoteNote));

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();
                result = "true";
               
            }
           catch(Exception e2)
           {
                result = "false: "+e2.Message;
           }

            return new QuoteSend
            {
                Success = result
            };
    }

        // POST: api/Quote
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Quote/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Quote/5
        public void Delete(int id)
        {
        }
    }
}
