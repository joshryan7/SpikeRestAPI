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
    public class MarketingController : ApiController
    {

        private List<MarketingInfo> marketingList;

        // GET: api/Marketing
        public MarketingInfo Get()
        {
            return new MarketingInfo
            {
                Id = "",
                Category = "",
                Subcategory = "",
                Detailamount = ""
            };
        }

        // GET: api/Marketing/5
        public List<MarketingInfo> Get(string invno)
        {
            dsMarketing.marketing_MachineStats_Select_MobileDataTable dt = new dsMarketing.marketing_MachineStats_Select_MobileDataTable();
            SpikeRest.DAL.dsMarketingTableAdapters.marketing_MachineStats_Select_MobileTableAdapter ta = new DAL.dsMarketingTableAdapters.marketing_MachineStats_Select_MobileTableAdapter();

            dt = ta.GetData(invno);
            if (dt.Rows.Count > 0)
            {
                marketingList = new List<MarketingInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    MarketingInfo a = new MarketingInfo();
                    a.Id = dt[i].id.ToString();
                    a.Category = dt[i].category;
                    a.Subcategory = dt[i].subcategory;
                    a.Detailamount = dt[i].detailamount.ToString();

                    marketingList.Add(a);
                    i++;
                }
            }
            return marketingList;
        }

        // POST: api/Marketing
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Marketing/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Marketing/5
        public void Delete(int id)
        {
        }
    }
}
