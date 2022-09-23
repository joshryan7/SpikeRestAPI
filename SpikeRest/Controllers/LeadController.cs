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
    public class LeadController : ApiController
    {

        private List<LeadInfo> leadinfolist;

        // GET: api/Lead
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Lead/5
        public List<LeadInfo> Get(string employeeid)
        {
            dsLead.LeadSelectByAssignedEmployeeDataTable dt = new dsLead.LeadSelectByAssignedEmployeeDataTable();
            SpikeRest.DAL.dsLeadTableAdapters.LeadSelectByAssignedEmployeeTableAdapter ta = new DAL.dsLeadTableAdapters.LeadSelectByAssignedEmployeeTableAdapter();
            leadinfolist = new List<LeadInfo>();

            dt = ta.GetData(Convert.ToInt32(employeeid));
            int x = 0;
            while (x < dt.Rows.Count)
            {
                LeadInfo n = new LeadInfo();
                n.Leadid = dt[x].id.ToString();
                n.Note = dt[x].note;
                n.Leadtype = dt[x].leadtype;
                n.Leadsource = dt[x].leadsource;
                n.Leaddate = dt[x].LeadDate;
                n.Cstno = dt[x].cstno;

                n.Assignedto = dt[x].assignedtoFullName;
                n.Contactcompany = dt[x].contactCompany;
                n.Contactname = dt[x].ContactName;
                n.Custname = dt[x].Custname;
                n.Contactemail = "";
                n.Regarding = dt[x].Regarding;
                n.Currentstep = dt[x].currentStep;
                n.Nextappt = dt[x].NextAppt;
                n.Completed = dt[x].completed.ToString();
                n.Hot = dt[x].hot;


                leadinfolist.Add(n);

                x++;

            }


                return leadinfolist;
        }

        public List<LeadInfo> Get(string leadid, string userid)
        {
            
            dsLead.LeadSelectById2DataTable dt = new dsLead.LeadSelectById2DataTable();
            SpikeRest.DAL.dsLeadTableAdapters.LeadSelectById2TableAdapter ta = new DAL.dsLeadTableAdapters.LeadSelectById2TableAdapter();
            leadinfolist = new List<LeadInfo>();

            dt = ta.GetData(Convert.ToInt32(leadid));
            int x = 0;
            while (x < dt.Rows.Count)
            {
                LeadInfo n = new LeadInfo();
                n.Leadid = dt[x].id.ToString();
                n.Note = dt[x].note;
                n.Leadtype = dt[x].leadtype;
                n.Leadsource = dt[x].leadsource;
                n.Leaddate = dt[x].leaddate.ToShortDateString();
                n.Cstno = dt[x].cstno;

                n.Assignedto = dt[x].assignedtoFullName;
                n.Contactcompany = dt[x].contactCompany;
                n.Contactname = dt[x].contactName.Trim(); ;
                n.Custname = dt[x].CUSTNAME.Trim();
                n.Contactemail = dt[x].contactEmail.Trim();
                n.Regarding = dt[x].leadRegardMany;
                n.Currentstep = "";
                n.Nextappt = "";
                n.Completed = dt[x].completed.ToString();
                n.Hot = "";


                leadinfolist.Add(n);

                x++;

            }


            return leadinfolist;
        }

        // POST: api/Lead
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Lead/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Lead/5
        public void Delete(int id)
        {
        }
    }
}
