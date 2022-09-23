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
using System.Web.Http.Controllers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Metadata;
using System.Drawing;
using System.Web;

namespace SpikeRest.Controllers
{
    public class AppraisalController : ApiController
    {
        private List<AppraisalInfo> appraisallist;

        // GET: api/Appraisal
        public AppraisalInfo Get()
        {
            return new AppraisalInfo
            {
                Id = "",
                Pname = "",
                Companycstno = "",
                Clientcstno = "",
                Contactname = "",
                Paddress1 = "",
                Paddress2 = "",
                Pcity = "",
                Pstate = "",
                Pzip = "",
                Contactphone = "",
                Contactemail = "",
                Pforgncode = "",
                Pdateadded = "",
                Pstartdate = "",
                Value1 = "",
                Value2 = "",
                Ptype = "",
                Intendeduse = "",
                Pnotes = "",
                Custname = "",
                Clientname = "",
                Recordtype = "",
                Itemid = "",
                Mfg = "",
                Model = "",
                Year = "",
                Serial = "",
                Appraisddate = ""


            };
        }

        //public AppraisalInfo Get(int userid, string pic, string itemid)
        //{
        //    TextWriter TW = new StreamWriter(@"D:\web2\ApprPics\test"+userid.ToString()+"-"+itemid+".jpg");
        //    //TextWriter TW = new StreamWriter(@"C:\Temp\" + userid.ToString() + "-" + itemid + ".jpg");
        //    TW.Write(pic);
        //    TW.Close();
        //    TW.Dispose();

        //    return new AppraisalInfo
        //    {
        //        Id = "",
        //        Pname = "Picture file written",
        //        Companycstno = "",
        //        Clientcstno = "",
        //        Contactname = "",
        //        Paddress1 = "",
        //        Paddress2 = "",
        //        Pcity = "",
        //        Pstate = "",
        //        Pzip = "",
        //        Contactphone = "",
        //        Contactemail = "",
        //        Pforgncode = "",
        //        Pdateadded = "",
        //        Pstartdate = "",
        //        Value1 = "",
        //        Value2 = "",
        //        Ptype = "",
        //        Intendeduse = "",
        //        Pnotes = "",
        //        Custname = "",
        //        Clientname = ""
        //    };
        //}

            // GET: api/Appraisal/5
            public List<AppraisalInfo> Get(int userid, string search, string searchtype)
        {
            dsAppraisals.AppraisalSelect_MobileDataTable dt = new dsAppraisals.AppraisalSelect_MobileDataTable();
            SpikeRest.DAL.dsAppraisalsTableAdapters.AppraisalSelect_MobileTableAdapter ta = new DAL.dsAppraisalsTableAdapters.AppraisalSelect_MobileTableAdapter();
            appraisallist = new List<AppraisalInfo>();
            dt = ta.GetData(userid, search, searchtype);
            if (dt.Rows.Count > 0)
            {
               
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    AppraisalInfo a = new AppraisalInfo();
                    a.Id = dt[i].id.ToString();
                    a.Pname = dt[i].pname;
                    a.Companycstno = dt[i].companyCstno;
                    a.Clientcstno = dt[i].clientCstno;
                    a.Contactname = dt[i].contactName;
                    a.Paddress1 = dt[i].paddress1;
                    a.Paddress2 = dt[i].paddress2;
                    a.Pcity = dt[i].pcity;
                    a.Pstate = dt[i].pstate;
                    a.Pzip = dt[i].pzip;
                    a.Contactphone = dt[i].contactPhone;
                    a.Contactemail = dt[i].contactEmail;
                    a.Pforgncode = dt[i].pforgncode;
                    a.Pdateadded = dt[i].paddedDate.ToShortDateString();
                    a.Pstartdate = dt[i].pstartDate.ToShortDateString();
                    a.Value1 = dt[i].value1;
                    a.Value2 = dt[i].value2;
                    a.Ptype = dt[i].ptype;
                    a.Intendeduse = dt[i].intendedUse;
                    a.Pnotes = dt[i].pnotes;
                    a.Custname = dt[i].custname;
                    a.Clientname = dt[i].clientname;
                    a.Recordtype = dt[i].recordtype;
                    a.Itemid = dt[i].itemid;
                    a.Mfg = dt[i].mfg;
                    a.Model = dt[i].model;
                    a.Year = dt[i].year;
                    a.Serial = dt[i].serial;
                    a.Appraisddate = dt[i].appraiseddate;
                    appraisallist.Add(a);
                    i++;
                }
            }
            return appraisallist;
        }

