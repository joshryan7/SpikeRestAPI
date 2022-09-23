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
    public class CategoryController : ApiController
    {
        private List<CategoryInfo> catList;

        // GET: api/Category
        public CategoryInfo Get()
        {
            return new CategoryInfo
            {
                Catdesc = "",
                Catno = "",
                Letter = "A"

            };
        }

        // GET: api/Category/5
        public List<CategoryInfo> Get(int vendorid)
        {
            dsCategory.GetUsedItemCategories_mobileDataTable dt = new dsCategory.GetUsedItemCategories_mobileDataTable();
            SpikeRest.DAL.dsCategoryTableAdapters.GetUsedItemCategories_mobileTableAdapter ta = new DAL.dsCategoryTableAdapters.GetUsedItemCategories_mobileTableAdapter();

            dt = ta.GetDataByVendorId(vendorid);
            if(dt.Rows.Count > 0)
            {
                catList = new List<CategoryInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    CategoryInfo ci = new CategoryInfo();
                    ci.Catno = dt[i].catno;
                    ci.Catdesc = dt[i].catdesc;
                    ci.Letter = dt[i].letter;

                    catList.Add(ci);

                    i++;

                }

                return catList;
            }
            return catList;
        }

        // POST: api/Category
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
