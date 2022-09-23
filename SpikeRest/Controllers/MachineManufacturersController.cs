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
    public class MachineManufacturersController : ApiController
    {

        private List<MachineManufacturer> manufacturerList = new List<MachineManufacturer>();
        private List<MachineInfo> machineList = new List<MachineInfo>();

        // GET: api/MachineManufacturers
        public MachineManufacturer Get()
        {
            return new MachineManufacturer
            {
                ManufacturerName = "",
                ManufacturerCode = "",
                Letter = ""
            };
        }

        // GET: api/MachineManufacturers/5
        public List<MachineManufacturer> Get(int vendorid)
        {
            dsMachineManufacturers.GetUsedItemManufacturers_MobileDataTable dt = new dsMachineManufacturers.GetUsedItemManufacturers_MobileDataTable();
            SpikeRest.DAL.dsMachineManufacturersTableAdapters.GetUsedItemManufacturers_MobileTableAdapter ta = new DAL.dsMachineManufacturersTableAdapters.GetUsedItemManufacturers_MobileTableAdapter();


            dt = ta.GetDataByVendorid(vendorid);
            manufacturerList = new List<MachineManufacturer>();
            int x = 0;
            while (x < dt.Rows.Count)
            {
                MachineManufacturer i = new MachineManufacturer();
                i.ManufacturerName = dt[x].ManufacturerName;
                i.ManufacturerCode = dt[x].mfg_short;
                i.Letter = dt[x].letter;
                x++;
                manufacturerList.Add(i);
                
            }

            return manufacturerList;
        }

        public List<MachineInfo> Get(string mfg, int vendorid)
        {
            dsMachineManufacturers.GetUsedInventoryForAManufacturer_MobileDataTable dt = new dsMachineManufacturers.GetUsedInventoryForAManufacturer_MobileDataTable();
            SpikeRest.DAL.dsMachineManufacturersTableAdapters.GetUsedInventoryForAManufacturer_MobileTableAdapter ta = new DAL.dsMachineManufacturersTableAdapters.GetUsedInventoryForAManufacturer_MobileTableAdapter();

            dt = ta.GetData(mfg, vendorid);
            machineList = new List<MachineInfo>();

            int x = 0;
            while (x < dt.Rows.Count)
            {
                MachineInfo i = new MachineInfo();               
                i.Invno = dt[x].productid;
                i.Description = dt[x].ItemName;
                i.Year = dt[x].year;
                i.ImageMain = dt[x].ItemImageName;
                i.Jvpinvno = dt[x].jvpinvno;
                x++;

                machineList.Add(i);
            }
            return machineList;
        }

        // POST: api/MachineManufacturers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineManufacturers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineManufacturers/5
        public void Delete(int id)
        {
        }
    }
}
