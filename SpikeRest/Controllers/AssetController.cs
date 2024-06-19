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
using System.IO;

namespace SpikeRest.Controllers
{
    public class AssetController : ApiController
    {
        private List<asset> assetList;
        // GET: api/Asset
        public List<asset> Get()
        {
            assetList = new List<asset>();
            asset i = new asset();
            i.Vendorid = "-1";
            i.Username = "added by";
            i.AssetNumber = "SAM asset #";
            i.Descript = "Description";
            assetList.Add(i);
            return assetList;
        }

        // GET: api/Asset/5
        public List<asset> Get(string action, string an, string desc, string un )
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            string pglConnection = "";
            string result = "";

            try
            {
                foreach (ConnectionStringSettings connection in connectionStrings)
                {
                    if (connection.Name == "CRMConnectionString")
                    {
                        pglConnection = connection.ConnectionString;
                    }

                }

                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = pglConnection;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SAMAsset_Insert";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@assetNumber", an));
                cmd.Parameters.Add(new SqlParameter("@descript", desc));
                cmd.Parameters.Add(new SqlParameter("@username", un));

                result = cmd.ExecuteScalar().ToString();

                if (result == "1")
                {
                    result = "true";
                }
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
            catch
            {
                result = "fail";
            }

            assetList = new List<asset>();
            asset i = new asset();
            i.Vendorid = "-1";
            i.Username = un;
            i.AssetNumber = result;
            i.Descript = "";
            assetList.Add(i);

            return assetList;
            
        }

        // POST: api/Asset
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Asset/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Asset/5
        public void Delete(int id)
        {
        }
    }
}
