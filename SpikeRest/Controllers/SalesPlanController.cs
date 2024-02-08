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
    public class SalesPlanController : ApiController
    {
        private List<SalesPlan> thelist;
        // GET: api/SalesPlan
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SalesPlan/5
        public List<SalesPlan> Get(string search)
        {
            dsSalesPlan.SalesPlanMachine_SearchDataTable dt = new dsSalesPlan.SalesPlanMachine_SearchDataTable();
            SpikeRest.DAL.dsSalesPlanTableAdapters.SalesPlanMachine_SearchTableAdapter ta = new DAL.dsSalesPlanTableAdapters.SalesPlanMachine_SearchTableAdapter();
            thelist = new List<SalesPlan>();

            dt = ta.GetData(search);
            if (dt.Rows.Count > 0)
            {
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    SalesPlan s = new SalesPlan();
                    s.Id = dt[i].id.ToString();
                    s.Invno = dt[i].invno;
                    s.Mfg = dt[i].mfg;
                    s.Model = dt[i].model;
                    s.SamJvp = dt[i].sam_jvp;
                    s.Jvpdescription = dt[i].jvpdescription.Trim();
                    s.Serial = dt[i].serial;
                    s.Jvpinvno = dt[i].jvpinvno.Trim();
                    s.Machinedescription = dt[i].machinedescription.Trim();

                    //Alphabetical here down
                    s.Accountnumber = dt[i].accountnumber;

                    s.Addbyname = dt[i].AddByName;

                    s.Additionaldetails = dt[i].additionalDetails;

                    s.Agreeddate = dt[i].AgreedDate.ToShortDateString();

                    s.Checkauction = dt[i].checkbox_auction.ToString();
                    s.Checkprivate = dt[i].checkbox_private.ToString();
                    s.Checkother = dt[i].checkbox_other.ToString();

                    s.Commauction = dt[i].comm_auction.ToString("C0");
                    s.Commprivate = dt[i].comm_private.ToString("C0");
                    s.Commother = dt[i].comm_other.ToString("C0");


                    s.Comments = dt[i].Comments;

                    s.Condition = dt[i].Condition;

                    s.Conditionservice = dt[i].ConditionService;

                    s.Daystosellauction = dt[i].daystosell_auction.ToString();
                    s.Daystosellprivate = dt[i].daystosell_private.ToString();
                    s.Daystosellother = dt[i].daystosell_other.ToString();

                    s.Disposition = dt[i].Disposition.Trim();

                    s.Expensesauction = dt[i].expenses_auction.ToString("C0");
                    s.Expensesprivate = dt[i].expenses_private.ToString("C0");
                    s.Expensesother = dt[i].expenses_other.ToString("C0");

                    s.Fmvauction = dt[i].fmv_auction.ToString("C0");
                    s.Fmvprivate = dt[i].fmv_private.ToString("C0");
                    s.Fmvother = dt[i].fmv_other.ToString("C0");


                    s.Locationcode = dt[i].locationCode;

                    s.Locname = dt[i].locname.Trim();

                    s.Nbv = dt[i].nbv;
                    s.Originalpurchaseprice = dt[i].originalPurchasePrice;

                    s.Otherinfo = dt[i].OtherInfo;


                    s.Pmsapprovaldate = dt[i].PMSApprovalDate.ToShortDateString();
                    s.Pmsapprovalsentfor = dt[i].PMSApprovalSentFor.ToShortDateString();
                    s.Pmsapprovedbyname = dt[i].PMSApprovedByName;
                    s.Pmsapprovedflag = dt[i].PMSApprovedFlag.ToString();
                    s.Pmsdisapprovaldate = dt[i].PMSDisApprovalDate.ToShortDateString();


                    s.Repair = dt[i].Repair;
                    s.Responsiblesalesmanemail = dt[i].ResponsibleSalesmanEmail;
                    s.Returnauction = dt[i].return_auction.ToString("C0");
                    s.Returnprivate = dt[i].return_private.ToString("C0");
                    s.Returnother = dt[i].return_other.ToString("C0");

                    s.Situation = dt[i].situation;

                    s.Status = dt[i].status;

                    s.Surpluscontact = dt[i].surpluscontact;

                    s.Validfor = dt[i].validUntilDate.ToShortDateString();

                    s.Yrmfg = dt[i].yearofmfg;

                    thelist.Add(s);
                    i++;
                }
            }
            return thelist;
        }


        public List<SalesPlan> Get(string id,
            string userid,
            string To,
           string cc,
             string subject,
           string chosen)
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

            thelist = new List<SalesPlan>();
            SalesPlan s = new SalesPlan();

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = cnToUse;
                cn.Open();


                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SalesPlanApproveInsert_Mobile";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@salesplanid", Convert.ToInt32(@id)));
                cmd.Parameters.Add(new SqlParameter("@emailto", To));
                cmd.Parameters.Add(new SqlParameter("@emailcc", cc));
                cmd.Parameters.Add(new SqlParameter("@emailsubject", subject));
                cmd.Parameters.Add(new SqlParameter("@chosen", chosen));
                cmd.Parameters.Add(new SqlParameter("@addedby", userid));
              

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();
                result = "true";
                s.Id = "1";

            }
            catch (Exception e2)
            {
                s.Id = "0";
               
                result = "false: " + e2.Message;
            }


            s.Machinedescription = result;
            thelist.Add(s);

            return thelist;
        }
        // POST: api/SalesPlan
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SalesPlan/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SalesPlan/5
        public void Delete(int id)
        {
        }
    }
}
