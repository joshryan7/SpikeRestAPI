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
    public class DealLotController : ApiController
    {

        private List<DealLot> deallotlist;
        dsDeals.DealLotCatalogSelect_MobileDataTable dt = new dsDeals.DealLotCatalogSelect_MobileDataTable();

        // GET: api/DealLot
        public DealLot Get()
        {
            return new DealLot
            {
                Lot = "",
                Id = "",
                Description = "",
                Buynowprice = "",
                Buynowtext = "",
                Sold = "",
                Dealid = ""
            };
        }

        // GET: api/DealLot/5
        public List<DealLot> Get(string dealid)
        {
            dsDeals.DealLotCatalogSelect_MobileDataTable dt = new dsDeals.DealLotCatalogSelect_MobileDataTable();
            SpikeRest.DAL.dsDealsTableAdapters.DealLotCatalogSelect_MobileTableAdapter ta = new DAL.dsDealsTableAdapters.DealLotCatalogSelect_MobileTableAdapter();

            dt = ta.GetData(Convert.ToInt32(dealid));
            if (dt.Rows.Count > 0)
            {
                deallotlist = new List<DealLot>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    DealLot d = new DealLot();

                    d.Lot = dt[i].lot;
                    d.Id = dt[i].id.ToString();
                    d.Description = dt[i].description;
                    d.Buynowprice = Convert.ToInt32(dt[i].buyItNowPrice).ToString("C0");
                    d.Buynowtext = dt[i].buyItNowPriceText;
                    d.Sold = dt[i].Sold.ToString();
                    d.Dealid = dt[i].dealid.ToString();

                    deallotlist.Add(d);
                    i++;
                }
            }
            return deallotlist;
        }
        public List<DealLot> Get(string dealid, string lot)
        {
            dsDeals.DealLotCatalogSelect_MobileDataTable dt = new dsDeals.DealLotCatalogSelect_MobileDataTable();
            SpikeRest.DAL.dsDealsTableAdapters.DealLotCatalogSelect_MobileTableAdapter ta = new DAL.dsDealsTableAdapters.DealLotCatalogSelect_MobileTableAdapter();

            dt = ta.GetDataByLot(Convert.ToInt32(dealid), lot);
            if (dt.Rows.Count > 0)
            {
                deallotlist = new List<DealLot>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    DealLot d = new DealLot();

                    d.Lot = dt[i].lot;
                    d.Id = dt[i].id.ToString();
                    d.Description = dt[i].description;
                    d.Buynowprice = Convert.ToInt32(dt[i].buyItNowPrice).ToString("C0");
                    d.Buynowtext = dt[i].buyItNowPriceText;
                    d.Sold = dt[i].Sold.ToString();
                    d.Dealid = dt[i].dealid.ToString();

                    deallotlist.Add(d);
                    i++;
                }
            }
            return deallotlist;
        }

        public DealLot Get(string dealid, string lot, string newprice, string newtext, string newsoldstatus)
        {


            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            string cnToUse = "";

            foreach (ConnectionStringSettings connection in connectionStrings)
            {
                if (connection.Name == "CRMConnectionString")
                {
                    cnToUse = connection.ConnectionString;

                    break;
                }

            }
            newprice = newprice.Replace("$", "");
            newprice = newprice.Replace(",", "");


            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cnToUse;
            cn.Open();

         

            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DealLotCatalogUpdate_Mobile";
            cmd.Parameters.Clear();

            cmd.Parameters.Add(new SqlParameter("@dealid", dealid));
            cmd.Parameters.Add(new SqlParameter("@lot", lot));
            cmd.Parameters.Add(new SqlParameter("@newprice", Convert.ToInt32(newprice)));
            cmd.Parameters.Add(new SqlParameter("@newtext", newtext));
            cmd.Parameters.Add(new SqlParameter("@newsoldstatus", (newsoldstatus == "1" || newsoldstatus.ToUpper() == "TRUE" )));

            int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

            cmd.Dispose();
            cn.Close();
            cn.Dispose();

            return new DealLot
            {
                Dealid = dealid,
                Lot = lot,
                Buynowprice = newprice,
                Buynowtext = newtext,
                Sold = newsoldstatus
            };

        }

       
    // POST: api/DealLot
    public void Post([FromBody]string value)
        {
        }

        // PUT: api/DealLot/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DealLot/5
        public void Delete(int id)
        {
        }
    }
}
