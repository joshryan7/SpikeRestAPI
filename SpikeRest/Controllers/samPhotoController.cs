using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    public class samPhotoController : ApiController
    {
        // GET: api/samPhoto
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/samPhoto/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("SamAsset/Upload/{parms}")]
        
        public string Post([FromUri] string parms)
        {
            string result2 = "Photo Uploaded";
            string vendorid = "";
            string userFullName = "";
            string asset = "";

            // vendor id  + user's full name + asset mfg + identity id from the SAM added Assets table
            // 116|Josh-Winkelmann|Asset

            int ipos = -1;
            ipos = parms.IndexOf("|");
            if (ipos > 0)
            {
                //(1)
                vendorid = parms.Substring(0, ipos);
                parms = parms.Substring(ipos + 1);

                ipos = parms.IndexOf("|");
                if (ipos > 0)
                {
                    //(2)
                    userFullName = parms.Substring(0, ipos);
                    parms = parms.Substring(ipos + 1);

                    //(3)
                    asset = parms;
                }


            }
            else
            {
                parms = "oops "+parms;
            }

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
            cmd.CommandText = "AuditInsert";


            try
            {
                //for future use to perhaps return a custom response and/or error response if an error occurs
                // see this URL https://www.c-sharpcorner.com/UploadFile/036f9e/httpresponsemessage-in-webapi166/
                HttpResponseMessage result = null;

                var httpRequest = System.Web.HttpContext.Current.Request;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@msg", parms + " Machine, file count is " + httpRequest.Files.Count.ToString()));
                cmd.Parameters.Add(new SqlParameter("@application", "iOS SAM Photos"));
                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());


                //cmd.Parameters.Clear();
                //cmd.Parameters.Add(new SqlParameter("@msg", asset + " is the asset#"));
                //cmd.Parameters.Add(new SqlParameter("@application", "iOS SAM Photos"));
                //int nrows2 = Convert.ToInt32(cmd.ExecuteNonQuery());

                System.IO.DirectoryInfo di;
                string outputPath = "";
                outputPath = @"D:\Web2\SAMPortal\" + vendorid + @"\" + userFullName + @"\" + asset;

                di = new System.IO.DirectoryInfo(outputPath);
                if (!di.Exists)
                {
                    System.IO.Directory.CreateDirectory(outputPath);
                    // di.CreateSubdirectory(@"D:\Web2\MachinePics\" + invno);
                }

                // Gets # of files in the directory di 
                int numberofFilesInFolder = di.GetFiles("*.*").Length;
                numberofFilesInFolder++;

                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var filePath = outputPath + @"\" + asset + "-" + numberofFilesInFolder.ToString() + ".jpg";

                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@msg", "Processing " + filePath + " file path"));
                        cmd.Parameters.Add(new SqlParameter("@application", "iOS Machine Photo"));
                        nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                        while (1 == 1)
                        {
                            if (System.IO.File.Exists(filePath))
                            {
                                numberofFilesInFolder++;
                                filePath = outputPath + @"\" + asset + "-" + numberofFilesInFolder.ToString() + ".jpg";
                            }
                            else
                            {
                                break;
                            }
                        }
                        postedFile.SaveAs(filePath);
                        numberofFilesInFolder++;
                    }
                }
            }
            catch (Exception e2)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@msg", "API Error POST " + e2.Message));
                cmd.Parameters.Add(new SqlParameter("@application", "iOS Machine Photo"));
                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());
                result2 = "Error: " + e2.Message;
            }

            cmd.Dispose();
            cn.Close();
            cn.Dispose();

            return result2;
        }

        // PUT: api/samPhoto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/samPhoto/5
        public void Delete(int id)
        {
        }
    }
}
