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
    public class MachineAdvController : ApiController
    {
        private List<MachineAdvertised> machinelist;

        // GET: api/MachineAdv
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public List<MachineAdvertised>Get(string apikey)
        {
            dsAllMachines.GetAllInventory_MobileDataTable dt = new dsAllMachines.GetAllInventory_MobileDataTable();
            SpikeRest.DAL.dsAllMachinesTableAdapters.GetAllInventory_MobileTableAdapter ta = new DAL.dsAllMachinesTableAdapters.GetAllInventory_MobileTableAdapter();

            machinelist = new List<MachineAdvertised>();

            try
            {
                dt = ta.GetData(apikey);
                int x = 0;
                while (x < dt.Rows.Count)
                {
                    MachineAdvertised i = new MachineAdvertised();
                    i.Id = dt[x].id;
                    i.Countrycode = dt[x].countryCode;
                    i.Title = dt[x].title;
                    i.Yearmfg = dt[x].year;
                    i.Manufacturer = dt[x].manufacturer;
                    i.Model = dt[x].model;
                    i.Price = dt[x].price.ToString();
                    i.Currencycode = dt[x].currencyCode;
                    i.Listingurl = dt[x].customurl;
                    i.Specstandard = dt[x].specstandard;
                    i.Specmetric = dt[x].specmetric;

                    machinelist.Add(i);
                    x++;

                }
            }
            catch(Exception e2)
            {
                machinelist.Clear();
                MachineAdvertised i = new MachineAdvertised();
                i.Id = "Error "+e2.Message;
                i.Countrycode = "";
                i.Title = "";
                i.Yearmfg = "";
                i.Manufacturer = "";
                i.Model = "";
                i.Price = "";
                i.Currencycode = "";
                i.Listingurl = "";
                i.Specstandard = "";
                i.Specmetric = "";

                machinelist.Add(i);
            }

            return machinelist;
        }

        // GET: api/MachineAdv/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MachineAdv
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineAdv/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineAdv/5
        public void Delete(int id)
        {
        }
    }
}
