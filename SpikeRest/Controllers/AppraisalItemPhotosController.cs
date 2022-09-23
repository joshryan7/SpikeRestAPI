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
    public class AppraisalItemPhotosController : ApiController
    {
        private List<AppraisalItemPhotosInfo> appraisalItemPhotosList;
        // GET: api/AppraisalItemPhotos
        public AppraisalItemPhotosInfo Get()
        {
            return new AppraisalItemPhotosInfo
            {
                Imagename = ""
            };
        }

        // GET: api/AppraisalItemPhotos/5
        public List<AppraisalItemPhotosInfo> Get(string itemid)
        {
            dsAppraisalItemPhotos.GetAppraisalItemPhotos_MobileDataTable dt = new dsAppraisalItemPhotos.GetAppraisalItemPhotos_MobileDataTable();
            SpikeRest.DAL.dsAppraisalItemPhotosTableAdapters.GetAppraisalItemPhotos_MobileTableAdapter ta = new DAL.dsAppraisalItemPhotosTableAdapters.GetAppraisalItemPhotos_MobileTableAdapter();

            dt = ta.GetData(itemid);

            appraisalItemPhotosList = new List<AppraisalItemPhotosInfo>();
            int x = 0;
            while (x < dt.Rows.Count)
            {
                AppraisalItemPhotosInfo i = new AppraisalItemPhotosInfo();
                i.Imagename = dt[x].ItemImageName;
                appraisalItemPhotosList.Add(i);

                x++;
            }

            return appraisalItemPhotosList;
        }

        // POST: api/AppraisalItemPhotos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AppraisalItemPhotos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AppraisalItemPhotos/5
        public void Delete(int id)
        {
        }
    }
}
