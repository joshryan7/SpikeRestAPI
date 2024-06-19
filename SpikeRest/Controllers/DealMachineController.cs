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
    public class DealMachineController : ApiController
    {

        private List<DealMachine> dealmachinelist;
        dsDeals.DealMachinesSelect_MobileDataTable dt = new dsDeals.DealMachinesSelect_MobileDataTable();

        // GET: api/DealMachine
        public DealMachine Get()
        {
            return new DealMachine
            {
               
                Invno = "",
                Descript = "",
                Displayorder = "",
                Year = ""
            };

        }


        // GET: api/DealMachine/5
        public List<DealMachine> Get(string dealid, string incSold)
        {
            dealmachinelist = new List<DealMachine>();

            dsDeals.DealMachinesSelect_MobileDataTable dt = new dsDeals.DealMachinesSelect_MobileDataTable();
            SpikeRest.DAL.dsDealsTableAdapters.DealMachinesSelect_MobileTableAdapter ta = new DAL.dsDealsTableAdapters.DealMachinesSelect_MobileTableAdapter();

            dt = ta.GetData(Convert.ToInt32(dealid), Convert.ToBoolean(incSold));
            if (dt.Rows.Count > 0)
            {
                
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    DealMachine d = new DealMachine();
                   
                    d.Invno = dt[i].INVNO;
                    d.Descript = dt[i].descript;
                    d.Displayorder = dt[i].displayorder;
                    d.Year = dt[i].year;

                    dealmachinelist.Add(d);
                    i++;
                }
            }
            //else
            //{
            //    DealMachine d = new DealMachine();

            //    d.Invno = "none";
            //    d.Descript = "";
            //    d.Displayorder = "";
            //    d.Year = "";

            //    dealmachinelist.Add(d);
            //}
            return dealmachinelist;

        }

        // POST: api/DealMachine
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DealMachine/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DealMachine/5
        public void Delete(int id)
        {
        }
    }
}
