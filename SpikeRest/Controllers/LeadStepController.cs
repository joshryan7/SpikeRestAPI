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
    public class LeadStepController : ApiController
    {
        private List<LeadStep> leadsteplist;

        // GET: api/LeadStep
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/LeadStep/5
        public List<LeadStep> Get(string leadid)
        {
            dsLead.LeadStepsSelectDataTable dt = new dsLead.LeadStepsSelectDataTable();
            SpikeRest.DAL.dsLeadTableAdapters.LeadStepsSelectTableAdapter ta = new DAL.dsLeadTableAdapters.LeadStepsSelectTableAdapter();
            leadsteplist = new List<LeadStep>();

            dt = ta.GetData(Convert.ToInt32(leadid));
            int x = 0;
            while (x < dt.Rows.Count)
            {
                LeadStep n = new LeadStep();
                n.Id = dt[x].id.ToString();
                n.Leadid = dt[x].leadid.ToString();
                n.Stepdescription = dt[x].stepdescription.Trim();
                n.Stepnumber = dt[x].stepnumber.ToString();
                n.Completed = dt[x].completed.ToString();
                n.Completeddate = dt[x].completedDate.ToShortDateString() + " " + dt[x].completedDate.ToShortTimeString();
                n.Note = dt[x].Note.Trim();

                leadsteplist.Add(n);

                x++;
            }

                return leadsteplist;
        }
        public LeadStep Get(string id, string completed)
        {
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
                bool bcompleted = false;
                if (completed.ToUpper() == "TRUE")
                {
                    bcompleted = true;
                }
                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = cnToUse;
                cn.Open();


                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LeadStepUpdate_Mobile";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id)));
                cmd.Parameters.Add(new SqlParameter("@completed", bcompleted));



                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();
                //result = "true";

            }
            catch (Exception e2)
            {
                //result = "false: " + e2.Message;
            }

            return new LeadStep
            {
                Id = id,
                Leadid = "",
                Stepdescription = "",
                Stepnumber = "",
                Completed = "",
                Completeddate = "",
                Note = ""

            };

        }
        // POST: api/LeadStep
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LeadStep/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LeadStep/5
        public void Delete(int id)
        {
        }
    }
}
