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
    public class MachineCashController : ApiController
    {
        private List<MachineCash> machinecashlist;
        // GET: api/MachineCash
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MachineCash/5
        public List<MachineCash> Get(string invno)
        {
            dsMachineCash.CashSelectByInvnoMobileDataTable dt = new dsMachineCash.CashSelectByInvnoMobileDataTable();
            SpikeRest.DAL.dsMachineCashTableAdapters.CashSelectByInvnoMobileTableAdapter ta = new DAL.dsMachineCashTableAdapters.CashSelectByInvnoMobileTableAdapter();

            machinecashlist = new List<MachineCash>();

            dt = ta.GetData(invno);
            int x = 0;
            while (x < dt.Rows.Count)
            {
                MachineCash n = new MachineCash();
                n.Id = dt[x].ID.ToString();
                n.Amount = dt[x].CHKAMT.ToString();
                n.formatted = dt[x].CHKAMT.ToString("C2");
                n.Name = dt[x].Name.Trim();
                n.Ref = dt[x].REF.Trim();
                n.Checkdate = dt[x].Checkdate;
                n.Checknumber = dt[x].CHECKNO.Trim();

                machinecashlist.Add(n);
                x++;


            }
            return machinecashlist;
        }

        // POST: api/MachineCash
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineCash/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineCash/5
        public void Delete(int id)
        {
        }
    }
}
