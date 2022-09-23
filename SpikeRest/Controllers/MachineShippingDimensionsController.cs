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
    public class MachineShippingDimensionsController : ApiController
    {

        private List<MachineShippingDimensions> shippingdimensionslist;

        // GET: api/MachineShippingDimensions
        public List<MachineShippingDimensions> Get()
        {
            MachineShippingDimensions n = new MachineShippingDimensions();
            n.Id = "-1";
            shippingdimensionslist.Add(n);
            return shippingdimensionslist;
        }

        // GET: api/MachineShippingDimensions/5
        public List<MachineShippingDimensions> Get(string invno)
        {
            
            dsMachineShippingDimensions.PerfecShipDimSelect_MobileDataTable dt = new dsMachineShippingDimensions.PerfecShipDimSelect_MobileDataTable();
            SpikeRest.DAL.dsMachineShippingDimensionsTableAdapters.PerfecShipDimSelect_MobileTableAdapter ta = new DAL.dsMachineShippingDimensionsTableAdapters.PerfecShipDimSelect_MobileTableAdapter();
            shippingdimensionslist = new List<MachineShippingDimensions>();

            dt = ta.GetData(invno);
            int x = 0;
            while (x < dt.Rows.Count)
            {
                MachineShippingDimensions n = new MachineShippingDimensions();
                n.Id = dt[x].id.ToString();
                n.Description = dt[x].name;
                n.Length = dt[x].length;
                n.Width = dt[x].width;
                n.Height = dt[x].height;
                n.Weight = dt[x].weight;
                n.Note = dt[x].note;
                n.Sqft = dt[x].sqft.ToString();

                shippingdimensionslist.Add(n);
               
                x++;
            }

            return shippingdimensionslist;
        }
        // POST: api/MachineShippingDimensions
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineShippingDimensions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineShippingDimensions/5
        public void Delete(int id)
        {
        }
    }
}
