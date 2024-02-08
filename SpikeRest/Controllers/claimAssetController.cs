using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpikeRest.Models.SAM;
using SpikeRest.DAL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SpikeRest.Controllers
{
    public class claimAssetController : ApiController
    {
        private List<claimAsset> claimAssetlist;

        // GET: api/claimAsset
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/claimAsset/5
        public List<claimAsset> Get(
            string invno,
            string email,
            int vendorid,
            string phone,
            string name,
            string message,
            string companyname
            )
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
            cmd.Parameters.Clear();

            cmd.CommandText = "claimAssetInsert_Mobile";
            cmd.Parameters.Add(new SqlParameter("@invno", invno));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@vendorid", vendorid));
            cmd.Parameters.Add(new SqlParameter("@phone", phone));
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@message", message));
            cmd.Parameters.Add(new SqlParameter("@companyname", companyname));

            int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

            cmd.Dispose();
            cn.Close();
            cn.Dispose();

            claimAssetlist = new List<claimAsset>();
            claimAsset a = new claimAsset();
            a.Invno = invno;
            a.Message = "Success";
            a.Email = "";
            a.Name = "";
            a.Phone = "";
            a.Vendorid = vendorid;
            a.Companyname = "";

            claimAssetlist.Add(a);

            return claimAssetlist;
        }

        // POST: api/claimAsset
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/claimAsset/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/claimAsset/5
        public void Delete(int id)
        {
        }
    }
}
