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
    public class sellMachineController : ApiController
    {
        // GET: api/sellMachine
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/sellMachine/5
        public string Get(int id)
        {
            return "value";
        }
        public SellMachineInfo Get(string mfg, string model, string year, string note, string addbyid)
        {
            string result = "true";
            string recordid = "";
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
                cmd.CommandText = "App_SellMachines_Insert";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@mfg", mfg));
                cmd.Parameters.Add(new SqlParameter("@model", model));
                cmd.Parameters.Add(new SqlParameter("@year", year));
                cmd.Parameters.Add(new SqlParameter("@note", note));
                cmd.Parameters.Add(new SqlParameter("@addbyid", addbyid));

                recordid = cmd.ExecuteScalar().ToString();

                cmd.Dispose();
                cn.Close();
                cn.Dispose();
                result = "true";

            }
            catch (Exception e2)
            {
                result = "false: " + e2.Message;
            }

            return new SellMachineInfo
            {
                Id = recordid,
                Mfg = mfg,
                Model = model,
                Year = year,
                Note = note,
                Status = result,
                Addbyid = addbyid
            };
        }

        [Route("SellMachine/Upload/{invno}")]
        // POST: api/sellMachine
        public string Post([FromUri] string invno)
        {
            string result2 = "Photo Uploaded";
            string fname = "";
            int ipos = -1;
            ipos = invno.IndexOf("|");
            if (ipos > 1)
            {
                fname = invno.Substring(0, ipos);
                invno = invno.Substring(ipos + 1);
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
                cmd.Parameters.Add(new SqlParameter("@msg", invno + " Machine, file count is " + httpRequest.Files.Count.ToString()));
                cmd.Parameters.Add(new SqlParameter("@application", "iOS Machine Photo"));
                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());


                System.IO.DirectoryInfo di;
                string outputPath = "";
                if (fname.Length == 0)
                {
                    outputPath = @"D:\Web2\SellMachinery\" + invno;

                }
                else
                {
                    outputPath = @"D:\Web2\SellMachinery\" + fname + @"\" + invno;

                }

                di = new System.IO.DirectoryInfo(outputPath);
                if (!di.Exists)
                {
                    System.IO.Directory.CreateDirectory(outputPath);
                    // di.CreateSubdirectory(@"D:\Web2\MachinePics\" + invno);
                }


                int numberofFilesInFolder = di.GetFiles(invno + "*.*").Length + 1;

                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var filePath = outputPath + @"\" + invno + "-" + numberofFilesInFolder.ToString() + ".jpg";

                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@msg", "Processing " + filePath + " file path"));
                        cmd.Parameters.Add(new SqlParameter("@application", "iOS Machine Photo"));
                        nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                        while (1 == 1)
                        {
                            if (System.IO.File.Exists(filePath))
                            {
                                numberofFilesInFolder++;
                                filePath = outputPath + @"\" + invno + "-" + numberofFilesInFolder.ToString() + ".jpg";
                            }
                            else
                            {
                                break;
                            }
                        }
                        postedFile.SaveAs(filePath);
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

        // PUT: api/sellMachine/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/sellMachine/5
        public void Delete(int id)
        {
        }
    }
}
