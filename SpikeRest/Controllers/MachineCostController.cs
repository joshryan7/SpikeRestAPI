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
    public class MachineCostController : ApiController
    {
        private List<MachineCost> machinecostlist;

        // GET: api/MachineCost
        public List<MachineCost>Get()
        {
            MachineCost n = new MachineCost();
            n.Id = "-1";
            machinecostlist.Add(n);
            return machinecostlist;
        }

        // GET: api/MachineCost/5
        public List<MachineCost> Get(string invno)
        {
            dsMachineCost.PrchLaborCostByInvnoMobileDataTable dt = new dsMachineCost.PrchLaborCostByInvnoMobileDataTable();
            SpikeRest.DAL.dsMachineCostTableAdapters.PrchLaborCostByInvnoMobileTableAdapter ta = new DAL.dsMachineCostTableAdapters.PrchLaborCostByInvnoMobileTableAdapter();

            machinecostlist = new List<MachineCost>();

            dt = ta.GetData(invno);
            int x = 0;
            while (x < dt.Rows.Count)
            {
                MachineCost n = new MachineCost();
                n.Id = dt[x].id.ToString();
                n.Jvpinfo = dt[x].jvpinfo;
                n.Externalvendorcost = dt[x].extvendorcost.ToString("C2");
                n.Laborcost = dt[x].laborcost.ToString("C2");
                n.Code = dt[x].code;
                n.Description = dt[x].descript;
                n.Costdate = dt[x].costdate;
                n.Doctype = dt[x].doctype;
                n.Refno = dt[x].refno;
                n.Invoiced = dt[x].invoiced;
                n.Amount = dt[x].amount.ToString("C2");
                n.Vendor = dt[x].vendor;
                n.Excludepost = dt[x].exclFromPostRelieved.ToString();

                machinecostlist.Add(n);
                x++;
            }
            return machinecostlist;
        }

        // POST: api/MachineCost
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineCost/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineCost/5
        public void Delete(int id)
        {
        }
    }
}
