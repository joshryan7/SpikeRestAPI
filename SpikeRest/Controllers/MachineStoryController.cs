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
    public class MachineStoryController : ApiController
    {
        private List<MachineStoryInfo> machinestorylist;

        // GET: api/MachineStory
        public MachineStoryInfo Get()
        {
            return new MachineStoryInfo
            {
                Column1 = ""
            };
        }

        // GET: api/MachineStory/5
        public List<MachineStoryInfo> Get(string invno, int security)
        {
            dsMachineStory.MachineStory_MobileDataTable dt = new dsMachineStory.MachineStory_MobileDataTable();
            SpikeRest.DAL.dsMachineStoryTableAdapters.MachineStory_MobileTableAdapter ta = new DAL.dsMachineStoryTableAdapters.MachineStory_MobileTableAdapter();

            dt = ta.GetData(invno, security);
            if (dt.Rows.Count > 0)
            {
                machinestorylist = new List<MachineStoryInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    MachineStoryInfo c = new MachineStoryInfo();
                    c.Column1 = dt[i].Column1;
                  

                    machinestorylist.Add(c);
                    i++;
                }
            }
            return machinestorylist;
        }

        // POST: api/MachineStory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineStory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineStory/5
        public void Delete(int id)
        {
        }
    }
}
