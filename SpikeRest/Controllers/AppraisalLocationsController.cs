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
    public class AppraisalLocationsController : ApiController
    {
        private List<AppraisalLocationsInfo> appraisallocationslist;

        // GET: api/Appraisal
        public AppraisalLocationsInfo Get()
        {
            return new AppraisalLocationsInfo
            {
                Id = "",
                Projectid = "",
                Locaname = "",
                Forgncode = "",
                Address1 = "",
                Address2 = "",
                City = "",
                State = "",
                Zip = "",
                Notes = "",
                Contactname = "",
                Contactemail = ""
   
            };
        }

        // GET: api/AppraisalLocations/5
        public List<AppraisalLocationsInfo> Get(int projectid)
        {
            dsAppraisalLocations.AppraisalLocations_MobileDataTable dt = new dsAppraisalLocations.AppraisalLocations_MobileDataTable();
            SpikeRest.DAL.dsAppraisalLocationsTableAdapters.AppraisalLocations_MobileTableAdapter ta = new DAL.dsAppraisalLocationsTableAdapters.AppraisalLocations_MobileTableAdapter();

            dt = ta.GetData(projectid);
            if (dt.Rows.Count > 0)
            {
                appraisallocationslist = new List<AppraisalLocationsInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    AppraisalLocationsInfo a = new AppraisalLocationsInfo();
                    a.Id = dt[i].id.ToString();
                    a.Projectid = dt[i].projectid.ToString();
                    a.Locaname = dt[i].locname;
                    a.Forgncode = dt[i].forgncode;
                    a.Address1 = dt[i].address1;
                    a.Address2 = dt[i].address2;
                    a.City = dt[i].city;
                    a.State = dt[i].state;
                    a.Zip = dt[i].zip;
                    a.Notes = dt[i].notes;
                    a.Contactname = dt[i].contactname;
                    a.Contactemail = dt[i].contactemail;
                    appraisallocationslist.Add(a);
                    i++;
                }
            }
            return appraisallocationslist;
        }

        // POST: api/AppraisalLocations
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AppraisalLocations/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AppraisalLocations/5
        public void Delete(int id)
        {
        }
    }
}
