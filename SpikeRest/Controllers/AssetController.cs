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

        private string idOfInsert = "0";

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
        public List<asset> Get(string action, string an, string desc, string un,
            string mfg, string md, string yr)
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
                cmd.Parameters.Add(new SqlParameter("@mfg", mfg));
                cmd.Parameters.Add(new SqlParameter("@model", md));
                cmd.Parameters.Add(new SqlParameter("@year", yr));

                SqlParameter output1 = new SqlParameter("@resultValue", SqlDbType.VarChar);
                output1.Direction = ParameterDirection.Output;
                output1.Size = 100;
                cmd.Parameters.Add(output1);

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());
                result = output1.Value.ToString();

                //result = cmd.ExecuteScalar().ToString();

                if (result == "0")
                {
                    result = "fail";
                }
                else
                {
                    idOfInsert = result;
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
            i.Id = idOfInsert;   // id from identity column id on databse table SamAddedAssets
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
