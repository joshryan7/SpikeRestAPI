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
    public class MachinePriceHistoryController : ApiController
    {

        private List<Pricehistory> pricehistorylist;

        // GET: api/MachinePriceHistory
        public List<Pricehistory> Get()
        {
            Pricehistory n = new Pricehistory();
            n.Changedby = "";
            pricehistorylist.Add(n);
            return pricehistorylist;
        }

        // GET: api/MachinePriceHistory/5
        public List<Pricehistory>Get(string invno)
        {
            dsPriceHistory.PriceHistorySelectByInvno_MobileDataTable dt = new dsPriceHistory.PriceHistorySelectByInvno_MobileDataTable();
            SpikeRest.DAL.dsPriceHistoryTableAdapters.PriceHistorySelectByInvno_MobileTableAdapter ta = new DAL.dsPriceHistoryTableAdapters.PriceHistorySelectByInvno_MobileTableAdapter();
            pricehistorylist = new List<Pricehistory>();

            dt = ta.GetData(invno);
            int x = 0;
            while (x < dt.Rows.Count)
            {
                Pricehistory n = new Pricehistory();

                n.Datechanged = dt[x].date_chang;
                n.Oldprice = dt[x].old_price.ToString("C0");
                n.Newprice = dt[x].new_price.ToString("C0");
                n.Changedby = dt[x].CHANGED_BY_NAME;

                pricehistorylist.Add(n);
               
                x++;
            }

            return pricehistorylist;
        }

        public Pricehistory Get(string oldprice,
            string newprice, string invno,
            string addbyid, string requote)
        {
            string result = "success mobile true";

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

            try
            {

                oldprice = oldprice.Replace("$", "");
                oldprice = oldprice.Replace(",", "");

                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = cnToUse;
                cn.Open();

                bool bRequote = true;
                if (requote.ToUpper() == "N" || requote.ToUpper()=="FALSE")
                {
                    bRequote = false;
                }

                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PriceHistoryInsert_Mobile";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@invno", invno));
                cmd.Parameters.Add(new SqlParameter("@old_price", Convert.ToInt32(oldprice)));
                cmd.Parameters.Add(new SqlParameter("@new_price", Convert.ToInt32(newprice)));
                cmd.Parameters.Add(new SqlParameter("@userid", addbyid));
                cmd.Parameters.Add(new SqlParameter("@addtopricechangebatch", bRequote));



                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();
                result = "success mobile true";

            }
            catch (Exception e2)
            {
                result = "false: " + e2.Message;
            }

            return new Pricehistory
            {
                Changedby = result,
                Oldprice = oldprice,
                Newprice = newprice,
                Datechanged = DateTime.Now.ToLongTimeString()

            };
        }

        // POST: api/MachinePriceHistory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachinePriceHistory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachinePriceHistory/5
        public void Delete(int id)
        {
        }
    }
}
