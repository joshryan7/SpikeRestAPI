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
    public class WantedController : ApiController
    {
        private List<WantedInfo> wantedlist;

        // GET: api/Contact
        public WantedInfo Get()
        {
            return new WantedInfo
            {
                Howmatched = "",
                Wanted_mfg_short = "",
                Wanted_model = "",
                Wanted_category = "",
                Wanted_field1 = "",
                Match_invno = "",
                Match_mfg_short = "",
                Match_model = "",
                Match_field1 = ""

            };
        }

        // GET: api/Contact/5
        public List<WantedInfo> Get(int machineno, string mfg_short, string model, string catno, string field1)
        {
            dsWanted.Wanted_CheckSingleMachine_mobileDataTable dt = new dsWanted.Wanted_CheckSingleMachine_mobileDataTable();
            SpikeRest.DAL.dsWantedTableAdapters.Wanted_CheckSingleMachine_mobileTableAdapter ta = new DAL.dsWantedTableAdapters.Wanted_CheckSingleMachine_mobileTableAdapter();

            dt = ta.GetData(machineno, mfg_short, model, catno, field1);
            if (dt.Rows.Count > 0)
            {
                wantedlist = new List<WantedInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    WantedInfo c = new WantedInfo();
                    c.Howmatched = dt[i].HowMatched;
                    c.Wanted_mfg_short = dt[i].wanted_mfg_short;
                    c.Wanted_model = dt[i].wanted_model;
                    c.Wanted_category = dt[i].wanted_category;
                    c.Wanted_field1 = dt[i].wanted_field1;
                    c.Match_invno = dt[i].match_invno;
                    c.Match_mfg_short = dt[i].match_mfg_short;
                    c.Match_model = dt[i].match_model;
                    c.Match_field1 = dt[i].match_FIELD1;


                    wantedlist.Add(c);
                    i++;
                }
            }
            return wantedlist;
        }

        // POST: api/Contact
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Contact/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Contact/5
        public void Delete(int id)
        {
        }
    }
}
