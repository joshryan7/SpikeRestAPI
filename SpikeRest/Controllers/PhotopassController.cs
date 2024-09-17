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
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace SpikeRest.Controllers
{
    public class PhotopassController : ApiController
    {
        // GET: api/Photopass
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Photopass/5
        public string Get(int id)
        {
            return "value";
        }

        //[Route("PhotopassMedia/Upload/{iname}")]
        //// POST: api/PhotopassMedia
        //public string Post([FromUri] string iname)
        //{
        //    string result2 = "Media Uploaded";
        //    string fname = "";
        //    int ipos = -1;
        //    ipos = iname.IndexOf("|");
        //    if (ipos > 1)
        //    {
        //        fname = iname.Substring(0, ipos);
        //        iname = iname.Substring(ipos + 1);
        //    }

        //    ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
        //    string cnToUse = "";

        //    foreach (ConnectionStringSettings connection in connectionStrings)
        //    {
        //        if (connection.Name == "CRMConnectionString")
        //        {
        //            cnToUse = connection.ConnectionString;
        //            break;
        //        }
        //    }

        //    SqlCommand cmd = new SqlCommand();
        //    SqlConnection cn = new SqlConnection();
        //    cn.ConnectionString = cnToUse;
        //    cn.Open();
        //    cmd.Connection = cn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "AuditInsert";

        //    try
        //    {
        //        var httpRequest = System.Web.HttpContext.Current.Request;
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.Add(new SqlParameter("@msg", iname + " Photopass, file count is " + httpRequest.Files.Count.ToString()));
        //        cmd.Parameters.Add(new SqlParameter("@application", "Photopass Media"));
        //        int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

        //        System.IO.DirectoryInfo di;
        //        string outputPath = "";
        //        if (fname.Length == 0)
        //        {
        //            outputPath = @"D:\Web2\Photopass\" + iname;
        //        }
        //        else
        //        {
        //            outputPath = @"D:\Web2\Photopass\" + fname + @"\" + iname;
        //        }

        //        di = new System.IO.DirectoryInfo(outputPath);
        //        if (!di.Exists)
        //        {
        //            System.IO.Directory.CreateDirectory(outputPath);
        //        }

        //        int numberofFilesInFolder = di.GetFiles(iname + "*.*").Length + 1;

        //        if (httpRequest.Files.Count > 0)
        //        {
        //            foreach (string file in httpRequest.Files)
        //            {
        //                var postedFile = httpRequest.Files[file];
        //                string extension = Path.GetExtension(postedFile.FileName).ToLower();
        //                string filePath = outputPath + @"\" + iname + "-" + numberofFilesInFolder.ToString();

        //                // Determine if the file is a photo or a video
        //                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
        //                {
        //                    filePath += ".jpg";
        //                }
        //                else if (extension == ".mp4" || extension == ".mov")
        //                {
        //                    filePath += ".mov"; // Assuming videos are in mp4 format
        //                }
        //                else
        //                {
        //                    throw new Exception("Unsupported file format");
        //                }

        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@msg", "Processing " + filePath + " file path"));
        //                cmd.Parameters.Add(new SqlParameter("@application", "iOS Photopass Media"));
        //                nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

        //                while (System.IO.File.Exists(filePath))
        //                {
        //                    numberofFilesInFolder++;
        //                    filePath = outputPath + @"\" + iname + "-" + numberofFilesInFolder.ToString() + extension;
        //                }

        //                postedFile.SaveAs(filePath);
        //            }
        //        }
        //    }
        //    catch (Exception e2)
        //    {
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.Add(new SqlParameter("@msg", "API Error POST " + e2.Message));
        //        cmd.Parameters.Add(new SqlParameter("@application", "Photopass Media"));
        //        int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());
        //        result2 = "Error: " + e2.Message;
        //    }

        //    cmd.Dispose();
        //    cn.Close();
        //    cn.Dispose();

        //    return result2;
        //}

        [Route("PhotopassMedia/Upload/{iname}")]
        // POST: api/PhotopassMedia
        public IHttpActionResult Post([FromUri] string iname)
        {
            string result2 = "Media Uploaded";
            string fname = "";
            int ipos = -1;
            ipos = iname.IndexOf("|");
            if (ipos > 1)
            {
                fname = iname.Substring(0, ipos);
                iname = iname.Substring(ipos + 1);
            }

            // Get connection string
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            string cnToUse = connectionStrings["CRMConnectionString"]?.ConnectionString;

            if (string.IsNullOrEmpty(cnToUse))
            {
                return InternalServerError(new Exception("Connection string not found"));
            }

            // File upload process
            var httpRequest = System.Web.HttpContext.Current.Request;

            try
            {
                // File saving logic
                System.IO.DirectoryInfo di;
                string outputPath = string.IsNullOrEmpty(fname)
                    ? @"D:\Web2\Photopass\" + iname
                    : @"D:\Web2\Photopass\" + fname + @"\" + iname;

                di = new System.IO.DirectoryInfo(outputPath);
                if (!di.Exists)
                {
                    System.IO.Directory.CreateDirectory(outputPath);
                }

                int numberofFilesInFolder = di.GetFiles(iname + "*.*").Length + 1;

                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        string extension = Path.GetExtension(postedFile.FileName).ToLower();
                        string filePath = outputPath + @"\" + iname + "-" + numberofFilesInFolder.ToString();

                        // Determine if the file is a photo or a video
                        if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                        {
                            filePath += ".jpg";
                        }
                        else if (extension == ".mp4" || extension == ".mov")
                        {
                            filePath += ".mov";
                        }
                        else
                        {
                            throw new Exception("Unsupported file format");
                        }

                        while (System.IO.File.Exists(filePath))
                        {
                            numberofFilesInFolder++;
                            filePath = outputPath + @"\" + iname + "-" + numberofFilesInFolder.ToString() + extension;
                        }

                        // Save file
                        postedFile.SaveAs(filePath);
                    }
                }

                // Return success immediately after file is saved
                Task.Run(() => LogAndProcessFile(httpRequest, iname, cnToUse)); // Run the background task
                return Ok(result2);
            }
            catch (Exception e2)
            {
                return InternalServerError(e2);
            }
        }

        // Background task for logging and additional processing
        private void LogAndProcessFile(HttpRequest httpRequest, string iname, string connectionString)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("AuditInsert", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@msg", iname + " Photopass, file count is " + httpRequest.Files.Count.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@application", "Photopass Media"));
                    cmd.ExecuteNonQuery();

                    foreach (string file in httpRequest.Files)
                    {
                        string filePath = httpRequest.Files[file].FileName;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@msg", "Processing " + filePath + " file path"));
                        cmd.Parameters.Add(new SqlParameter("@application", "iOS Photopass Media"));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        // PUT: api/Photopass/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Photopass/5
        public void Delete(int id)
        {
        }
    }
}
