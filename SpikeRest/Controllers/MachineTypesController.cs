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
    public class MachineTypesController : ApiController
    {
        private List<MachineInfo> machineList;

        // GET: api/MachineTypes
        public MachineInfo Get()
        {
            return new MachineInfo
            {
                Invno = "",
                Description = "",
                //Model = "",
                Jvpinvno = "",
                Year = "",
                ImageMain = ""
            };
        }

        // GET: api/MachineTypes/5
        public List<MachineInfo> Get(string category, int vendorid)
        {
            dsMachineTypes.GetUsedInventoryForACategory_MobileDataTable dt = new dsMachineTypes.GetUsedInventoryForACategory_MobileDataTable();
            SpikeRest.DAL.dsMachineTypesTableAdapters.GetUsedInventoryForACategory_MobileTableAdapter ta = new DAL.dsMachineTypesTableAdapters.GetUsedInventoryForACategory_MobileTableAdapter();

            dt = ta.GetDataByCategoryAndVendorId(category, vendorid);
            machineList = new List<MachineInfo>();
            int x = 0;
            while (x < dt.Rows.Count)
            {
                MachineInfo i = new MachineInfo();
                i.Invno = dt[x].invno;
                i.Description = dt[x].ItemName.Trim();
                i.Year = dt[x].year;
                i.ImageMain = dt[x].ItemImageName;
                i.Jvpinvno = dt[x].jvpinvno.Trim();
                i.Reserved = dt[x].reserved.ToString();

                //i.Label1 = dt[x].label1;
                //i.Label2 = dt[x].label2;
                //i.Label3 = dt[x].label3;
                //i.Label4 = dt[x].label4;
                //i.Label5 = dt[x].label5;
                //i.Label6 = dt[x].label6;
                //i.Label7 = dt[x].label7;
                //i.Label8 = dt[x].label8;

                //i.Value1 = dt[x].value1;
                //i.Value2 = dt[x].value2;
                //i.Value3 = dt[x].value3;
                //i.Value4 = dt[x].value4;
                //i.Value5 = dt[x].value5;
                //i.Value6 = dt[x].value6;
                //i.Value7 = dt[x].value7;
                //i.Value8 = dt[x].value8;

                // i.YouTubeVideo = dt[x].youtube_embed;

                // i.HasVideo = dt[x].HasVideo;
                //i.Model = dt[x].model;



                machineList.Add(i);

                x++;

            }

            return machineList;
        }

        // POST: api/MachineTypes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineTypes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineTypes/5
        public void Delete(int id)
        {
        }
    }
}
