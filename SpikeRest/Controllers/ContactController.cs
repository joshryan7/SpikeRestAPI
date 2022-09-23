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
    public class ContactController : ApiController
    {
        private List<ContactInfo> contactlist;

        // GET: api/Contact
        public ContactInfo Get()
        {
            return new ContactInfo
            {
                Pkey = "",
                Cstno = "",
                Last = "",
                First = "",
                Phone1 = "",
                Title = "",
                Email =""
                
            };
        }

        // GET: api/Contact/5
        public List<ContactInfo> Get(int contactid)
        {
            dsContact.ContactSelectByContactIdMobileDataTable dt = new dsContact.ContactSelectByContactIdMobileDataTable();
            SpikeRest.DAL.dsContactTableAdapters.ContactSelectByContactIdMobileTableAdapter ta = new DAL.dsContactTableAdapters.ContactSelectByContactIdMobileTableAdapter();

            dt = ta.GetData(contactid);
            if (dt.Rows.Count > 0)
            {
                contactlist = new List<ContactInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    ContactInfo c = new ContactInfo();
                    c.Pkey = dt[i].PKEY.ToString();
                    c.Cstno = dt[i].CSTNO;
                    c.Last = dt[i].LAST;
                    c.First = dt[i].FIRST;
                    c.Phone1 = dt[i].PHONE1;
                    c.Title = dt[i].TITLE;
                    c.Email = dt[i].EMAIL;

                    contactlist.Add(c);
                    i++;
                }
            }
            return contactlist;
        }

        // POST: api/Contact
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contact/5
        public void Delete(int id)
        {
        }
    }
}
