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
    public class MachineSettlementController : ApiController
    {
        private List<MachineSettlement> machinesettlementlist;

        // GET: api/MachineSettlement
        public List<MachineSettlement>Get()
        {
           MachineSettlement n = new MachineSettlement();
            n.Id = "-1";
            machinesettlementlist.Add(n);
            return machinesettlementlist;
        }

        // GET: api/MachineSettlement/5
        public List<MachineSettlement> Get(string invno)
        {
            dsMachineSettlement.SettlementSelectByInvnoMobileDataTable dt = new dsMachineSettlement.SettlementSelectByInvnoMobileDataTable();
            SpikeRest.DAL.dsMachineSettlementTableAdapters.SettlementSelectByInvnoMobileTableAdapter ta = new DAL.dsMachineSettlementTableAdapters.SettlementSelectByInvnoMobileTableAdapter();

            machinesettlementlist = new List<MachineSettlement>();

            dt = ta.GetData(invno);
            int x = 0;
            while (x < dt.Rows.Count)
            {
                MachineSettlement n = new MachineSettlement();
                n.Id = dt[x].id.ToString();
                n.Jvpcode = dt[x].jvpcode;
                n.Custname = dt[x].custname.Trim();
                n.Settledate = dt[x].settledate;
                n.Refno = dt[x].refno.Trim();
                n.Amount = dt[x].amount.ToString("C2");
                n.Cstno = dt[x].CSTNO;
                
                machinesettlementlist.Add(n);
                x++;
            }
            return machinesettlementlist;

        }

        // POST: api/MachineSettlement
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineSettlement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineSettlement/5
        public void Delete(int id)
        {
        }
    }
}
