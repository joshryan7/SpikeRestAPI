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
    public class DealsController : ApiController
    {
        private List<DealsInfo> dealslist;
        dsDeals.DealsSelectByName_mobileDataTable dt = new dsDeals.DealsSelectByName_mobileDataTable();

        // GET: api/Deals
        public DealsInfo Get()
        {
            return new DealsInfo
            {
                Dname = "",
                Dcompanyfull = "",
                Id = "",
                Dcontactfull = "",
                Forgncodefull = "",
                Addr1 = "",
                City = "",
                Statefull = "",
                Zip = "",
                Internetdisplayorder = "",
                Companylogo = "",
                Internetdescription = "",
                Dateadded = "",
                Datefound = "",
                Dstatus = "",
                Dtype = "",
                Dsubtype = "",
                Webshowin = "",
                Showonwebsite = "",
                NoFollowuprequired = "",
                Companylogourl = ""
            };
        }

        private void ProcessData()
        {
            dealslist = new List<DealsInfo>();
            if (dt.Rows.Count > 0)
            {
               
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    DealsInfo d = new DealsInfo();

                    d.Addr1 = dt[i].addr1;
                    d.Addr2 = dt[i].addr2;
                    d.Addr3 = dt[i].addr3;

                    d.Appointmentdate = dt[i].AppointmentDate.ToShortDateString();
                    d.Appointmenttime = dt[i].AppointmentTime.Trim();

                    d.Appraisedbyfull = dt[i].AppraisedByFull;
                    d.Approvedby = dt[i].approvedby;

                    d.Auctionclosedate = dt[i].AuctionCloseDate.ToShortDateString();
                    d.Auctionclosetime = dt[i].AuctionCloseTime.Trim();

                    d.Auctionstartdate = dt[i].AuctionStartDate.ToShortDateString();
                    d.Auctionstarttime = dt[i].auctionStartTime.Trim();

                    d.Auctionurl = dt[i].auctionUrl.Trim();


                    //B

                    d.Bptext = dt[i].bpText;

                    d.Brochuredestinationurl = dt[i].brochure_destination_url;
                    d.Brochureimageurl = dt[i].brochure_image_url;

                    d.Buyerpremium = dt[i].BuyerPremium.ToString();

                    //C

                    d.City = dt[i].city;
                    d.Companylogo = dt[i].CompanyLogo;
                    d.Customurl = dt[i].customurl;
                    d.Companylogourl = dt[i].companylogourl;

                    //D

                    d.Dateadded = dt[i].dateadded;
                    d.Dcompanyaka = dt[i].dCompanyAKA;
                    d.Dcompanycstno = dt[i].dCompanyCstno;
                    d.Dcompanyfull = dt[i].dCompanyFull;
                    d.Dcontactfull = dt[i].dContactFull;
                    d.Dealfromcstnofull = dt[i].DealFromCstnoFull;
                    d.Dealfromcstnonumber = dt[i].DealFromCstno;

                    d.Deallocation = dt[i].dealLocation;

                    d.Dname = dt[i].dname;
                    d.Documentfolder = dt[i].documentFolder;

                    d.Datefound = dt[i].DateFound.ToShortDateString();
                    if (dt[i].DateFound < DateTime.Parse("01/01/1990"))
                    {
                        d.Datefound = "Unknown";
                    }

                    d.Dstatus = dt[i].dstatus;
                    d.Dsubtype = dt[i].dsubtype;
                    d.Dtype = dt[i].dtype;
                    d.Dvalue = dt[i].dvalue.ToString("C0");
                    //E

                    d.Equipdetailsweb = dt[i].EquipDetailsweb;
                    d.Equipmentremoval = dt[i].EquipmentRemoval.ToShortDateString();

                    //F
                    d.Findercommission = dt[i].FinderCommission.ToString("C0");
                    d.Forgncodefull = dt[i].forgncodeFull;
                    d.Forgncode = dt[i].forgncode;

                    d.Foundbyfull = dt[i].FoundByFull;

                    //H
                    d.Howfound = dt[i].howfound;

                    //I
                    d.Id = dt[i].id.ToString();
                    d.Inspectionweb = dt[i].InspectionWeb;
                    d.Internetdescription = dt[i].InternetDescription;
                    d.Internetdisplayorder = dt[i].InternetDisplayOrder;
                    d.Invnoaccounting = dt[i].invno_accounting;

                    //L
                    d.Leadtype = dt[i].leadtype;
                    d.Lob = dt[i].lob;
                    d.Lotlisting = dt[i].LotListing;

                    //M
                    d.Metadescription = dt[i].metadescription;
                    d.Metakeyword = dt[i].metakeyword;

                    // N
                    d.Nolongerforsale = dt[i].NoLongerForSale.ToShortDateString();
                    d.NoFollowuprequired = dt[i].NoFollowUp.ToString();

                    //O

                    d.Oninternet = dt[i].OnInternet.ToString();

                    d.Othercompany1comment = dt[i].OtherCompany1Comment;
                    d.Othercompany1cstno = dt[i].OtherCompany1Cstno;
                    d.Othercompany1full = dt[i].OtherCompany1Full;

                    d.Othercompany2comment = dt[i].OtherCompany2Comment;
                    d.Othercompany2cstno = dt[i].OtherCompany2Cstno;
                    d.Othercompany2full = dt[i].OtherCompany2Full;

                    //P
                    d.Pdfthumb = dt[i].PdfThumb;
                    d.Pdflocation = dt[i].PdfLocation;



                    //Q
                    d.Quoteverbiage = dt[i].QuoteVerbiage;

                    //R
                    d.Registerurl = dt[i].RegisterURL;

                    //S

                    d.Sellercommission = dt[i].SellerCommission.ToString("C0");
                    d.Showonwebsite = dt[i].OnInternet.ToString();
                    d.Signornote = dt[i].signornote;
                    d.Sitecontactinfo = dt[i].SiteContactInfo;

                    d.Stateabbr = dt[i].state;
                    d.Statefull = dt[i].stateFull;

                    d.Submitbydate = dt[i].SubmitByDate.ToShortDateString();
                    d.Submitbytime = dt[i].SubmitByTime;

                    //T
                    d.Tagsiteverbiage = dt[i].TagVerbiage.Trim();
                    d.terms1 = dt[i].Terms;
                    d.termnotes = dt[i].terms_notes;

                    d.Timezonetext = dt[i].TimeZoneText;
                    d.Titletag = dt[i].titletag;

                    //W
                    d.Webdatetimetext = dt[i].WebDateTimeText;

                    d.Webpageviews = dt[i].webpagevisits.ToString();
                    d.Webshowin = dt[i].WebShowin;
                    d.Websiteverbiage = dt[i].WebsiteVerbiage;
                    d.Weburl = dt[i].WebURL;



                    d.Zip = dt[i].zip;


                    dealslist.Add(d);
                    i++;
                }
            }
        }
        // GET: api/Deals/5

        public List<DealsInfo> Get(string searchterm)
        {

            SpikeRest.DAL.dsDealsTableAdapters.DealsSelectByName_mobileTableAdapter ta = new DAL.dsDealsTableAdapters.DealsSelectByName_mobileTableAdapter();
            dt.Clear();

            try
            {
                dt = ta.GetDataOnWebSite();
                this.ProcessData();

            }
            catch (Exception e2)
            {
                dealslist = new List<DealsInfo>();

                DealsInfo d = new DealsInfo();

                d.Addr1 = e2.Message;

            }
            return dealslist;
        }


        public List<DealsInfo> Get(string searchterm, string lob ,string updaterecents, string userid)
        {
           
            SpikeRest.DAL.dsDealsTableAdapters.DealsSelectByName_mobileTableAdapter ta = new DAL.dsDealsTableAdapters.DealsSelectByName_mobileTableAdapter();
            dt.Clear();

            try
            {
                dt = ta.GetData(searchterm, lob, Convert.ToInt32(updaterecents), Convert.ToInt32(userid));
                this.ProcessData();
               
            }
            catch (Exception e2)
            {
                dealslist = new List<DealsInfo>();

                DealsInfo d = new DealsInfo();

                d.Addr1 = e2.Message;

            }
            return dealslist;
        }

        public List<DealsInfo> Get(string id, string lob, string userid)
        {

            SpikeRest.DAL.dsDealsTableAdapters.DealsSelectByName_mobileTableAdapter ta = new DAL.dsDealsTableAdapters.DealsSelectByName_mobileTableAdapter();
            dt.Clear();

            try
            {
                dt = ta.GetDataBy(Convert.ToInt32(id), lob, Convert.ToInt32(userid));
                this.ProcessData();

            }
            catch (Exception e2)
            {
                dealslist = new List<DealsInfo>();

                DealsInfo d = new DealsInfo();

                d.Addr1 = e2.Message;

            }
            return dealslist;
        }

        [Route("LotImage/Upload/{dealitem}")]

        // POST: api/Deals
        // format of dealitem: dealid-lot
        public string Post([FromUri]string dealitem)
        {
            string result2 = "Photo Uploaded";

           
            // 2-47
            string dealid = "";
            string lot = "";

            int dashpos = dealitem.IndexOf("-");
            dealid = dealitem.Substring(0, dashpos);
            lot = dealitem.Substring(dashpos + 1);

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
                cmd.Parameters.Add(new SqlParameter("@msg", dealid + " Deal, file count is " + httpRequest.Files.Count.ToString()));
                cmd.Parameters.Add(new SqlParameter("@application", "iOS Photo"));
                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@msg", dealid + "-" + lot + " deal and lot"));
                cmd.Parameters.Add(new SqlParameter("@application", "iOS Photo"));
                nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

               
                System.IO.DirectoryInfo di = new DirectoryInfo(@"D:\Web2\DealPics\" + dealid);
                if (!di.Exists)
                {
                    System.IO.Directory.CreateDirectory(@"D:\Web2\DealPics\" + dealid);
                }

                int numberofFilesInFolder = di.GetFiles(lot + "-*.*").Length + 1;

                if (httpRequest.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        //var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                        var filePath = @"D:\Web2\DealPics\"+dealid+@"\"+lot + "-" + numberofFilesInFolder.ToString() + ".jpg";


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
                                
                                filePath = @"D:\Web2\DealPics\" + dealid + @"\" + lot + "-" + numberofFilesInFolder.ToString() + ".jpg";
                            }
                            else
                            {
                                break;
                            }
                        }
                        postedFile.SaveAs(filePath);

                        try
                        {
                            SqlCommand cmd2 = new SqlCommand();
                            //cn.ConnectionString = cnToUse;
                            //cn.Open();
                            cmd2.Connection = cn;
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.CommandText = "DocumentInsert";
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add(new SqlParameter("@recordType", "deal"));
                            cmd2.Parameters.Add(new SqlParameter("@recordkey", Convert.ToInt32(dealid)));
                            cmd2.Parameters.Add(new SqlParameter("@filepath", filePath.Replace(@"D:\Web2", "W:")));
                            cmd2.Parameters.Add(new SqlParameter("@description", ""));
                            cmd2.Parameters.Add(new SqlParameter("@addbyid", 1));
                            cmd2.Parameters.Add(new SqlParameter("@youtube", ""));
                            cmd2.Parameters.Add(new SqlParameter("@onweb", false));

                            nrows = Convert.ToInt32(cmd2.ExecuteNonQuery());

                            cmd2.Dispose();
                        }
                        catch (Exception e3)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@msg", dealid + "-" + lot + " error " + e3.Message));
                            cmd.Parameters.Add(new SqlParameter("@application", "iOS Photo"));
                            nrows = Convert.ToInt32(cmd.ExecuteNonQuery());
                            result2 = "Error, Picture Uploaded, but not added to Spike: " + e3.Message;
                        }

                        // docfiles.Add(filePath);
                    }
                }

            }
            catch (Exception e2)
            {
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@msg", "API Error POST " + e2.Message));
                cmd.Parameters.Add(new SqlParameter("@application", "iOS Photo"));

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                result2 =  "Error: " + e2.Message;
            }

            cmd.Dispose();
            cn.Close();
            cn.Dispose();

            return result2;
        }

        // PUT: api/Deals/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Deals/5
        public void Delete(int id)
        {
        }
    }
}
