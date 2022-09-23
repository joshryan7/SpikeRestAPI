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
    public class MTPController : ApiController
    {
        private List<MTPinfo> mtplist;

        // GET: api/MTP
        public List<MTPinfo> Get()
        {
            dsMTP.MachinePricingType_SelectDataTable dt = new dsMTP.MachinePricingType_SelectDataTable();
            SpikeRest.DAL.dsMTPTableAdapters.MachinePricingType_SelectTableAdapter ta = new DAL.dsMTPTableAdapters.MachinePricingType_SelectTableAdapter();

            dt = ta.GetData();
            if (dt.Rows.Count > 0)
            {
                mtplist = new List<MTPinfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    MTPinfo t = new MTPinfo();
                    t.Id = dt[i].id.ToString();
                    t.Machinetype = dt[i].MachineType;
                    t.Mtorder = dt[i].MtOrder.ToString();
                   
                    mtplist.Add(t);
                    i++;
                }
            }
            return mtplist;
        }

        // GET: api/MTP/5
        public MTPinfo Get(string machinetype, string mtorder)
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



            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cnToUse;
            cn.Open();



            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "MachinePricingType_Insert";
            cmd.Parameters.Clear();

            cmd.Parameters.Add(new SqlParameter("@machinetype", machinetype));
            cmd.Parameters.Add(new SqlParameter("@mtorder", mtorder));
            

            int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

            cmd.Dispose();
            cn.Close();
            cn.Dispose();

            return new MTPinfo
            {
                Id = "",
               Machinetype = "",
               Mtorder = ""
            };
        }

        // POST: api/MTP
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MTP/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MTP/5
        public void Delete(int id)
        {
        }
    }
}
