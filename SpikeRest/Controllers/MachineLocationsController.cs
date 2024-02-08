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
    public class MachineLocationsController : ApiController
    {
        private List<MachineLocation> locationList = new List<MachineLocation>();
        private List<MachineInfo> machineList = new List<MachineInfo>();

        // GET: api/MachineLocations
        public MachineLocation Get()
        {
            return new MachineLocation
            {
                LocationName = "",
                LocationCode = "",
                Letter = ""

            };
        }

        // GET: api/MachineLocations/5
        // This method returns all the locations that a SAM vendor has machines at
        // Sample production URL for calling this is:  https://pmsql01.perfectionmachinery.com/PGLAPI/api/MachineLocations?vendorid=1
        public List<MachineLocation> Get(int vendorid)
        {
            dsMachineLocations.GetUsedItemLocations_MobileDataTable dt = new dsMachineLocations.GetUsedItemLocations_MobileDataTable();
            SpikeRest.DAL.dsMachineLocationsTableAdapters.GetUsedItemLocations_MobileTableAdapter ta = new DAL.dsMachineLocationsTableAdapters.GetUsedItemLocations_MobileTableAdapter();

            dt = ta.GetDataByVendorId(vendorid);
            locationList = new List<MachineLocation>();
            int x = 0;
            while (x < dt.Rows.Count)
            {
                MachineLocation i = new MachineLocation();
                i.LocationName = dt[x].locationName;
                i.LocationCode = dt[x].locationCode;
                i.Letter = dt[x].letter;
                x++;
                locationList.Add(i);
            }

            return locationList;
        }

        // This method returns all the machines that are at a location for a SAM vendor 
        // The URL for this is https://pmsql01.perfectionmachinery.com/PGLAPI/api/MachineLoations?vendorid=1&location=Decatur, IL, Caterpillar Decatur

        public List<MachineInfo> Get(int vendorid, string location)
        {
            dsMachineLocations.GetUsedInventoryForALocation_MobileDataTable dt = new dsMachineLocations.GetUsedInventoryForALocation_MobileDataTable();
            SpikeRest.DAL.dsMachineLocationsTableAdapters.GetUsedInventoryForALocation_MobileTableAdapter ta = new DAL.dsMachineLocationsTableAdapters.GetUsedInventoryForALocation_MobileTableAdapter();

            dt = ta.GetDataByLocation(location,vendorid);
            machineList = new List<MachineInfo>();
            
            int x = 0;
            while (x < dt.Rows.Count)
            {
                MachineInfo i = new MachineInfo();
                i.Invno = dt[x].productid;
                i.Description = dt[x].ItemName.Trim();
                i.Year = dt[x].year;
                i.ImageMain = dt[x].ItemImageName;
                i.Jvpinvno = dt[x].jvpinvno.Trim();
                x++;

                machineList.Add(i);
                
            }

            return machineList;
        }


        // POST: api/MachineLocations
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineLocations/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineLocations/5
        public void Delete(int id)
        {
        }
    }
}
