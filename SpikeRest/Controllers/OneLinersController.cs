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
    public class OneLinersController : ApiController
    {
        private List<OneLinersInfo> onelinersList;

        // GET: api/OneLiners
        public List<OneLinersInfo>Get()
        {
            OneLinersInfo i = new OneLinersInfo();
            i.Invno = "";

            onelinersList.Add(i);
            return onelinersList;

        }

        // GET: api/OneLiners/5
        public List<OneLinersInfo>Get(string searchterm, string filter, string machinetype, string mfg, string jvp, string model, string location)
        {
            // put in DAL/dt/ta

            
            dsOneLinersInfo.OneLinerSelectVersion2webDataTable dt = new dsOneLinersInfo.OneLinerSelectVersion2webDataTable();
            SpikeRest.DAL.dsOneLinersInfoTableAdapters.OneLinerSelectVersion2webTableAdapter ta = new DAL.dsOneLinersInfoTableAdapters.OneLinerSelectVersion2webTableAdapter();
            onelinersList = new List<OneLinersInfo>();

            // the Stored procedure that is called is OneLinerSelectVersion2Mobile
            dt = ta.GetData(searchterm, filter, machinetype,mfg,model,jvp,location);
            int x = 0;
            while (x < dt.Rows.Count)
            {
                OneLinersInfo i = new OneLinersInfo();
                i.Invno = dt[x].INVNO;
                i.Year = dt[x].year;
                i.Model = dt[x].MODEL;
                i.Mfg = dt[x].mfg2;
                i.Field1 = dt[x].FIELD1;
                i.Field2 = dt[x].FIELD2;
                i.Location = dt[x].location;
                i.Retail = dt[x].retail_STRING;
                i.Type = dt[x].machinepricingtype;
                i.Jvpcode = dt[x].jvpcode;
                i.City = dt[x].CITY;
                i.Label1 = dt[x].Label1.Trim();
                i.Label2 = dt[x].Label2.Trim();
                i.Machinepricingtype = dt[x].machinepricingtype;
                i.Signorid = dt[x].signorid.ToString();
                try
                {
                    i.Imagemain = "https://pmsql01.perfectionmachinery.com/pix/" + dt[x].ItemImage.Trim();
                }
                catch
                {
                    i.Imagemain = "";
                }

                i.Compareprice = i.Retail.Replace("$", "").Replace(",", "");
                i.Compareprice = i.Compareprice.PadLeft(12, '0');
                

                onelinersList.Add(i);
                x++; 

            }
            return onelinersList;
        }

        public List<OneLinersInfo> Get(string searchterm, string filter, string machinetype)
        {
            // put in DAL/dt/ta


            dsOneLinersInfo.OneLinerSelectVersion2webDataTable dt = new dsOneLinersInfo.OneLinerSelectVersion2webDataTable();
            SpikeRest.DAL.dsOneLinersInfoTableAdapters.OneLinerSelectVersion2webTableAdapter ta = new DAL.dsOneLinersInfoTableAdapters.OneLinerSelectVersion2webTableAdapter();
            onelinersList = new List<OneLinersInfo>();

            // the Stored procedure that is called is OneLinerSelectVersion2Mobile
            dt = ta.GetData(searchterm, filter, machinetype, "", "", "", "");
            int x = 0;
            while (x < dt.Rows.Count)
            {
                OneLinersInfo i = new OneLinersInfo();
                i.Invno = dt[x].INVNO;
                i.Year = dt[x].year;
                i.Model = dt[x].MODEL;
                i.Mfg = dt[x].mfg2;
                i.Field1 = dt[x].FIELD1;
                i.Field2 = dt[x].FIELD2;
                i.Location = dt[x].location;
                i.Retail = dt[x].retail_STRING;
                i.Type = dt[x].machinepricingtype;
                i.Jvpcode = dt[x].jvpcode;
                i.City = dt[x].CITY;
                i.Label1 = dt[x].Label1.Trim();
                i.Label2 = dt[x].Label2.Trim();
                i.Machinepricingtype = dt[x].machinepricingtype;
                i.Signorid = dt[x].signorid.ToString();
                try
                {
                    i.Imagemain = "https://pmsql01.perfectionmachinery.com/pix/" + dt[x].ItemImage.Trim();
                }
                catch
                {
                    i.Imagemain = "";
                }

                i.Compareprice = i.Retail.Replace("$", "").Replace(",", "");
                i.Compareprice = i.Compareprice.PadLeft(12, '0');


                onelinersList.Add(i);
                x++;

            }
            return onelinersList;
        }


        ///////////////////////////////////////////////////////////////////////////// 
        // POST: api/OneLiners
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OneLiners/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OneLiners/5
        public void Delete(int id)
        {
        }
    }
}
