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
    public class CommissionsPreController : ApiController
    {
        private List<CommissionsPreInfo> commisionsprelist;

        // GET: api/CommissionsPre
        public CommissionsPreInfo Get()
        {
            return new CommissionsPreInfo
            {
                Id = "",
                Commpaidtoid = "",
                Commpaidtoname = "",
                Commmonth = "",
                Commyear = "",
                Invno = "",
                Basisamount = "",
                Commamount = "",
                Basisamounttype = "",
                Commtype = "",
                Proactive = "",
                Comment = "",
                Dateadded = "",
                Addedbyid = "",
                Addedbyname = "",
                Datemodified = "",
                Modifiedbyid = "",
                Modifiedbyname = "",
                Commdate = "",
                Pifdate = "",
                Shipdate = "",
                Jvpandpercentage = "",
                Invoicedate = "",
                Descript = "",
                Totalcommamount = ""
            };
        }

        // GET: api/CommissionsPre/5
        public List<CommissionsPreInfo> Get(int userid, string themonth, string theyear)
        {

            dsCommissionsPre.CommissionsSelectPre_mobileDataTable dt = new dsCommissionsPre.CommissionsSelectPre_mobileDataTable();
            SpikeRest.DAL.dsCommissionsPreTableAdapters.CommissionsSelectPre_mobileTableAdapter ta = new DAL.dsCommissionsPreTableAdapters.CommissionsSelectPre_mobileTableAdapter();

            dt = ta.GetData(userid, themonth, theyear);
            if (dt.Rows.Count > 0)
            {
                commisionsprelist = new List<CommissionsPreInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    CommissionsPreInfo c = new CommissionsPreInfo();
                    c.Id = dt[i].id.ToString();
                    c.Commpaidtoid = dt[i].commPaidToid.ToString();
                    c.Commpaidtoname = dt[i].CommPaidToName;
                    c.Commmonth = dt[i].commMonth;
                    c.Commyear = dt[i].commYear;
                    c.Invno = dt[i].invno;
                    c.Basisamount = dt[i].basisamount.ToString("C2");
                    c.Commamount = dt[i].commamount.ToString("C2");
                    c.Basisamounttype = dt[i].basisAmountType;
                    c.Commtype = dt[i].commType;
                    c.Proactive = dt[i].ProActive.ToString();
                    c.Comment = dt[i].comment;
                    c.Dateadded = dt[i].dateadded.ToShortDateString();
                    c.Addedbyid = dt[i].addedbyid.ToString();
                    c.Addedbyname = dt[i].addbyName;
                    c.Datemodified = dt[i].datemodified;
                    c.Modifiedbyid = dt[i].modifiedbyid.ToString();
                    c.Commdate = dt[i].commDate;
                    c.Pifdate = dt[i].PIFDate;
                    c.Shipdate = dt[i].ShipDate;
                    c.Jvpandpercentage = dt[i].JVPandPercentage;
                    c.Invoicedate = dt[i].InvoiceDate;
                    c.Descript = dt[i].descript;
                    c.Totalcommamount = dt[i].TotalCommAmount.ToString("C2");

                    commisionsprelist.Add(c);
                    i++;
                }
            }
            return commisionsprelist;
        }

        // POST: api/CommissionsPre
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CommissionsPre/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CommissionsPre/5
        public void Delete(int id)
        {
        }
    }
}
