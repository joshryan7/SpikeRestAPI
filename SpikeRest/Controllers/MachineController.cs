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
    
    public class MachineController : ApiController
    {
        // GET: api/Machine
        public MachineInfo Get()
        {
            return new MachineInfo
            {
                Invno = "12345",
                Description = "test 12345 description",
                Year = "2000"
            };
        }

        // GET: api/Machine/5
        public MachineInfo Get(string invno, int userid)
        {
            
            dsMachine.GetUsedInventoryItem_MobileDataTable dt = new dsMachine.GetUsedInventoryItem_MobileDataTable();
            SpikeRest.DAL.dsMachineTableAdapters.GetUsedInventoryItem_MobileTableAdapter ta = new DAL.dsMachineTableAdapters.GetUsedInventoryItem_MobileTableAdapter();

            string _invno = "";
            string _description = "";
            string _year = "";
            string _specsheet = "";
            string _specmetric = "";
            string _jvpinvno = "";
            string _jvpandpercentage = "";
            string _label1 = "";
            string _value1 = "";
            string _label2 = "";
            string _value2 = "";
            string _label3 = "";
            string _value3 = "";
            string _label4 = "";
            string _value4 = "";
            string _label5 = "";
            string _value5 = "";
            string _label6 = "";
            string _value6 = "";
            string _label7 = "";
            string _value7 = "";
            string _label8 = "";
            string _value8 = "";
            string _city = "";
            string _state = "";



            string _model = "";
            string _imagemain = "";
            string _youtubevideo = "";
            string _numbofntoes = "";
            string _numbofoffers = "";
            string _pifstatus = "";
            string _tag_long = "";
            string _tagdate = "";
            string _tagcustomer = "";
            string _tagcontact = "";
            string _tagsalesperson = "";
            string _tagamount = "";
            string _outbound = "";
            string _inspdate = "";
            string _cstno = "";
            string _retail = "";
            string _width = "";
            string _length = "";
            string _height = "";
            string _approx_wt = "";
            string _dimensioncomment = "";
            string _sqft = "";
            string _salesplanstatus = "";

            string _signorid = "";
            string _signorname = "";
            string _leadtype = "";
            string _approvedby = "";
            string _howfound = "";
            string _signornote = "";
            string _exclEndDate = "";
            string _netbacktoseller = "";
            string _responsibleSalesmanid = "";
            string _netbacktoselleramount = "";
            string _netbacktosellerpercentage = "";

            string _transferamount = "";
            string _transfernote = "";
            string _removalamount = "";
            string _removalnote = "";
            string _assetcontactname = "";
            string _assetcontactemail = "";
            string _assetcontactphone = "";
            string _transferassets = "";

            dt = ta.GetDataByInvno(invno, userid, "");
            
            if(dt.Rows.Count > 0)
            {
                _description = dt[0].ItemName.Trim();
                _year = dt[0].year;
                _specsheet = dt[0].specsheet;
                _specmetric = dt[0].specmetric;
                _jvpinvno = dt[0].jvpinvno.Trim();
                _jvpandpercentage = dt[0].JVPandPercentage;
                _invno = dt[0].invno;
                _value1 = dt[0].value1.Trim();
                _label1 = dt[0].label1.Trim();
                _value2 = dt[0].value2.Trim();
                _label2 = dt[0].label2.Trim();
                _value3 = dt[0].value3.Trim();
                _label3 = dt[0].label3.Trim();
                _value4 = dt[0].value4.Trim();
                _label4 = dt[0].label4.Trim();
                _value5 = dt[0].value5.Trim();
                _label5 = dt[0].label5.Trim();
                _value6 = dt[0].value6.Trim();
                _label6 = dt[0].label6.Trim();
                _value7 = dt[0].value7.Trim();
                _label7 = dt[0].label7.Trim();
                _value8 = dt[0].value8.Trim();
                _label8 = dt[0].label8.Trim();
                _imagemain = dt[0].ItemImageName;
                _model = dt[0].model;
                _youtubevideo = "";
                _numbofntoes = dt[0].numbofnotes.ToString();
                _numbofoffers = dt[0].numbofoffers.ToString();
                _youtubevideo = dt[0].youtube_embed;
                _pifstatus = dt[0].PIFSTATUS.Substring(1);
                _tag_long = dt[0].Tag_Long;
                _tagdate = dt[0].TagDate;
                _tagcustomer = dt[0].TagCustomer;
                _tagcontact = dt[0].TagContact;
                _tagsalesperson = dt[0].TagSalesPerson;
                _tagamount = dt[0].TagAmount;
                _cstno = dt[0].HLD_CSTNO;
                _retail = dt[0].Retail;

                _width = dt[0].width;
                _length = dt[0].length;
                _height = dt[0].height;
                _approx_wt = dt[0].approx_wt;
                _dimensioncomment = dt[0].dimensionComment;
                _sqft = dt[0].sqft;

                _signorid = dt[0].signorid.ToString();
                _signorname = dt[0].signor;
                _leadtype = dt[0].leadtype;
                _approvedby = dt[0].approvedby;
                _howfound = dt[0].howfound;
                _signornote = dt[0].signornote;
                _exclEndDate = dt[0].exclEndDate.ToShortDateString();
                _netbacktoseller = dt[0].netbacktoseller;
                _responsibleSalesmanid = dt[0].responsibleSalesmanid;
                _netbacktoselleramount = dt[0].netbacktoselleramount;
                _netbacktosellerpercentage = dt[0].netbacktosellerpercentage;

                _city = dt[0].city;
                _state = dt[0].state;

                try
                {
                    _transferamount = Convert.ToDecimal(dt[0].transferamount).ToString("C0");
                    //_transferamount = "$1,889";
                }
                catch
                {
                    _transferamount = dt[0].transferamount;
                }

                _transfernote = dt[0].transfernote;

                try
                {
                    _removalamount = Convert.ToDecimal(dt[0].removalamount).ToString("C0");
                    //_transferamount = "$1,889";
                }
                catch
                {
                    _removalamount = dt[0].removalamount;
                }

                _removalnote = dt[0].removalnote;

                _assetcontactname = dt[0].assetcontactname;
                _assetcontactemail = dt[0].assetcontactemail;
                _assetcontactphone = dt[0].assetcontactphone;
                _transferassets = dt[0].transferassets;

                try
                {
                    if (dt[0].euros == true)
                    {
                        _retail = "€" + Convert.ToInt32(dt[0].Retail).ToString("N0");
                    }
                    else
                    {
                        _retail = Convert.ToInt32(dt[0].Retail).ToString("C0");
                        //_retail = dt[0].Retail;
                    }
                }
                catch
                {
                    _retail = dt[0].Retail;
                }
                try
                {
                    _tagamount = Convert.ToInt32(dt[0].TagAmount).ToString("C0");
                }
                catch
                {
                    _tagamount = dt[0].TagAmount;
                }

                _outbound = dt[0].OutBound.ToShortDateString();
                _inspdate = dt[0].inspdate.ToShortDateString();
                _salesplanstatus = dt[0].SalesPlanStatus;

                try
                {
                    _netbacktoselleramount = Convert.ToInt32(dt[0].netbacktoselleramount).ToString("C0");
                }
                catch
                {
                    _netbacktoselleramount = dt[0].netbacktoselleramount;
                }

               


            }
            else
            {
                _description = "Machine not found";
                _year = "n/a";
            }
            //if(invno == "20000")
            //{
            //    _description = "Spot 1 20000";
            //    _year = "Spot 1 Year";
            //}
            //else
            //{
            //    _description = "Spot 2 not 20000";
            //    _year = "Spot 2 Year";
            //}

            return new MachineInfo
            {
                Invno = _invno,
                Description = _description.Trim(),
                Year = _year,
                Jvpinvno = _jvpinvno,
                JvpandPercentage = _jvpandpercentage,
                ImageMain = _imagemain,
                SpecSheet = _specsheet,

                SpecMetric = _specmetric,
                Numbofnotes = _numbofntoes,
                Numbofoffers = _numbofoffers,
                Pifstatus = _pifstatus,
                Tag_long = _tag_long,
                Tagdate = _tagdate,
                Tagcustomer = _tagcustomer.Trim(),
                Tagcontact = _tagcontact,
                Tagsalesperson = _tagsalesperson,
                Tagamount = _tagamount,
                Outbound = _outbound,
                Inspdate = _inspdate,
                Cstno = _cstno,
                Retail = _retail,
                Width = _width,
                Length = _length,
                Height = _height,
                Approx_wt = _approx_wt,
                Dimensioncomment = _dimensioncomment,
                Sqft = _sqft,
                Salesplanstatus = _salesplanstatus,
                Signorid = _signorid,
                Signorname = _signorname,
                Leadtype = _leadtype,
                Approvedby = _approvedby,
                Howfound = _howfound,
                Signornote = _signornote,
                Exclenddate = _exclEndDate,
                Netbacktoseller = _netbacktoseller,
                Responsiblesalesmanid = _responsibleSalesmanid,
                Netbacktoselleramount = _netbacktoselleramount,
                Netbacktosellerpercentage = _netbacktosellerpercentage,
                City = _city,
                State = _state,
                Transferamount = _transferamount,
                Transfernote = _transfernote,
                Removalamount = _removalamount,
                Removalnote = _removalnote,
                Assetcontactname = _assetcontactname,
                Assetcontactemail = _assetcontactemail,
                Assetcontactphone = _assetcontactphone,
                Transferassets = _transferassets
                
                //Transferamount = "12345",
                //Transfernote = "Hello"

                //SpecSheet = _specsheet,

                //Label1 = _label1,
                //Value1 = _value1,
                //Label2 = _label2,
                //Value2 = _value2,
                //Label3 = _label3,
                //Value3 = _value3,
                //Label4 = _label4,
                //Value4 = _value4,
                //Label5 = _label5,
                //Value5 = _value5,
                //Label6 = _label6,
                //Value6 = _value6,
                //Label7 = _label7,
                //Value7 = _value7,
                //Label8 = _label8,
                //Value8 = _value8,

                //Model = _model

            };
        }

        public MachineInfo Get(string invno, string useremail)
        {

            dsMachine.GetUsedInventoryItem_MobileDataTable dt = new dsMachine.GetUsedInventoryItem_MobileDataTable();
            SpikeRest.DAL.dsMachineTableAdapters.GetUsedInventoryItem_MobileTableAdapter ta = new DAL.dsMachineTableAdapters.GetUsedInventoryItem_MobileTableAdapter();

            string _invno = "";
            string _description = "";
            string _year = "";
            string _specsheet = "";
            string _specmetric = "";
            string _jvpinvno = "";
            string _jvpandpercentage = "";
            string _label1 = "";
            string _value1 = "";
            string _label2 = "";
            string _value2 = "";
            string _label3 = "";
            string _value3 = "";
            string _label4 = "";
            string _value4 = "";
            string _label5 = "";
            string _value5 = "";
            string _label6 = "";
            string _value6 = "";
            string _label7 = "";
            string _value7 = "";
            string _label8 = "";
            string _value8 = "";
            string _city = "";
            string _state = "";



            string _model = "";
            string _imagemain = "";
            string _youtubevideo = "";
            string _numbofntoes = "";
            string _numbofoffers = "";
            string _pifstatus = "";
            string _tag_long = "";
            string _tagdate = "";
            string _tagcustomer = "";
            string _tagcontact = "";
            string _tagsalesperson = "";
            string _tagamount = "";
            string _outbound = "";
            string _inspdate = "";
            string _cstno = "";
            string _retail = "";
            string _width = "";
            string _length = "";
            string _height = "";
            string _approx_wt = "";
            string _dimensioncomment = "";
            string _sqft = "";
            string _salesplanstatus = "";

            string _signorid = "";
            string _signorname = "";
            string _leadtype = "";
            string _approvedby = "";
            string _howfound = "";
            string _signornote = "";
            string _exclEndDate = "";
            string _netbacktoseller = "";
            string _responsibleSalesmanid = "";
            string _netbacktoselleramount = "";
            string _netbacktosellerpercentage = "";

            string _transferamount = "";
            string _transfernote = "";
            string _removalamount = "";
            string _removalnote = "";
            string _assetcontactname = "";
            string _assetcontactemail = "";
            string _assetcontactphone = "";
            string _transferassets = "";

            // calls stored procedure GetUsedInventoryItem_Mobile
            dt = ta.GetDataByInvno(invno, 0 , useremail);

            if (dt.Rows.Count > 0)
            {
                _description = dt[0].ItemName.Trim();
                _year = dt[0].year;
                _specsheet = dt[0].specsheet;
                _specmetric = dt[0].specmetric;
                _jvpinvno = dt[0].jvpinvno.Trim();
                _jvpandpercentage = dt[0].JVPandPercentage;
                _invno = dt[0].invno;
                _value1 = dt[0].value1.Trim();
                _label1 = dt[0].label1.Trim();
                _value2 = dt[0].value2.Trim();
                _label2 = dt[0].label2.Trim();
                _value3 = dt[0].value3.Trim();
                _label3 = dt[0].label3.Trim();
                _value4 = dt[0].value4.Trim();
                _label4 = dt[0].label4.Trim();
                _value5 = dt[0].value5.Trim();
                _label5 = dt[0].label5.Trim();
                _value6 = dt[0].value6.Trim();
                _label6 = dt[0].label6.Trim();
                _value7 = dt[0].value7.Trim();
                _label7 = dt[0].label7.Trim();
                _value8 = dt[0].value8.Trim();
                _label8 = dt[0].label8.Trim();
                _imagemain = dt[0].ItemImageName;
                _model = dt[0].model;
                _youtubevideo = "";
                _numbofntoes = dt[0].numbofnotes.ToString();
                _numbofoffers = dt[0].numbofoffers.ToString();
                _youtubevideo = dt[0].youtube_embed;
                _pifstatus = dt[0].PIFSTATUS.Substring(1);
                _tag_long = dt[0].Tag_Long;
                _tagdate = dt[0].TagDate;
                _tagcustomer = dt[0].TagCustomer;
                _tagcontact = dt[0].TagContact;
                _tagsalesperson = dt[0].TagSalesPerson;
                _tagamount = dt[0].TagAmount;
                _cstno = dt[0].HLD_CSTNO;
                _retail = dt[0].Retail;

                _width = dt[0].width;
                _length = dt[0].length;
                _height = dt[0].height;
                _approx_wt = dt[0].approx_wt;
                _dimensioncomment = dt[0].dimensionComment;
                _sqft = dt[0].sqft;

                _signorid = dt[0].signorid.ToString();
                _signorname = dt[0].signor;
                _leadtype = dt[0].leadtype;
                _approvedby = dt[0].approvedby;
                _howfound = dt[0].howfound;
                _signornote = dt[0].signornote;
                _exclEndDate = dt[0].exclEndDate.ToShortDateString();
                _netbacktoseller = dt[0].netbacktoseller;
                _responsibleSalesmanid = dt[0].responsibleSalesmanid;
                _netbacktoselleramount = dt[0].netbacktoselleramount;
                _netbacktosellerpercentage = dt[0].netbacktosellerpercentage;

                _city = dt[0].city;
                _state = dt[0].state;

                try
                {
                    _transferamount = Convert.ToDecimal(dt[0].transferamount).ToString("C0");
                    //_transferamount = "$1,889";
                }
                catch
                {
                    _transferamount = dt[0].transferamount;
                }

                _transfernote = dt[0].transfernote;

                try
                {
                    _removalamount = Convert.ToDecimal(dt[0].removalamount).ToString("C0");
                    //_transferamount = "$1,889";
                }
                catch
                {
                    _removalamount = dt[0].removalamount;
                }

                _removalnote = dt[0].removalnote;

                _assetcontactname = dt[0].assetcontactname;
                _assetcontactemail = dt[0].assetcontactemail;
                _assetcontactphone = dt[0].assetcontactphone;
                _transferassets = dt[0].transferassets;

                try
                {
                    if (dt[0].euros == true)
                    {
                        _retail = "€" + Convert.ToInt32(dt[0].Retail).ToString("N0");
                    }
                    else
                    {
                        _retail = Convert.ToInt32(dt[0].Retail).ToString("C0");
                        //_retail = dt[0].Retail;
                    }
                }
                catch
                {
                    _retail = dt[0].Retail;
                }
                try
                {
                    _tagamount = Convert.ToInt32(dt[0].TagAmount).ToString("C0");
                }
                catch
                {
                    _tagamount = dt[0].TagAmount;
                }

                _outbound = dt[0].OutBound.ToShortDateString();
                _inspdate = dt[0].inspdate.ToShortDateString();
                _salesplanstatus = dt[0].SalesPlanStatus;

                try
                {
                    _netbacktoselleramount = Convert.ToInt32(dt[0].netbacktoselleramount).ToString("C0");
                }
                catch
                {
                    _netbacktoselleramount = dt[0].netbacktoselleramount;
                }




            }
            else
            {
                _description = "Machine not found";
                _year = "n/a";
            }
            //if(invno == "20000")
            //{
            //    _description = "Spot 1 20000";
            //    _year = "Spot 1 Year";
            //}
            //else
            //{
            //    _description = "Spot 2 not 20000";
            //    _year = "Spot 2 Year";
            //}

            return new MachineInfo
            {
                Invno = _invno,
                Description = _description.Trim(),
                Year = _year,
                Jvpinvno = _jvpinvno,
                JvpandPercentage = _jvpandpercentage,
                ImageMain = _imagemain,
                SpecSheet = _specsheet,

                SpecMetric = _specmetric,
                Numbofnotes = _numbofntoes,
                Numbofoffers = _numbofoffers,
                Pifstatus = _pifstatus,
                Tag_long = _tag_long,
                Tagdate = _tagdate,
                Tagcustomer = _tagcustomer.Trim(),
                Tagcontact = _tagcontact,
                Tagsalesperson = _tagsalesperson,
                Tagamount = _tagamount,
                Outbound = _outbound,
                Inspdate = _inspdate,
                Cstno = _cstno,
                Retail = _retail,
                Width = _width,
                Length = _length,
                Height = _height,
                Approx_wt = _approx_wt,
                Dimensioncomment = _dimensioncomment,
                Sqft = _sqft,
                Salesplanstatus = _salesplanstatus,
                Signorid = _signorid,
                Signorname = _signorname,
                Leadtype = _leadtype,
                Approvedby = _approvedby,
                Howfound = _howfound,
                Signornote = _signornote,
                Exclenddate = _exclEndDate,
                Netbacktoseller = _netbacktoseller,
                Responsiblesalesmanid = _responsibleSalesmanid,
                Netbacktoselleramount = _netbacktoselleramount,
                Netbacktosellerpercentage = _netbacktosellerpercentage,
                City = _city,
                State = _state,
                Transferamount = _transferamount,
                Transfernote = _transfernote,
                Removalamount = _removalamount,
                Removalnote = _removalnote,
                Assetcontactname = _assetcontactname,
                Assetcontactemail = _assetcontactemail,
                Assetcontactphone = _assetcontactphone,
                Transferassets = _transferassets

                //Transferamount = "12345",
                //Transfernote = "Hello"

                //SpecSheet = _specsheet,

                //Label1 = _label1,
                //Value1 = _value1,
                //Label2 = _label2,
                //Value2 = _value2,
                //Label3 = _label3,
                //Value3 = _value3,
                //Label4 = _label4,
                //Value4 = _value4,
                //Label5 = _label5,
                //Value5 = _value5,
                //Label6 = _label6,
                //Value6 = _value6,
                //Label7 = _label7,
                //Value7 = _value7,
                //Label8 = _label8,
                //Value8 = _value8,

                //Model = _model

            };
        }
        [Route("MachineImage/Upload/{invno}")]

        // POST: api/Deals
        // format of dealitem: dealid-lot
        public string Post([FromUri]string invno)
        {
            string result2 = "Photo Uploaded";


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
                cmd.Parameters.Add(new SqlParameter("@msg", invno + " Machine, file count is " + httpRequest.Files.Count.ToString()));
                cmd.Parameters.Add(new SqlParameter("@application", "iOS Machine Photo"));
                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@msg", invno + " invno"));
                cmd.Parameters.Add(new SqlParameter("@application", "iOS Machine Photo"));
                nrows = Convert.ToInt32(cmd.ExecuteNonQuery());
                
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@"D:\Web2\MachinePics\" + invno);

                
                if (!di.Exists)
                {
                    System.IO.Directory.CreateDirectory(@"D:\Web2\MachinePics\" + invno);
                   // di.CreateSubdirectory(@"D:\Web2\MachinePics\" + invno);
                }
                int numberofFilesInFolder = di.GetFiles(invno + "*.*").Length + 1;
                
                if (httpRequest.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        //var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                        var filePath = @"D:\Web2\MachinePics\" + invno + @"\" + invno + "-" + numberofFilesInFolder.ToString() + ".jpg";


                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@msg", filePath + " file path"));
                        cmd.Parameters.Add(new SqlParameter("@application", "iOS Machine Photo"));
                        nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                        bool b = false;
                        while (!b)
                        {
                            if (System.IO.File.Exists(filePath))
                            {
                                numberofFilesInFolder++;

                                filePath = @"D:\Web2\MachinePics\" + invno + @"\" + "-" + numberofFilesInFolder.ToString() + ".jpg";
                            }
                            else
                            {
                                break;
                            }
                        }
                        postedFile.SaveAs(filePath);

                        // docfiles.Add(filePath);
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


        // POST: api/Machine
        //public void Post([FromBody]string value)
        //{
        //    System.IO.File.AppendAllText(@"d:\web2\andy\api_log.txt", value);
        //    System.IO.File.AppendAllText(@"d:\web2\andy\api_log.txt", Environment.NewLine+"Hello");

            //String _connectionString = "";

            //ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            //foreach (ConnectionStringSettings connection in connectionStrings)
            //{
            //    _connectionString = connection.ConnectionString;
            //}

            //SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = _connectionString;

            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = cn;
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandText = "AuditInsert";

            //cmd.Parameters.Add(new SqlParameter("@msg", value));
            //cmd.Parameters.Add(new SqlParameter("@applicatrion", "API /Machine"));

            //cn.Open();

            //int irows = cmd.ExecuteNonQuery();

            //cn.Close();
            //cmd.Dispose();
            //cn.Dispose();

        //}

        // PUT: api/Machine/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Machine/5
        public void Delete(int id)
        {
        }
    }
}