        public AppraisalInfo Get(string tasktype, int projectid, int userid)
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
            cmd.CommandText = "BackEndRequest_Insert";
            cmd.Parameters.Clear();

            cmd.Parameters.Add(new SqlParameter("@tasktype", "AppraisalExcel"));
            cmd.Parameters.Add(new SqlParameter("@keyvalue", projectid));
            cmd.Parameters.Add(new SqlParameter("@requestedBy", userid));


            int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

            cmd.Dispose();
            cn.Close();
            cn.Dispose();
            return new AppraisalInfo
            {
                Id = "",
                Pname = "",
                Companycstno = "",
                Clientcstno = "",
                Contactname = "",
                Paddress1 = "",
                Paddress2 = "",
                Pcity = "",
                Pstate = "",
                Pzip = "",
                Contactphone = "",
                Contactemail = "",
                Pforgncode = "",
                Pdateadded = "",
                Pstartdate = "",
                Value1 = "",
                Value2 = "",
                Ptype = "",
                Intendeduse = "",
                Pnotes = "",
                Custname = "",
                Clientname = "",
                Recordtype = "",
                Itemid = "",


            };
        }

        public AppraisalInfo Get(string nameTb, string contactnameTb, string addressTb, string address2Tb, string cityTb, string statecb, string zipTb, string contactphoneTb, string contactemailTb, string countrycb, string ProjectStartDateTB, string valuetype1, string valuetype2, string projecttypeCb, string intendeduseTb, string notesRtb, int addbyid)
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
            cmd.CommandText = "AppraisalProjectInsert";
            cmd.Parameters.Clear();

            cmd.Parameters.Add(new SqlParameter("@pname", nameTb));
            cmd.Parameters.Add(new SqlParameter("@companyCstno", ""));
            cmd.Parameters.Add(new SqlParameter("@clientcstno", ""));
            cmd.Parameters.Add(new SqlParameter("@contactname", contactnameTb));
            cmd.Parameters.Add(new SqlParameter("@paddress1", addressTb));
            cmd.Parameters.Add(new SqlParameter("@paddress2", address2Tb));
            cmd.Parameters.Add(new SqlParameter("@pcity", cityTb));
            cmd.Parameters.Add(new SqlParameter("@pstate", statecb));
            cmd.Parameters.Add(new SqlParameter("@pzip", zipTb));
            cmd.Parameters.Add(new SqlParameter("@contactphone", contactphoneTb));
            cmd.Parameters.Add(new SqlParameter("@contactemail", contactemailTb));
            cmd.Parameters.Add(new SqlParameter("@pforgncode", countrycb));

            cmd.Parameters.Add(new SqlParameter("@pstartdate", ProjectStartDateTB));
            cmd.Parameters.Add(new SqlParameter("@value1", valuetype1));
            cmd.Parameters.Add(new SqlParameter("@value2", valuetype2));
            cmd.Parameters.Add(new SqlParameter("@ptype", projecttypeCb));
            cmd.Parameters.Add(new SqlParameter("@intendeduse", intendeduseTb));
            cmd.Parameters.Add(new SqlParameter("@pnotes", notesRtb));
            cmd.Parameters.Add(new SqlParameter("@addbyid", addbyid));



            int newProjectId = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            try
            {
                System.IO.Directory.CreateDirectory(@"D:\ApprPics\Project" + newProjectId.ToString());
            }
            catch
            { }

            cmd.Dispose();
            cn.Close();
            cn.Dispose();
            return new AppraisalInfo
            {
                Id = newProjectId.ToString(),
                Pname = "",
                Companycstno = "",
                Clientcstno = "",
                Contactname = "",
                Clientname = "",
                Custname = "",
                Paddress1 = "",
                Paddress2 = "",
                Pcity = "",
                Pstate = "",
                Pzip = "",
                Contactphone = "",
                Contactemail = "",
                Pforgncode = "",
                Pdateadded = DateTime.Now.ToShortDateString(),
                Pstartdate = "",
                Value1 = "",
                Value2 = "",
                Ptype = "",
                Intendeduse = "",
                Pnotes = "",
                Appraisddate = DateTime.Now.ToShortDateString()


            };
        }

        public AppraisalInfo Get(int projectid, string contactnameTb, string addressTb, string address2Tb, string cityTb, string statecb, string zipTb, string contactphoneTb, string contactemailTb, string countrycb, string ProjectStartDateTB, string valuetype1, string valuetype2, string projecttypeCb, string intendeduseTb, string notesRtb)
        {
            try
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
                cmd.CommandText = "AppraisalProjectUpdate_Mobile";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@id", projectid));
                cmd.Parameters.Add(new SqlParameter("@contactname", contactnameTb));
                cmd.Parameters.Add(new SqlParameter("@paddress1", addressTb));
                cmd.Parameters.Add(new SqlParameter("@paddress2", address2Tb));
                cmd.Parameters.Add(new SqlParameter("@pcity", cityTb));
                cmd.Parameters.Add(new SqlParameter("@pstate", statecb));
                cmd.Parameters.Add(new SqlParameter("@pzip", zipTb));
                cmd.Parameters.Add(new SqlParameter("@contactphone", contactphoneTb));
                cmd.Parameters.Add(new SqlParameter("@contactemail", contactemailTb));
                cmd.Parameters.Add(new SqlParameter("@pforgncode", countrycb));
                cmd.Parameters.Add(new SqlParameter("@pstartdate", ProjectStartDateTB));
                cmd.Parameters.Add(new SqlParameter("@value1", valuetype1));
                cmd.Parameters.Add(new SqlParameter("@value2", valuetype2));
                cmd.Parameters.Add(new SqlParameter("@ptype", projecttypeCb));
                cmd.Parameters.Add(new SqlParameter("@intendeduse", intendeduseTb));
                cmd.Parameters.Add(new SqlParameter("@pnotes", notesRtb));



                int nrows = Convert.ToInt32(cmd.ExecuteScalar().ToString());


                cmd.Dispose();
                cn.Close();
                cn.Dispose();
                return new AppraisalInfo
                {
                    Id = nrows.ToString(),
                    Pname = "Success",
                    Companycstno = "",
                    Clientcstno = "",
                    Contactname = "",
                    Clientname = "",
                    Custname = "",
                    Paddress1 = "",
                    Paddress2 = "",
                    Pcity = "",
                    Pstate = "",
                    Pzip = "",
                    Contactphone = "",
                    Contactemail = "",
                    Pforgncode = "",
                    Pdateadded = DateTime.Now.ToShortDateString(),
                    Pstartdate = "",
                    Value1 = "",
                    Value2 = "",
                    Ptype = "",
                    Intendeduse = "",
                    Pnotes = "",
                    Serial = "",
                    Year = "",
                    Model = "",
                    Mfg = "",
                    Itemid = "",
                    Recordtype = "",
                    Appraisddate = DateTime.Now.ToShortDateString()


                };
            }
            catch (System.Exception e2)
            {
                return new AppraisalInfo
                {
                    Id = "-1",
                    Pname = "Fail " + e2.Message,
                    Companycstno = "lll",
                    Clientcstno = "",
                    Contactname = "",
                    Clientname = "",
                    Custname = "",
                    Paddress1 = "",
                    Paddress2 = "",
                    Pcity = "",
                    Pstate = "",
                    Pzip = "",
                    Contactphone = "",
                    Contactemail = "",
                    Pforgncode = "",
                    Pdateadded = DateTime.Now.ToShortDateString(),
                    Pstartdate = "",
                    Value1 = "",
                    Value2 = "",
                    Ptype = "",
                    Intendeduse = "",
                    Pnotes = "",
                    Serial = "",
                    Year = "",
                    Model = "",
                    Mfg = "",
                    Itemid = "",
                    Recordtype = "",

                    Appraisddate = DateTime.Now.ToShortDateString()


                };
            }
        }

        public string Rotate90(string inputfilename)
        {
            string output = inputfilename.ToUpper().Replace(".JPG", "R.JPG");

            try
            {

                output = inputfilename;
                output = @"D:\Web2\ApprPics\rotatedAppraisalAPI.jpg";

                // FOR TESTing during development uncomment next line
                output = @"W:\ApprPics\rotatedAppraisalAPI.jpg";

                //create an object that we can use to examine an image file
                using (Image img = Image.FromFile(inputfilename))
                {
                    //rotate the picture by 90 degrees and re-save the picture as a Jpeg
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    //var newImage = new Bitmap(img, new Size(1920,1080));
                    var newImage = new Bitmap(img, new Size(img.Height, img.Width));
                    img.Dispose();
                    newImage.Save(output, System.Drawing.Imaging.ImageFormat.Jpeg);
                    newImage.Dispose();
                }
            }
            catch (Exception e2)
            {
                
            }

            return output;
        }


        // POST: api/Appraisal
        //public void Post([FromBody]string value)
        //{
        //}

        //public void Post([FromBody]string value)
        // route decorator
        // foxnes.com/r

        //[Route("PGLAPI/api/Image/Upload/{car_number}")]
        [Route("Image/Upload/{projectitem}")]

        //public string Post( [FromUri] int car_number, [FromBody] byte[] value)

        public string Post([FromUri] string projectitem)
        {
            string result2 = "Photo Uploaded";
            // 2-47
            string projectid = "";
            string itemid = "";
            string portraitOrlandscape = "P";

            int dashpos = projectitem.IndexOf("-");
            int exclpos = projectitem.IndexOf("!");
            projectid = projectitem.Substring(0, dashpos);

            itemid = projectitem.Substring(dashpos + 1,exclpos - dashpos - 1);

            portraitOrlandscape = projectitem.Substring(exclpos + 1);



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
                HttpResponseMessage result = null;
                var httpRequest = System.Web.HttpContext.Current.Request;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@msg", projectitem + " received, file count is " + httpRequest.Files.Count.ToString()));
                cmd.Parameters.Add(new SqlParameter("@application", "iOS Photo"));
                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@msg", projectid + "-"+ itemid + " "+portraitOrlandscape + " project and item"));
                cmd.Parameters.Add(new SqlParameter("@application", "iOS Photo"));
                nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                System.IO.DirectoryInfo di = new DirectoryInfo(@"D:\Web2\ApprPics\Project" + projectid);

                // FOR TESTing during development uncomment next line
                //System.IO.DirectoryInfo di = new DirectoryInfo(@"W:\ApprPics\Project" + projectid);

                int numberofFilesInFolder = di.GetFiles(itemid+"-*.*").Length + 1;

                if (httpRequest.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        //var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                        var filePath = @"D:\Web2\ApprPics\Project" + projectid + @"\pic" + itemid+"-"+numberofFilesInFolder.ToString()+".jpg";

                        // FOR TESTing during development uncomment next line
                        //filePath = @"W:\ApprPics\Project" + projectid + @"\pic" + itemid + "-" + numberofFilesInFolder.ToString() + ".jpg";


                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@msg", filePath + " file path"));
                        cmd.Parameters.Add(new SqlParameter("@application", "iOS Photo"));
                        nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                        bool b = false;
                        while (!b)
                        {
                            if (System.IO.File.Exists(filePath))
                            {
                                numberofFilesInFolder++;
                                filePath = @"D:\Web2\ApprPics\Project" + projectid + @"\pic" + itemid + "-" + numberofFilesInFolder.ToString() + ".jpg";

                                // FOR TESTing during development uncomment next line
                                 //filePath = @"W:\ApprPics\Project" + projectid + @"\pic" + itemid + "-" + numberofFilesInFolder.ToString() + ".jpg";
                            }
                            else
                            {
                                break;
                            }
                        }

                        postedFile.SaveAs(filePath);

                        if(portraitOrlandscape.ToUpper() == "L")
                        {
                            try
                            {
                                string newfile = this.Rotate90(filePath);
                                
                                System.IO.File.Copy(newfile, filePath,true);
                            }
                            catch(Exception e2)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add(new SqlParameter("@msg", projectid + "-" + itemid + " error " + e2.Message));
                                cmd.Parameters.Add(new SqlParameter("@application", "iOS Photo"));
                                nrows = Convert.ToInt32(cmd.ExecuteNonQuery());
                                result2 = "Error, Picture Uploaded, but not rotates: " + e2.Message;
                            }
                        }

                        try
                        {
                            SqlCommand cmd2 = new SqlCommand();
                            //cn.ConnectionString = cnToUse;
                            //cn.Open();
                            cmd2.Connection = cn;
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.CommandText = "DocumentInsert";
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add(new SqlParameter("@recordType", "appr"));
                            cmd2.Parameters.Add(new SqlParameter("@recordkey", Convert.ToInt32(itemid)));
                            cmd2.Parameters.Add(new SqlParameter("@filepath", filePath.Replace(@"D:\Web2","W:")));
                            cmd2.Parameters.Add(new SqlParameter("@description", ""));
                            cmd2.Parameters.Add(new SqlParameter("@addbyid", 1));
                            cmd2.Parameters.Add(new SqlParameter("@youtube", ""));
                            cmd2.Parameters.Add(new SqlParameter("@onweb", false));

                            nrows = Convert.ToInt32(cmd2.ExecuteNonQuery());

                            cmd2.Dispose();
                        }
                        catch(Exception e3)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@msg", projectid + "-" + itemid + " error "+e3.Message));
                            cmd.Parameters.Add(new SqlParameter("@application", "iOS Photo"));
                            nrows = Convert.ToInt32(cmd.ExecuteNonQuery());
                            result2 = "Error, Picture Uploaded, but not added to Spike: " + e3.Message;
                        }

                        // docfiles.Add(filePath);
                    }
                }
                else
                {

                    byte[] bytes = Convert.FromBase64String(httpRequest.InputStream.ToString());

                    
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@msg", bytes.Length.ToString() + " Bytes length"));
                    cmd.Parameters.Add(new SqlParameter("@application", "iOS Photo"));
                    nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                    MemoryStream ms = new MemoryStream(bytes);

                    Image img = System.Drawing.Image.FromStream(ms);

                    img.Save(@"f:\andy\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception e2)
            {
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@msg", "API Error POST " + e2.Message));
                cmd.Parameters.Add(new SqlParameter("@application", "iOS Photo"));

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                result2 = "Error: " + e2.Message;
            }

            cmd.Dispose();
            cn.Close();
            cn.Dispose();
            //try
            //{



            //    cmd.Parameters.Clear();

            //    cmd.Parameters.Add(new SqlParameter("@msg", car_number.ToString() + " car number received"));
            //    cmd.Parameters.Add(new SqlParameter("@application", "iOS Photo"));

            //    int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

            //    cmd.Dispose();
            //    cn.Close();
            //    cn.Dispose();
            //}
            //catch (Exception e2)
            //{
            //    return "Error: " + e2.Message;
            //}
            //return "";
            return result2;
        }


        [HttpPost]
        public string PostBinaryBuffer([NakedBody] byte[] raw)
        {
            return raw.Length + " bytes sent";
        }

        [HttpPost]
        public string PostRawBuffer([NakedBody] string raw)
        {
            return raw;
        }

        // PUT: api/Appraisal/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Appraisal/5
        public void Delete(int id)
        {
        }

    }

    /// <summary>
    /// Reads the Request body into a string/byte[] and
    /// assigns it to the parameter bound.
    /// 
    /// Should only be used with a single parameter on
    /// a Web API method using the [NakedBody] attribute
    /// </summary>
    public class NakedBodyParameterBinding : HttpParameterBinding
    {
        public NakedBodyParameterBinding(HttpParameterDescriptor descriptor)
            : base(descriptor)
        {

        }


        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
                                                    HttpActionContext actionContext,
                                                    CancellationToken cancellationToken)
        {
            var binding = actionContext
                .ActionDescriptor
                .ActionBinding;

            if (binding.ParameterBindings.Length > 1 ||
                actionContext.Request.Method == HttpMethod.Get)
                return EmptyTask.Start();

            var type = binding
                        .ParameterBindings[0]
                        .Descriptor.ParameterType;

            if (type == typeof(string))
            {
                return actionContext.Request.Content
                        .ReadAsStringAsync()
                        .ContinueWith((task) =>
                        {
                            var stringResult = task.Result;
                            SetValue(actionContext, stringResult);
                        });
            }
            else if (type == typeof(byte[]))
            {
                return actionContext.Request.Content
                    .ReadAsByteArrayAsync()
                    .ContinueWith((task) =>
                    {
                        byte[] result = task.Result;
                        SetValue(actionContext, result);
                    });
            }

            throw new InvalidOperationException("Only string and byte[] are supported for [NakedBody] parameters");
        }

        //public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        public override bool WillReadBody
        {
            get
            {
                return true;
            }
        }
    }

    /// <summary>
    /// A do nothing task that can be returned
    /// from functions that require task results
    /// when there's nothing to do.
    /// 
    /// This essentially returns a completed task
    /// with an empty value structure result.
    /// </summary>
    public class EmptyTask
    {
        public static Task Start()
        {
            var taskSource = new TaskCompletionSource<AsyncVoid>();
            taskSource.SetResult(default(AsyncVoid));
            return taskSource.Task as Task;
        }

        private struct AsyncVoid
        {
        }
    }

    /// <summary>
    /// An attribute that captures the entire content body and stores it
    /// into the parameter of type string or byte[].
    /// </summary>
    /// <remarks>
    /// The parameter marked up with this attribute should be the only parameter as it reads the
    /// entire request body and assigns it to that parameter.    
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public sealed class NakedBodyAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            if (parameter == null)
                throw new ArgumentException("Invalid parameter");

            return new NakedBodyParameterBinding(parameter);
        }
    }
}
