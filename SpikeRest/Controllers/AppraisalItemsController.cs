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
    public class AppraisalItemsController : ApiController
    {
        private List<AppraisalItemsInfo> appraisalitemslist;

        // GET: api/AppraisalItems
        public AppraisalItemsInfo Get()
        {
            return new AppraisalItemsInfo
            {
                Id = "",
                Projectid = "",
                Locationid = "",
                Mfg = "",
                Model = "",
                Year = "",
                Serial = "",
                Value1a = "",
                Value1t = "",
                Value2a = "",
                Value2t = "",
                Quantity = "",
                Description = "",
                Capacity = "",
                Assettype = "",
                Refno = "",
                Condition = "",
                Notes = "",
                Assetnum = "",
                Appraisedby  = "",
                Appraisedate = "",
                Appraidedbyfullname = "",
                Locationname = ""

            };
        }

        // GET: api/AppraisalItems/5
        public List<AppraisalItemsInfo> Get(int projectid, int locationid)
        {
            dsAppraisalItems.AppraisalItems_MobileDataTable dt = new dsAppraisalItems.AppraisalItems_MobileDataTable();
            SpikeRest.DAL.dsAppraisalItemsTableAdapters.AppraisalItems_MobileTableAdapter ta = new DAL.dsAppraisalItemsTableAdapters.AppraisalItems_MobileTableAdapter();
            appraisalitemslist = new List<AppraisalItemsInfo>();
            dt = ta.GetData(projectid, locationid);
            if (dt.Rows.Count > 0)
            {
               
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    AppraisalItemsInfo a = new AppraisalItemsInfo();
                    a.Id = dt[i].id.ToString();
                    a.Projectid = dt[i].projectid.ToString();
                    a.Locationid = dt[i].locationid.ToString();
                    a.Mfg = dt[i].mfg;
                    a.Model = dt[i].model;
                    a.Year = dt[i].year;
                    a.Serial = dt[i].serial;
                    a.Value1a = dt[i].value1a.ToString("C0");
                    a.Value1t = dt[i].value1t;
                    a.Value2a = dt[i].value2a.ToString("C0");
                    a.Value2t = dt[i].value2t;
                    a.Quantity = dt[i].quantity;
                    a.Description = dt[i].description;
                    a.Capacity = dt[i].capacity;
                    a.Assettype = dt[i].assettype;
                    a.Refno = dt[i].refno.ToString();
                    a.Condition = dt[i].condition;
                    a.Notes = dt[i].notes;
                    a.Assetnum = dt[i].assetnum;
                    a.Appraisedby = dt[i].appraisedby.ToString();
                    a.Appraisedate = dt[i].appraiseddate.ToShortDateString();
                    a.Appraidedbyfullname = dt[i].appraisedbyfullname;
                    a.Locationname = dt[i].locationname;

                    appraisalitemslist.Add(a);
                    i++;
                }
            }
            return appraisalitemslist;
        }

        public List<AppraisalItemsInfo> Get(int itemid)
        {
            dsAppraisalItems.AppraisalItems_MobileDataTable dt = new dsAppraisalItems.AppraisalItems_MobileDataTable();
            SpikeRest.DAL.dsAppraisalItemsTableAdapters.AppraisalItems_MobileTableAdapter ta = new DAL.dsAppraisalItemsTableAdapters.AppraisalItems_MobileTableAdapter();
            appraisalitemslist = new List<AppraisalItemsInfo>();
            dt = ta.GetDataById(itemid);
            if (dt.Rows.Count > 0)
            {
                appraisalitemslist = new List<AppraisalItemsInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    AppraisalItemsInfo a = new AppraisalItemsInfo();
                    a.Id = dt[i].id.ToString();
                    a.Projectid = dt[i].projectid.ToString();
                    a.Locationid = dt[i].locationid.ToString();
                    a.Mfg = dt[i].mfg;
                    a.Model = dt[i].model;
                    a.Year = dt[i].year;
                    a.Serial = dt[i].serial;
                    a.Value1a = dt[i].value1a.ToString("C0");
                    a.Value1t = dt[i].value1t;
                    a.Value2a = dt[i].value2a.ToString("C0");
                    a.Value2t = dt[i].value2t;
                    a.Quantity = dt[i].quantity;
                    a.Description = dt[i].description;
                    a.Capacity = dt[i].capacity;
                    a.Assettype = dt[i].assettype;
                    a.Refno = dt[i].refno.ToString();
                    a.Condition = dt[i].condition;
                    a.Notes = dt[i].notes;
                    a.Assetnum = dt[i].assetnum;
                    a.Appraisedby = dt[i].appraisedby.ToString();
                    a.Appraisedate = dt[i].appraiseddate.ToShortDateString();
                    a.Appraidedbyfullname = dt[i].appraisedbyfullname;
                    a.Locationname = dt[i].locationname;

                    appraisalitemslist.Add(a);
                    i++;
                }
            }
            return appraisalitemslist;
        }

        public List<AppraisalItemsInfo> Get
            (
                string InsertOrUpdate,
                int projectid,
                int locationid,
                string mfg,
                string model,
                string year,
                string serial,
                string value1a,
                string value1t,
                string value2a,
                string value2t,
                string quantity,
                string description,
                string capacity,
                string assettype,
                string condition,
                string notes,
                string assetnum,
                int appraisedby,
                int id1
            )
        {
            string result = "true";

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
                value1a = value1a.Replace("$", "");
                value1a = value1a.Replace(",", "");

                value2a = value2a.Replace("$", "");
                value2a = value2a.Replace(",", "");

                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = cnToUse;
                cn.Open();


                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                if (InsertOrUpdate == "I")
                {
                    cmd.CommandText = "AppraisalItemInsert_Mobile";
                    cmd.Parameters.Add(new SqlParameter("@projectid", projectid));
                    cmd.Parameters.Add(new SqlParameter("@locationid", locationid));
                    cmd.Parameters.Add(new SqlParameter("@mfg", mfg));
                    cmd.Parameters.Add(new SqlParameter("@model", model));
                    cmd.Parameters.Add(new SqlParameter("@year", year));
                    cmd.Parameters.Add(new SqlParameter("@serial", serial));
                    cmd.Parameters.Add(new SqlParameter("@value1a", value1a));
                    cmd.Parameters.Add(new SqlParameter("@value1t", value1t));
                    cmd.Parameters.Add(new SqlParameter("@value2a", value2a));
                    cmd.Parameters.Add(new SqlParameter("@value2t", value2t));
                    cmd.Parameters.Add(new SqlParameter("@quantity", quantity));
                    cmd.Parameters.Add(new SqlParameter("@description", description));
                    cmd.Parameters.Add(new SqlParameter("@capacity", capacity));
                    cmd.Parameters.Add(new SqlParameter("@assettype", assettype));
                    cmd.Parameters.Add(new SqlParameter("@condition", condition));
                    cmd.Parameters.Add(new SqlParameter("@notes", notes));
                    cmd.Parameters.Add(new SqlParameter("@assetnum", assetnum));
                    cmd.Parameters.Add(new SqlParameter("@appraisedby", appraisedby));

                }
                else
                {
                    cmd.CommandText = "AppraisalItemUpdate_Mobile";

                    cmd.Parameters.Add(new SqlParameter("@id", id1));
                    cmd.Parameters.Add(new SqlParameter("@projectid", projectid));
                    cmd.Parameters.Add(new SqlParameter("@locationid", locationid));
                    cmd.Parameters.Add(new SqlParameter("@mfg", mfg));
                    cmd.Parameters.Add(new SqlParameter("@model", model));
                    cmd.Parameters.Add(new SqlParameter("@year", year));
                    cmd.Parameters.Add(new SqlParameter("@serial", serial));
                    cmd.Parameters.Add(new SqlParameter("@value1a", value1a));
                    cmd.Parameters.Add(new SqlParameter("@value1t", value1t));
                    cmd.Parameters.Add(new SqlParameter("@value2a", value2a));
                    cmd.Parameters.Add(new SqlParameter("@value2t", value2t));
                    cmd.Parameters.Add(new SqlParameter("@quantity", quantity));
                    cmd.Parameters.Add(new SqlParameter("@description", description));
                    cmd.Parameters.Add(new SqlParameter("@capacity", capacity));
                    cmd.Parameters.Add(new SqlParameter("@assettype", assettype));
                    cmd.Parameters.Add(new SqlParameter("@condition", condition));
                    cmd.Parameters.Add(new SqlParameter("@notes", notes));
                    cmd.Parameters.Add(new SqlParameter("@assetnum", assetnum));
                    
                }
                

                



                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();
                appraisalitemslist = new List<AppraisalItemsInfo>();

                AppraisalItemsInfo a = new AppraisalItemsInfo();
                a.Id = "-1";
                a.Projectid = "-1";
                a.Locationid = "-1";
                a.Mfg = "true";
                a.Model ="";
                a.Year = "";
                a.Serial ="";
                a.Value1a = "";
                a.Value1t = "";
                a.Value2a = "";
                a.Value2t = "";
                a.Quantity = "";
                a.Description = "";
                a.Capacity = "";
                a.Assettype ="";
                a.Refno = "";
                a.Condition = "";
                a.Notes = "";
                a.Assetnum = "";
                a.Appraisedby = "";
                a.Appraisedate = "";
                a.Locationname = "";
                a.Appraidedbyfullname = "";
                appraisalitemslist.Add(a);

            }
            catch (Exception e2)
            {
                AppraisalItemsInfo a = new AppraisalItemsInfo();
                a.Id = "-1";
                a.Projectid = "-1";
                a.Locationid = "-1";
                a.Mfg = "false";
                a.Model = "";
                a.Year = "";
                a.Serial = "";
                a.Value1a = "";
                a.Value1t = "";
                a.Value2a = "";
                a.Value2t = "";
                a.Quantity = "";
                a.Description = "";
                a.Capacity = "";
                a.Assettype = "";
                a.Refno = "";
                a.Condition = "";
                a.Notes = e2.Message;
                a.Assetnum = "";
                a.Appraisedby = "";
                a.Appraisedate = "";
                a.Locationname = "";
                a.Appraidedbyfullname = "";
                appraisalitemslist.Add(a);
            }

            return appraisalitemslist;

        }

        // POST: api/AppraisalItems
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AppraisalItems/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AppraisalItems/5
        public void Delete(int id)
        {
        }
    }
}
