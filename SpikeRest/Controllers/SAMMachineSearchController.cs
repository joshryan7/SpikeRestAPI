using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SpikeRest.Models.SAM;
using SpikeRest.DAL.SAM;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SpikeRest.Controllers
{
    public class SAMMachineSearchController : ApiController
    {
        private List<machineSearch> machineList;
        // GET: api/SAMMachineSearch
        public machineSearch Get()
        {
            return new machineSearch
            {
                Invno = "12345",
                ItemName = "Descrition 12345",
                Year = "1999",
                ImageMain = "12345_1.jpg",
                Jvpinvno = "SAM number",
                Model = "12345 model",
                Reserved = "False"
            };
        }

        // GET: api/SAMMachineSearch/5
        public List<machineSearch> Get(string search, int vendorid)
        {
            machineList = new List<machineSearch>();

            dsMachineSearch.GetUsedInventorySearchSAM_MobileDataTable dt = new dsMachineSearch.GetUsedInventorySearchSAM_MobileDataTable();
            SpikeRest.DAL.SAM.dsMachineSearchTableAdapters.GetUsedInventorySearchSAM_MobileTableAdapter ta = new DAL.SAM.dsMachineSearchTableAdapters.GetUsedInventorySearchSAM_MobileTableAdapter();
            try
            {
                dt = ta.GetData(search, vendorid);
            }
            catch (Exception e2)
            {
                string msg = e2.Message;
            }
            int x = 0;
            while (x < dt.Rows.Count)
            {
                machineSearch i = new machineSearch();
                i.Invno = dt[x].productid;
                i.Jvpinvno = dt[x].jvpinvno.Trim();
                i.ItemName = dt[x].ItemName.Trim();
                i.ImageMain = dt[x].ItemImageName;
                i.Year = dt[x].year;
                i.Model = dt[x].model;
                i.Reserved = dt[x].reserved.ToString();

                machineList.Add(i);

                x++;
            }
            return machineList;
        }

        // POST: api/SAMMachineSearch
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SAMMachineSearch/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SAMMachineSearch/5
        public void Delete(int id)
        {
        }
    }
}
