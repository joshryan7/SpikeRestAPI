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
    public class ShippingItemController : ApiController
    {

        private List<ShipItemInfo> shipItemList;
        // GET: api/ShippingItem
        public ShipItemInfo Get()
        {
            return new ShipItemInfo
            {
                Id = "",
                Inbno = "",
                Invno = "",
                Dest = "",
                Pickup = "",
                Shipdate = "",
                Deldate = "",
                Destcust = "",
                Destcstno = "",
                Destaddr1 = "",
                Destaddr2 = "",
                Destcity = "",
                Deststate = "",
                Destforn = "",
                Destzip = "",
                Rg_amt = "",
                Trk_amt = "",
                Trk_amt2 = "",
                Trk_amt3 = "",
                Lastupdt = "",
                Model = "",
                Mfg_short = "",
                Mfg_long = "",
                Pifshort = "",
                Piflong = "",
                Location = "",
                Serial = "",
                Jvpper = "",
                Rpt_amt = ""
            };
        }

        // GET: api/ShippingItem/5
        public List<ShipItemInfo> Get(string inbno)
        {
         
            dsShip.ShipItemSelectByShipNo_MobileDataTable dt = new dsShip.ShipItemSelectByShipNo_MobileDataTable();
            SpikeRest.DAL.dsShipTableAdapters.ShipItemSelectByShipNo_MobileTableAdapter ta = new DAL.dsShipTableAdapters.ShipItemSelectByShipNo_MobileTableAdapter();

            dt = ta.GetData(inbno);
            if (dt.Rows.Count > 0)
            {
                shipItemList = new List<ShipItemInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    ShipItemInfo a = new ShipItemInfo();
                    a.Id = dt[i].id.ToString();
                    a.Inbno = dt[i].inbno;
                    a.Invno = dt[i].invno;
                    a.Dest = dt[i].dest;
                    a.Pickup = dt[i].pickup;
                    a.Shipdate = dt[i].shipdate.ToShortDateString();
                    a.Deldate = dt[i].deldate.ToShortDateString();
                    a.Destcust = dt[i].destcust;
                    a.Destcstno = dt[i].destcstno;
                    a.Destaddr1 = dt[i].destaddr1;
                    a.Destaddr2 = dt[i].destaddr2;
                    a.Destcity = dt[i].destcity;
                    a.Deststate = dt[i].deststate;
                    a.Destforn = dt[i].destforn;
                    a.Destzip = dt[i].destzip;
                    a.Rg_amt = dt[i].rg_amt.ToString("C2");
                    a.Trk_amt = dt[i].trk_amt.ToString("C2");
                    a.Trk_amt2 = dt[i].trk_amt2.ToString("C2");
                    a.Trk_amt3 = dt[i].trk_amt3.ToString("C2");
                    a.Lastupdt = dt[i].lastupdt.ToShortDateString(); ;
                    a.Model = dt[i].model;
                    a.Mfg_short = dt[i].mfg_short;
                    a.Mfg_long = dt[i].mfg_long;
                    a.Pifshort = dt[i].pifShort;
                    a.Piflong = dt[i].pifLong;
                    a.Location = dt[i].location;
                    a.Serial = dt[i].serial;
                    a.Jvpper = dt[i].jvpper;
                    a.Rpt_amt = dt[i].rpt_amt.ToString("C2");

                    shipItemList.Add(a);
                    i++;
                }
            }
            return shipItemList;
        }

        // POST: api/ShippingItem
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShippingItem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShippingItem/5
        public void Delete(int id)
        {
        }
    }
}
