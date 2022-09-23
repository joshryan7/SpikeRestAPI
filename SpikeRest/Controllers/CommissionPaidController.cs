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
    public class CommissionPaidController : ApiController
    {
        private List<CommissionPaid> commissionlist;

        // GET: api/CommissionPaid
        public CommissionPaid Get()
        {
            return new CommissionPaid
            {
                Id = "",
                Commpaidtoid = "",
                Commpaidtoname = "",
                Commmonth = "",
                Commyear = "",
                Invno = "",
                Commamount = "",
                Commtype = "",
                Comment = "",
                Dateapproved = ""
            };
        }

        // GET: api/CommissionPaid/5
        public List<CommissionPaid> Get(string invno)
        {
            
            dsCommissionPaid.CommissionsSelectMobileDataTable dt = new dsCommissionPaid.CommissionsSelectMobileDataTable();
            SpikeRest.DAL.dsCommissionPaidTableAdapters.CommissionsSelectMobileTableAdapter ta = new DAL.dsCommissionPaidTableAdapters.CommissionsSelectMobileTableAdapter();

            dt = ta.GetData("","","","",invno);
            if (dt.Rows.Count > 0)
            {
                commissionlist = new List<CommissionPaid>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    CommissionPaid c = new CommissionPaid();
                    c.Id = dt[i].id.ToString();
                    c.Commpaidtoid = dt[i].commPaidToid.ToString();
                    c.Commpaidtoname = dt[i].CommPaidToName;
                    c.Commmonth = dt[i].commMonth;
                    c.Commyear = dt[i].commYear;
                    c.Invno = dt[i].invno;
                    c.Commamount = dt[i].commAmount.ToString("C2");
                    c.Commtype = dt[i].commType;
                    c.Comment = dt[i].comment;
                    c.Dateapproved = dt[i].DateApproved.ToShortDateString();


                    commissionlist.Add(c);
                    i++;
                }
            }
            return commissionlist;
        }

        // POST: api/CommissionPaid
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CommissionPaid/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CommissionPaid/5
        public void Delete(int id)
        {
        }
    }
}
