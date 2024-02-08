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
    public class ShippingController : ApiController
    {

        private List<ShipInfo> shipList;
        // GET: api/Shipping
        public ShipInfo Get()
        {
            return new ShipInfo
            {
                Id = "",
                Shipno = "",
                Rigger = "",
                Trucker = "",
                Shiptype = "",
                Invno = "",
                Shipdate = "",
                Pickup = "",
                Pickupcity = "",
                Destination = "",
                Container = "",
                Comments = "",
                Descript = ""
            };
        }

        // GET: api/Shipping/5
        public List<ShipInfo> Get(string searchkey)
        {
            dsShip.ShipSearch_MobileDataTable dt = new dsShip.ShipSearch_MobileDataTable();
            SpikeRest.DAL.dsShipTableAdapters.ShipSearch_MobileTableAdapter ta = new DAL.dsShipTableAdapters.ShipSearch_MobileTableAdapter();

            dt = ta.GetData(searchkey);
            if (dt.Rows.Count > 0)
            {
                shipList = new List<ShipInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    ShipInfo a = new ShipInfo();
                    a.Id = dt[i].id.ToString();
                    a.Shipno = dt[i].ShipNo;
                    a.Rigger = dt[i].Rigger;
                    a.Trucker = dt[i].Trucker;
                    a.Shiptype = dt[i].ShipType;
                    a.Invno = dt[i].Invno;
                    a.Shipdate = dt[i].ShipDate.ToShortDateString();
                    a.Pickup = dt[i].Pickup;
                    a.Pickupcity = dt[i].PickUpCity;
                    a.Destination = dt[i].Destination;
                    a.Container = dt[i].Container;
                    a.Comments = dt[i].Comments;
                    a.Descript = dt[i].DESCRIPT;

                    shipList.Add(a);
                    i++;
                }
            }
            return shipList;
        }

        // POST: api/Shipping
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Shipping/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shipping/5
        public void Delete(int id)
        {
        }
    }
}
