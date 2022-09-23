using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpikeRest.Models;
using SpikeRest.DAL;

namespace SpikeRest.Controllers
{
    public class DealsJVPController : ApiController
    {
        private List<DealsJvp> dealsjvplist;
        // GET: api/DealsJVP
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DealsJVP/5
        public List<DealsJvp> Get(string dealid)
        {
            dsDeals.DealsJVPSelectDataTable dt = new dsDeals.DealsJVPSelectDataTable();
            SpikeRest.DAL.dsDealsTableAdapters.DealsJVPSelectTableAdapter ta = new DAL.dsDealsTableAdapters.DealsJVPSelectTableAdapter();
            dealsjvplist = new List<DealsJvp>();


            dt = ta.GetData(Convert.ToInt32(dealid));
            if (dt.Rows.Count > 0)
            {
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    DealsJvp d = new DealsJvp();
                    d.Cstno = dt[i].cstno;
                    d.Custname = dt[i].custname;
                    d.Id = dt[i].id.ToString();
                    d.Jvpper = dt[i].jvpper.ToString();

                    dealsjvplist.Add(d);
                    i++;
                }

            }
            return dealsjvplist;
        }

        // POST: api/DealsJVP
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DealsJVP/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DealsJVP/5
        public void Delete(int id)
        {
        }
    }
}
