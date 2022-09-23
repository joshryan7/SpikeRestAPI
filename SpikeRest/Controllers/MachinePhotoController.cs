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
    public class MachinePhotoController : ApiController
    {
        private List<MachinePhotosInfo> machinePhotosList;

        // GET: api/MachinePhoto
        public MachinePhotosInfo Get()
        {
            return new MachinePhotosInfo
            {
                Imagename = ""
            };
        }

        // GET: api/MachinePhoto/5
        public List<MachinePhotosInfo> Get(string invno)
        {
            dsMachinePhotos.GetMachinePhotos_MobileDataTable dt = new dsMachinePhotos.GetMachinePhotos_MobileDataTable();
            SpikeRest.DAL.dsMachinePhotosTableAdapters.GetMachinePhotos_MobileTableAdapter ta = new DAL.dsMachinePhotosTableAdapters.GetMachinePhotos_MobileTableAdapter();

            dt = ta.GetData(invno);

            machinePhotosList = new List<MachinePhotosInfo>();
            int x = 0;
            while (x < dt.Rows.Count)
            {
                MachinePhotosInfo i = new MachinePhotosInfo();
                i.Imagename = dt[x].ItemImageName;
                machinePhotosList.Add(i);

                x++;
            }

            return machinePhotosList;
        }

        // POST: api/MachinePhoto
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachinePhoto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachinePhoto/5
        public void Delete(int id)
        {
        }
    }
}
