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
    public class CustomerContactsController : ApiController
    {

        private List<CustomerContactsInfo> contactsList;

        // GET: api/CustomerContacts
        public List<CustomerContactsInfo>Get()
        {
            CustomerContactsInfo c = new CustomerContactsInfo();
            c.Cstno = "";

            contactsList.Add(c);
            return contactsList;
        }

        // GET: api/CustomerContacts/5
       public List<CustomerContactsInfo>Get(string cstno)
        {

            dsCustomersInfo.Contacts4CustomerDataTable dt = new dsCustomersInfo.Contacts4CustomerDataTable();
            SpikeRest.DAL.dsCustomersInfoTableAdapters.Contacts4CustomerTableAdapter ta = new DAL.dsCustomersInfoTableAdapters.Contacts4CustomerTableAdapter();
            contactsList = new List<CustomerContactsInfo>();

            dt = ta.GetData(cstno);
            int x = 0;
            while (x < dt.Rows.Count)
            {
                CustomerContactsInfo c = new CustomerContactsInfo();
                c.Cstno = dt[x].CSTNO;
                c.Firstname = dt[x].FIRST;
                c.Lastname = dt[x].last;
                c.Email = dt[x].EMAIL;
                c.Title = dt[x].title;
                c.Phone1 = dt[x].phone1;
                c.Pkey = dt[x].PKEY.ToString();

                contactsList.Add(c);
                x++;
            }
            return contactsList;
        }

        // POST: api/CustomerContacts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CustomerContacts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomerContacts/5
        public void Delete(int id)
        {
        }
    }
}
