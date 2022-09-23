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
    public class MachineOffersController : ApiController
    {
        private List<MachineOffers> machineoffersList;

        // GET: api/MachineOffers
       public List<MachineOffers>Get()
        {
            MachineOffers o = new MachineOffers();
            o.Invno = "";

            machineoffersList.Add(o);
            return machineoffersList;
        }

        // GET: api/MachineOffers/5
        public List<MachineOffers>Get(string invno)
        {
            dsMachineInfo.OfferMasterSelectByInvnoDataTable dt = new dsMachineInfo.OfferMasterSelectByInvnoDataTable();
            SpikeRest.DAL.dsMachineInfoTableAdapters.OfferMasterSelectByInvnoTableAdapter ta = new DAL.dsMachineInfoTableAdapters.OfferMasterSelectByInvnoTableAdapter();
            machineoffersList = new List<MachineOffers>();

            dt = ta.GetData(invno);
            int x = 0;
            while(x < dt.Rows.Count)
            {
                MachineOffers o = new MachineOffers();

                o.Invno = dt[x].invno;
                o.Amount = dt[x].amount.ToString("C0");
                o.Status_long = dt[x].status_long;
                o.Offnote = dt[x].offnote;
                o.Employeelast = dt[x].employeeLast.Trim();
                o.Custname = dt[x].custname.Trim();
                o.Offdate = dt[x].offdate.ToShortDateString();
                o.Retail = Convert.ToInt32(dt[0].Retail).ToString("C0");
                machineoffersList.Add(o);
                x++;
            }
            return machineoffersList;
        }

        // POST: api/MachineOffers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineOffers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineOffers/5
        public void Delete(int id)
        {
        }
    }
}
