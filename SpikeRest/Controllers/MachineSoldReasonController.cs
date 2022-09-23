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
    public class MachineSoldReasonController : ApiController
    {
        private List<MachineSoldReason> machinesoldreasonlist;
        // GET: api/MachineSoldReason
        public List<MachineSoldReason> Get()
        {
            
            dsMachineSoldReasons.InventorySoldReasons_SelectDataTable dt = new dsMachineSoldReasons.InventorySoldReasons_SelectDataTable();
            SpikeRest.DAL.dsMachineSoldReasonsTableAdapters.InventorySoldReasons_SelectTableAdapter ta = new DAL.dsMachineSoldReasonsTableAdapters.InventorySoldReasons_SelectTableAdapter();

            machinesoldreasonlist = new List<MachineSoldReason>();

            dt = ta.GetData();
            int x = 0;
            while (x < dt.Rows.Count)
            {
                MachineSoldReason n = new MachineSoldReason();
                n.Reason = dt[x].reason.Trim();
                n.Cstno = dt[x].cstno;
                
                machinesoldreasonlist.Add(n);
                x++;


            }
            return machinesoldreasonlist;
        }

        // GET: api/MachineSoldReason/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MachineSoldReason
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineSoldReason/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineSoldReason/5
        public void Delete(int id)
        {
        }
    }
}
