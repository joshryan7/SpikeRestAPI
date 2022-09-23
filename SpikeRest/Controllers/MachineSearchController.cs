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
    public class MachineSearchController : ApiController
    {
        private List<MachineInfo> machineList;

        // GET: api/MachineSearch
        public List<MachineInfo>Get()
        {
            MachineInfo i = new MachineInfo();
            i.Invno = "";
            i.Description = "";
            i.Jvpinvno = "";
            i.Year = "";
            i.ImageMain = "";
            i.Signorid = "";

            machineList.Add(i);

            return machineList;
        }

        // GET: api/MachineSearch/5
        public List<MachineInfo> Get(string searchterm, int vendorid)
        {
            dsMachine.GetUsedInventoryItem_MobileDataTable dt = new dsMachine.GetUsedInventoryItem_MobileDataTable();
            SpikeRest.DAL.dsMachineTableAdapters.GetUsedInventoryItem_MobileTableAdapter ta = new DAL.dsMachineTableAdapters.GetUsedInventoryItem_MobileTableAdapter();
            machineList = new List<MachineInfo>();

            dt = ta.GetDataSearch(searchterm, vendorid);
            int x = 0;
            while (x < dt.Rows.Count)
            {
                MachineInfo i = new MachineInfo();
                i.Invno = dt[x].invno;
                i.Description = dt[x].ItemName;
                i.Year = dt[x].year;
                i.ImageMain = dt[x].ItemImageName;
                i.Jvpinvno = dt[x].jvpinvno;
                i.SpecMetric = dt[x].specsheet;
                i.SpecSheet = dt[x].specmetric;
                i.Signorid = dt[x].signorid.ToString();

                machineList.Add(i);

                x++;

            }

            return machineList;
        }

        // POST: api/MachineSearch
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineSearch/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineSearch/5
        public void Delete(int id)
        {
        }
    }
}
