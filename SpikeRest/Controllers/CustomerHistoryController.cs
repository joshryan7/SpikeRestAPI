using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpikeRest.Models;
using SpikeRest.DAL;

namespace SpikeRest.Controllers
{
    public class CustomerHistoryController : ApiController
    {
        private List<CustomerHistoryInfo> customerhistorylist;
        //dsCustomerHistory.HistoryCustomerSelect_MobileDataTable dt = new dsCustomerHistory.HistoryCustomerSelect_MobileDataTable();

        // GET: api/CustomerHistory
        public CustomerHistoryInfo Get()
        {
            return new CustomerHistoryInfo
            {
                Cstno = "",
                Transtype = "",
                Trans2type = "",
                Transtime = "",
                Thekey = "",
                Transdate = "",
                Sls = "",
                Fullname = "",
                Invno = "",
                Userprice = "",
                Retail = "",
                Udf1 = "",
                Apptime = "",
                Mfg = "",
                Model = "",
                Note = "",
                Displaynote = "",
                Emailaddress = "",
                Emailsubject = ""      
            };

        }

        // GET: api/CustomerHistory/5
       // public List<CustomerHistoryInfo> Get(string cstno, DateTime startdate, DateTime enddate, bool GetSales, bool GetQuotes, bool GetOffers, bool GetNotes, bool GetAppointments, bool GetCalls, bool GetEmails)
                   // public List<CustomerHistoryInfo> Get(string cstno, DateTime startdate, DateTime enddate, string GetSales, string GetQuotes, string GetOffers, string GetNotes, string GetAppointments, string GetCalls, string GetEmails)
             public List<CustomerHistoryInfo> Get(string cstno, DateTime startdate, DateTime enddate)

        {
            dsCustomerHistory.HistoryCustomerSelect_MobileDataTable dt = new dsCustomerHistory.HistoryCustomerSelect_MobileDataTable();
            SpikeRest.DAL.dsCustomerHistoryTableAdapters.HistoryCustomerSelect_MobileTableAdapter ta = new DAL.dsCustomerHistoryTableAdapters.HistoryCustomerSelect_MobileTableAdapter();
            customerhistorylist = new List<CustomerHistoryInfo>();

            enddate = enddate.AddDays(1);

            dt = ta.GetData(cstno, startdate, enddate, true, true, true, true, true, true, true);
            if (dt.Rows.Count > 0)
            {
                customerhistorylist = new List<CustomerHistoryInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    CustomerHistoryInfo d = new CustomerHistoryInfo();

                    d.Cstno = dt[i].cstno;
                    d.Transtype = dt[i].transtype;
                    d.Trans2type = dt[i].trans2type;
                    d.Transtime = dt[i].transtime.ToString();
                    d.Thekey = dt[i].thekey.ToString();
                    d.Transdate = dt[i].transdate.ToShortDateString();
                    d.Sls = dt[i].SLS;
                    d.Fullname = dt[i].fullname;
                    d.Invno = dt[i].invno;
                    d.Userprice = dt[i].userprice.ToString("C0");
                    d.Retail = dt[i].retail.ToString("C0");
                    d.Udf1 = dt[i].udf1;
                    d.Apptime = dt[i].appttime;
                    d.Mfg = dt[i].mfg;
                    d.Model = dt[i].model;
                    d.Note = dt[i].note;
                    d.Displaynote = dt[i].DisplayNote;
                    d.Emailaddress = dt[i].EMAILADDRESS;
                    d.Emailsubject = dt[i].EMAILSUBJECT;


                    customerhistorylist.Add(d);
                    i++;
                }
            }

            return customerhistorylist;

        }

        // POST: api/CustomerHistory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CustomerHistory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomerHistory/5
        public void Delete(int id)
        {
        }
    }
}
