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
    public class CustomersController : ApiController
    {

        private List<CustomersInfo> customersList;

        // GET: api/Customers
        public List<CustomersInfo>Get()
        {
            CustomersInfo c = new CustomersInfo();
            c.Cstno = "";

           customersList.Add(c);
            return customersList;

        }


        // GET: api/Customers/5
        public List<CustomersInfo>Get(string searchterm, string searchmethod)
        {

            dsCustomersInfo.CustomerSearchSimpleSearchDataTable dt = new dsCustomersInfo.CustomerSearchSimpleSearchDataTable();
            SpikeRest.DAL.dsCustomersInfoTableAdapters.CustomerSearchSimpleSearchTableAdapter ta = new DAL.dsCustomersInfoTableAdapters.CustomerSearchSimpleSearchTableAdapter();
            customersList = new List<CustomersInfo>();

            dt = ta.GetData(searchterm, searchmethod);
            int x = 0;
            while (x < dt.Rows.Count)
            {
                CustomersInfo c = new CustomersInfo();
                c.Cstno = dt[x].cstno;
                c.Custname = dt[x].custname;
                c.Forgncode = dt[x].forgncode;
                c.City = dt[x].city;
                c.State = dt[x].state;
                c.Csttype = dt[x].csttype;

                customersList.Add(c);
                x++;

            }
            return customersList;

        }

        // POST: api/Customers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customers/5
        public void Delete(int id)
        {
        }
    }
}
