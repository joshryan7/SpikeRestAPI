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
    public class RecentsController : ApiController
    {
        private List<RecentsInfo> recentslist;
        // GET: api/Recents
       public RecentsInfo Get()
        {
            return new RecentsInfo
            {
                Recordtype = "",
                Recordkey = "",
                Displaydesc = ""
            };
        }
              
        // GET: api/Recents/5
        public List<RecentsInfo> Get(int userid, int number)
        {
            dsRecents.RECENTSELECT_LASTN_mobileDataTable dt = new dsRecents.RECENTSELECT_LASTN_mobileDataTable();
            SpikeRest.DAL.dsRecentsTableAdapters.RECENTSELECT_LASTN_mobileTableAdapter ta = new DAL.dsRecentsTableAdapters.RECENTSELECT_LASTN_mobileTableAdapter();

            dt = ta.GetData(userid, number);
            if(dt.Rows.Count > 0)
            {
                recentslist = new List<RecentsInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    RecentsInfo r = new RecentsInfo();
                    r.Recordtype = dt[i].RecordType.Trim();
                    r.Recordkey = dt[i].RECORDKEY;
                    r.Displaydesc = dt[i].displaydesc;

                    recentslist.Add(r);
                    i++;
                }
            }
            return recentslist;
        }

        // POST: api/Recents
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Recents/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Recents/5
        public void Delete(int id)
        {
        }
    }
}
