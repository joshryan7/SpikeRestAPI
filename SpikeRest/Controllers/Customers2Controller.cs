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
    public class Customers2Controller : ApiController
    {
        private List<CustomersInfo2> customersList2;

        // GET: api/CustomersController2
        public List<CustomersInfo2>Get()
        {
            CustomersInfo2 c = new CustomersInfo2();
            c.Cstno = "";

            customersList2.Add(c);
            return customersList2;
        }

        // GET: api/CustomersController2/5
        public List<CustomersInfo2>Get(string cstno, int userid)
        {
            dsCustomersInfo2.CustomerMasterSelectDataTable dt = new dsCustomersInfo2.CustomerMasterSelectDataTable();
            SpikeRest.DAL.dsCustomersInfo2TableAdapters.CustomerMasterSelectTableAdapter ta = new DAL.dsCustomersInfo2TableAdapters.CustomerMasterSelectTableAdapter();
            customersList2 = new List<CustomersInfo2>();

            dt = ta.GetData(cstno, userid, true);
            int x = 0;
            while (x < dt.Rows.Count)
            {
                CustomersInfo2 c = new CustomersInfo2();
                c.Cstno = dt[x].cstno;
                c.Custname = dt[x].custname;
                c.Address1 = dt[x].address1;
                if (dt[x].address2.Trim().Length == 0 || dt[x].address2 == null)
                {
                    c.Address2 = "xx";
                }
                else
                {
                    c.Address2 = dt[x].address2;
                }
                c.Countylong = dt[x].countyLong;
                c.City = dt[x].city;
                c.State_long = dt[x].state_long;
                c.Zip = dt[x].zip;
                c.Phone = dt[x].phone;
                c.Faxphone = dt[x].faxphone;
                c.Samjvp = dt[x].samjvp;
                c.Numberofnotes = dt[x].numberofnotes.ToString();

                customersList2.Add(c);
                x++;
            }
            return customersList2;
        }

        // POST: api/CustomersController2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CustomersController2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomersController2/5
        public void Delete(int id)
        {
        }
    }
}
