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
    public class MachineSoldController : ApiController
    {
        private List<Message> messagelist;
        // GET: api/MachineSold

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MachineSold/5
        public List<Message>Get(string invno)
        {
            messagelist = new List<Message>();

            // step 1 - get the machine record
            dsMachine.GetUsedInventoryItem_MobileDataTable dtInv = new dsMachine.GetUsedInventoryItem_MobileDataTable();
            SpikeRest.DAL.dsMachineTableAdapters.GetUsedInventoryItem_MobileTableAdapter taInv = new DAL.dsMachineTableAdapters.GetUsedInventoryItem_MobileTableAdapter();
            
            dtInv = taInv.GetDataByInvno(invno, -1);


            if (dtInv[0].MachinePricingType.ToUpper() == "CONSIGNMENT" ||
                dtInv[0].MachinePricingType.ToUpper() == "EXCLUSIVE")
            {
                // step 2 get the purchase cost records
                dsMachineCost.PrchLaborCostByInvnoMobileDataTable dt = new dsMachineCost.PrchLaborCostByInvnoMobileDataTable();
                SpikeRest.DAL.dsMachineCostTableAdapters.PrchLaborCostByInvnoMobileTableAdapter ta = new DAL.dsMachineCostTableAdapters.PrchLaborCostByInvnoMobileTableAdapter();

                dt = ta.GetData(invno);
                int x = 0;
                bool bFound_110_200 = false;
                while (x < dt.Rows.Count)
                {
                    if (dt[x].code.Trim() == "110" || dt[x].code.Trim() == "200")
                    {
                        bFound_110_200 = true;
                        break;
                    }
                    x++;
                }

                if (!bFound_110_200)
                {
                    Message n = new Message();
                    n.MessageText = "Warning - Machine has a consignment or exclusive status. No purchase 110 or 200 code record in the system";
                    messagelist.Add(n);
                }
                else
                {
                    Message n = new Message();
                    n.MessageText = "No warnings";
                    messagelist.Add(n);
                }
            }
            else
            {
                Message n = new Message();
                n.MessageText = "No warnings";
                messagelist.Add(n);

            }
            return messagelist ;
        }

        // GET: api/MachineSold/5
        public List<Message> Get(string invno, int userid)
        {
            messagelist = new List<Message>();
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
                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = cnToUse;
                cn.Open();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MarkItemSold";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@invno", invno));

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();


                Message n = new Message();
                n.MessageText = "Machine marked sold";
                messagelist.Add(n);
            }
            catch(Exception e2)
            {
                Message n = new Message();
                n.MessageText = "Error.  Marking sold fail.  Error message "+e2.Message;
                messagelist.Add(n);
            }
          
            return messagelist;
        }


        // note, the cstno parameter is the user chosen reason of why a machine is being
        // removed from inventory.  Each reason relates to its' own customer record

        public List<Message> Get(string invno, string cstno, int userid)
        {
            messagelist = new List<Message>();
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
                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = cnToUse;
                cn.Open();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RemoveItem";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@invno", invno));
                cmd.Parameters.Add(new SqlParameter("@cstno", cstno));
                cmd.Parameters.Add(new SqlParameter("@employeeid", userid));

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();


                Message n = new Message();
                n.MessageText = "Machine removed.";
                messagelist.Add(n);
            }
            catch (Exception e2)
            {
                Message n = new Message();
                n.MessageText = "Error.  Marking removed fail.  Error message " + e2.Message;
                messagelist.Add(n);
            }

            return messagelist;
        }

        // POST: api/MachineSold
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MachineSold/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MachineSold/5
        public void Delete(int id)
        {
        }
    }
}
