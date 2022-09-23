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
    public class CustomerNotesController : ApiController
    {
        private List<CustomerNotes> customernotesList;

        // GET: api/CustomerNotes
       public List<CustomerNotes>Get()
        {
            CustomerNotes n = new CustomerNotes();
            n.Cstno = "";

            customernotesList.Add(n);
            return customernotesList;
        }

        // GET: api/CustomerNotes/5
       public List<CustomerNotes>Get(string cstno)
        {
            dsCustomersInfo.NotesSelect4CustomerDataTable dt = new dsCustomersInfo.NotesSelect4CustomerDataTable();
            SpikeRest.DAL.dsCustomersInfoTableAdapters.NotesSelect4CustomerTableAdapter ta = new DAL.dsCustomersInfoTableAdapters.NotesSelect4CustomerTableAdapter();
            customernotesList = new List<CustomerNotes>();

            dt = ta.GetData(cstno);
            int x = 0;
            while(x < dt.Rows.Count)
            {
                CustomerNotes n = new CustomerNotes();

                n.Cstno = dt[x].CSTNO;
                n.Firstname = dt[x].FIRSTNAME;
                n.Lastname = dt[x].LASTNAME;
                n.Transdate = dt[x].TRANSDATE.ToShortDateString();
                n.Note = dt[x].NOTE.Trim();
                n.Transtype = dt[x].TRANSTYPE;


                customernotesList.Add(n);
                x++;
                             

            }
            return customernotesList;
        }

        public CustomerNotes Get(string cstno, string addbyid, string note)
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
                cmd.CommandText = "Note4CustomerInsert_Mobile";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@cstno", cstno));
                cmd.Parameters.Add(new SqlParameter("@addbyid", addbyid ));
                cmd.Parameters.Add(new SqlParameter("@thenote", note));
                

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

            return new CustomerNotes
            {
                Cstno = cstno,
                Note = result,
                Transdate = DateTime.Now.ToShortTimeString(),
                Firstname="",
                Lastname=""
            };
        }


        public CustomerNotes Get(string cstno, string addbyid, string emailbody, string emailto, string emailfrom, string emailsubject,
            string invno, string photos, string standard, string metric, string nonphotos)
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
                cmd.CommandText = "EmailMobileInsert";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@cstno", cstno));
                cmd.Parameters.Add(new SqlParameter("@emailFrom", emailfrom));
                cmd.Parameters.Add(new SqlParameter("@emailTo", emailto));
                cmd.Parameters.Add(new SqlParameter("@emailSubject", emailsubject));
                cmd.Parameters.Add(new SqlParameter("@emailBody", emailbody));

                cmd.Parameters.Add(new SqlParameter("@addedbyid", Convert.ToInt32(addbyid)));
                cmd.Parameters.Add(new SqlParameter("@invno", invno));
                cmd.Parameters.Add(new SqlParameter("@sendphotos", photos));
                cmd.Parameters.Add(new SqlParameter("@sendstandard", standard));
                cmd.Parameters.Add(new SqlParameter("@sendmetric", metric));
                cmd.Parameters.Add(new SqlParameter("@sendNonPhotos", nonphotos));

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

            return new CustomerNotes
            {
                Cstno = cstno,
                Note = result,
                Transdate = DateTime.Now.ToShortTimeString(),
                Firstname = "",
                Lastname = ""
            };
        }


        // POST: api/CustomerNotes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CustomerNotes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomerNotes/5
        public void Delete(int id)
        {
        }
    }
}
