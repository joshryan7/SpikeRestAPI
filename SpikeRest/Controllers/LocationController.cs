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
    public class LocationController : ApiController
    {
        private List<LocationInfo> locationlist;

        // GET: api/Location
        public LocationInfo Get()
        {
            return new LocationInfo
            {
                Id = "",
                Lcode = "",
                Lname = "",
                Address = "",
                City = "",
                State = "",
                Zip = "",
                Contact = "",
                Phone = "",
                Sqft = "",
                Comment = "",
                Deleteyn = "",
                Daysfree = "",
                glacct = "",
                Fdate = "",
                Shipterm = "",
                Termother = "",
                Prints = "",
                Manuals = "",
                Actneer = "",
                Actnnam = "",
                Buyer = "",
                Lot = "",
                Addby = "",
                Editby = "",
                Forncode = "",
                //Yesno = "",
                Addbyid = "",
                Addate = "",
                Editbyid = "",
                Editbydate = "",
                Jvpcstno = "",
                Samjvp = "",
                Responsiblesalesman = "",
                Jvpcode = "",
                Responsiblesalesmanlong = "",
                Email = ""

            };
        }

        // GET: api/Location/5
        public List<LocationInfo> Get(string searchkey)
        {
            try
            {
                dsLocation.LocationSelect_MobileDataTable dt = new dsLocation.LocationSelect_MobileDataTable();
                SpikeRest.DAL.dsLocationTableAdapters.LocationSelect_MobileTableAdapter ta = new DAL.dsLocationTableAdapters.LocationSelect_MobileTableAdapter();
                locationlist = new List<LocationInfo>();

                dt = ta.GetData(searchkey);
                if (dt.Rows.Count > 0)
                {
                   
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        LocationInfo l = new LocationInfo();
                        l.Id = dt[i].ID.ToString();
                        l.Lcode = dt[i].LCODE;
                        l.Lname = dt[i].LNAME;
                        l.Address = dt[i].ADDRESS;
                        l.City = dt[i].CITY;
                        l.State = dt[i].STATE;
                        l.Zip = dt[i].ZIP;
                        l.Contact = dt[i].CONTACT;
                        l.Phone = dt[i].PHONE;
                        l.Sqft = dt[i].SQ_FT.ToString();
                        l.Comment = dt[i].COMMENT;
                        l.Deleteyn = dt[i].DELETE_YN;
                        l.Daysfree = dt[i].DAYS_FREE.ToString();
                        l.glacct = dt[i].GLACCT;
                        l.Fdate = dt[i].FDATE.ToString();
                        l.Shipterm = dt[i].SHIPTERM;
                        l.Termother = dt[i].TERMOTHER;
                        l.Prints = dt[i].PRINTS;
                        l.Manuals = dt[i].MANUALS;
                        l.Actneer = dt[i].ACTNEER;
                        l.Actnnam = dt[i].ACTN_NAM;
                        l.Buyer = dt[i].BUYER;
                        l.Lot = dt[i].LOT;
                        l.Addby = dt[i].ADDBY;
                        l.Lcode = dt[i].LCODE;
                        l.Editby = dt[i].EDITBY;
                        l.Forncode = dt[i].FORGNCODE;
                        //l.Yesno = dt[i].YESNO.ToString();
                        l.Addbyid = dt[i].addby_id.ToString();
                        l.Addate = dt[i].add_date.ToString();
                        l.Editbyid = dt[i].editby_id.ToString();
                        l.Editbydate = dt[i].editby_date.ToString();
                        l.Jvpcstno = dt[i].jvpcstno;
                        l.Samjvp = dt[i].SAMJVP;
                        l.Responsiblesalesman = dt[i].responsibleSalesman.ToString();
                        l.Jvpcode = dt[i].jvpcode;
                        l.Responsiblesalesmanlong = dt[i].responsibleSalesmanLong;
                        l.Email = dt[i].email;

                        locationlist.Add(l);
                        i++;
                    }
                }


            }

            catch (Exception e2)
            {
                string x = e2.Message;
            }

            return locationlist;
        }

        // POST: api/Location
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Location/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Location/5
        public void Delete(int id)
        {
        }
    }
}
