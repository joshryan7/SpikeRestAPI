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
    public class EmployeeMaintController : ApiController
    {
        private List<EmployeeMaintInfo> employeemaintlist;

        // GET: api/EmployeeMaint
        public EmployeeMaintInfo Get()
        {
            return new EmployeeMaintInfo
            {
                Employeeid = "",
                Firstname = "",
                Lastname = "",
                Email = "",
                Email2 = "",
                Active = "",
                Activeforpricechange = "",
                Dateadded = "",
                Issalesman = "",
                Sendofferemail = "",
                Sendpricechangeemail = "",
                Sendbatchquoteemail = "",
                Sendcashreceivedemail = "",
                Sendadvertisingemail = "",
                Sendrequesttoaddmachine = "",
                Securitylevel = "",
                Isspanish = "",
                Canchangeprice = "",
                Cansendpricechangeemail = "",
                Canaddcustomers = "",
                Canaddinventory = "",
                Candeleteparts = "",
                Canremovefromoneliners = "",
                Canexcludeserial = "",
                Canupdatedealfields = "",
                Canacceptoffer = "",
                Isprocurement = "",
                Cantagsold = "",
                Canapprovesalesorder = "",
                Createtaskforsaleorderapproval = "",
                Canadddeletemachineplan = "",
                Canupdateinvcommission = "",
                Canapproveinvcommission = "",
                Worklocation = "",
                Usespecprintingutility = "",
                Isacounting = "",
                Password = "",
                Username = "",
                Passcode = "",
                Mobiletheme = ""

            };
        }

        // GET: api/EmployeeMaint/5
        public List<EmployeeMaintInfo> Get(string search)
        {
            int id = -1;
            try
            {
                int x = Convert.ToInt32(search);
                id = x;
            }
            catch
            {

            }

            dsEmployeeMaint.EmployeeSearchDataTable dt = new dsEmployeeMaint.EmployeeSearchDataTable();
            SpikeRest.DAL.dsEmployeeMaintTableAdapters.EmployeeSearchTableAdapter ta = new DAL.dsEmployeeMaintTableAdapters.EmployeeSearchTableAdapter();
            dt = ta.GetData(id, search);
            if (dt.Rows.Count > 0)
            {
                employeemaintlist = new List<EmployeeMaintInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    EmployeeMaintInfo e = new EmployeeMaintInfo();
                    e.Employeeid = dt[i].employeeid.ToString();
                    e.Firstname = dt[i].FirstName;
                    e.Lastname = dt[i].LastName;
                    e.Email = dt[i].email;
                    e.Email2 = dt[i].email2;
                    e.Active = dt[i].active.ToString();
                    e.Activeforpricechange = dt[i].activeForPriceChange.ToString();
                    e.Dateadded = dt[i].DateAdded.ToShortDateString();
                    e.Issalesman = dt[i].IsSalesMan.ToString();
                    e.Sendofferemail = dt[i].SendOfferEmail.ToString();
                    e.Sendpricechangeemail = dt[i].sendpricechangeemail.ToString();
                    e.Sendbatchquoteemail = dt[i].sendbatchquoteemail.ToString();
                    e.Sendcashreceivedemail = dt[i].SendCashReceivedEmail.ToString();
                    e.Sendadvertisingemail = dt[i].SendAdvertisingEmail.ToString();
                    e.Sendrequesttoaddmachine = dt[i].SendRequestToAddMachine.ToString();
                    e.Securitylevel = dt[i].Security_level.ToString();
                    e.Isspanish = dt[i].isSpanish.ToString();
                    e.Canchangeprice = dt[i].CanChangePrice.ToString();
                    e.Cansendpricechangeemail = dt[i].CanSendPriceChangeEmail.ToString();
                    e.Canaddcustomers = dt[i].CanAddCustomers.ToString();
                    e.Canaddinventory = dt[i].CanAddInventory.ToString();
                    e.Candeleteparts = dt[i].CanDeleteParts.ToString();
                    e.Canremovefromoneliners = dt[i].CanRemoveFromOneLiners.ToString();
                    e.Canexcludeserial = dt[i].CanExcludeSerial.ToString();
                    e.Canupdatedealfields = dt[i].CanUpdateDealFields.ToString();
                    e.Canacceptoffer = dt[i].CanAcceptOffer.ToString();
                    e.Isprocurement = dt[i].isProcurement.ToString(); ;
                    e.Cantagsold = dt[i].CanTagSold.ToString();
                    e.Canapprovesalesorder = dt[i].CanApproveSalesOrder.ToString();
                    e.Createtaskforsaleorderapproval = dt[i].CreateTaskForSaleOrderApproval.ToString();
                    e.Canadddeletemachineplan = dt[i].CanAddDeleteMachinePlan.ToString();
                    e.Canupdateinvcommission = dt[i].CanUpdateInvCommissions.ToString();
                    e.Canapproveinvcommission = dt[i].CanApproveInvCommissions.ToString();
                    e.Worklocation = dt[i].WorkLocation;
                    e.Usespecprintingutility = dt[i].useSpecPrintingUtility.ToString();
                    e.Isacounting = dt[i].isAccounting.ToString();
                    e.Password = dt[i].password.ToString();
                    e.Username = dt[i].username.ToString();
                    e.Passcode = dt[i].passcode.ToString();
                    e.Mobiletheme = dt[i].mobiletheme;

                    employeemaintlist.Add(e);
                    i++;
                }
            }
            return employeemaintlist;
        }

        ////Update
        //public EmployeeMaintInfo Get(
        //    string employeeid, string firstname, string lastname,
        //    string email, string email2, string username,
        //    string password, string passcode, string active,
        //    string accounting, string procurement, string salesman,
        //    string securitylevel, string addcustomers, string addinventory,
        //    string updatedealfields, string tagsold, string excludeserial,
        //    string deleteparts, string adddeletemachineplan, string removefromoneliners,
        //    string changeprice, string cansendpricechangeemail, string acceptoffer,
        //    string approveinvcommissions, string updateinvcommissions, string createtasks,
        //    string sendoffer, string sendpricechange, string sendbatchquote,
        //    string sendcashrecieved, string sendadvertising, string sendrequesttoaddmachine,
        //    string spanish, string activeforpricechange, string usesepcutility, string mobiletheme
        //    )
        public EmployeeMaintInfo Get(
           string employeeid, string firstname, string lastname, string email, string email2,
           string username, string password, string passcode, string active, string mobiletheme,
           string accounting, string procurement, string salesman, string securitylevel, string addcustomers,
           string addinventory, string updatedealfields, string tagsold, string excludeserial, string deleteparts, string adddeletemachineplan,
           string removefromoneliners, string changeprice,
           string cansendpricechangeemail,
           string acceptoffer, string approveinvcommissions, string updateinvcommissions, string approvesalesorder,
           string createtasks, string sendoffer, string sendpricechange, string sendbatchquote, string sendcashrecieved,
           string sendadvertising, string sendrequesttoaddmachine, string spanish, string activeforpricechange, string usespecprintingutility

           //string adddeletemachineplan
           //string changeprice, string cansendpricechangeemail
           //string acceptoffer, string approveinvcommissions, string updateinvcommissions, string approvesalesorder,
           //string createtasks, string sendoffer, string sendpricechange, string sendbatchquote, string sendcashrecieved,
           //string sendadvertising, string sendrequesttoaddmachine, string spanish, string activeforpricechange, string usespecprintingutility

           )
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

            try
            {

                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = cnToUse;
                cn.Open();



                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Employee_UpdateMobile";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@employeeid", employeeid));
                cmd.Parameters.Add(new SqlParameter("@firstname", firstname));
                cmd.Parameters.Add(new SqlParameter("@lastname", lastname));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@email2", email2));
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                cmd.Parameters.Add(new SqlParameter("@passcode", passcode));
                cmd.Parameters.Add(new SqlParameter("@active", active));
                cmd.Parameters.Add(new SqlParameter("@mobiletheme", mobiletheme));
                cmd.Parameters.Add(new SqlParameter("@accounting", accounting));
                cmd.Parameters.Add(new SqlParameter("@procurement", procurement));
                cmd.Parameters.Add(new SqlParameter("@salesman", salesman));
                cmd.Parameters.Add(new SqlParameter("@securitylevel", securitylevel));
                cmd.Parameters.Add(new SqlParameter("@activeforpricechange", activeforpricechange));
                cmd.Parameters.Add(new SqlParameter("@sendofferemail", sendoffer));
                cmd.Parameters.Add(new SqlParameter("@sendpricechangeemail", sendpricechange));
                cmd.Parameters.Add(new SqlParameter("@sendbatchquoteemail", sendbatchquote));
                cmd.Parameters.Add(new SqlParameter("@sendcashreceivedemail", sendcashrecieved));
                cmd.Parameters.Add(new SqlParameter("@sendadvertisingemail", sendadvertising));
                cmd.Parameters.Add(new SqlParameter("@sendrequesttoaddmachine", sendrequesttoaddmachine));
                cmd.Parameters.Add(new SqlParameter("@isspanish", spanish));
                cmd.Parameters.Add(new SqlParameter("@CanChangePrice", changeprice));
                cmd.Parameters.Add(new SqlParameter("@CanSendPriceChangeEmail", cansendpricechangeemail));
                cmd.Parameters.Add(new SqlParameter("@canaddcustomers", addcustomers));
                cmd.Parameters.Add(new SqlParameter("@canaddinventory", addinventory));
                cmd.Parameters.Add(new SqlParameter("@candeleteparts", deleteparts));
                cmd.Parameters.Add(new SqlParameter("@CanRemoveFromOneLiners", removefromoneliners));
                cmd.Parameters.Add(new SqlParameter("@canexcludeserial", excludeserial));
                cmd.Parameters.Add(new SqlParameter("@canupdatedealfields", updatedealfields));
                cmd.Parameters.Add(new SqlParameter("@canacceptoffer", acceptoffer));
                cmd.Parameters.Add(new SqlParameter("@cantagsold", tagsold));
                cmd.Parameters.Add(new SqlParameter("@canapprovesalesorder", approvesalesorder));
                cmd.Parameters.Add(new SqlParameter("@createtaskforsaleorderapproval", createtasks));
                cmd.Parameters.Add(new SqlParameter("@CanAddDeleteMachinePlan", adddeletemachineplan));
                cmd.Parameters.Add(new SqlParameter("@canupdateinvcommissions", updateinvcommissions));
                cmd.Parameters.Add(new SqlParameter("@canapproveinvcommissions", approveinvcommissions));
                cmd.Parameters.Add(new SqlParameter("@usespecprintingutility", usespecprintingutility));

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                return new EmployeeMaintInfo
                {
                    Employeeid = "",
                    Firstname = "",
                    Lastname = "",
                    Email = "",
                    Email2 = "",
                    Active = "",
                    Activeforpricechange = "",
                    Dateadded = "",
                    Issalesman = "",
                    Sendofferemail = "",
                    Sendpricechangeemail = "",
                    Sendbatchquoteemail = "",
                    Sendcashreceivedemail = "",
                    Sendadvertisingemail = "",
                    Sendrequesttoaddmachine = "",
                    Securitylevel = "",
                    Isspanish = "",
                    Canchangeprice = "",
                    Cansendpricechangeemail = "",
                    Canaddcustomers = "",
                    Canaddinventory = "",
                    Candeleteparts = "",
                    Canremovefromoneliners = "",
                    Canexcludeserial = "",
                    Canupdatedealfields = "",
                    Canacceptoffer = "",
                    Isprocurement = "",
                    Cantagsold = "",
                    Canapprovesalesorder = "",
                    Createtaskforsaleorderapproval = "",
                    Canadddeletemachineplan = "",
                    Canupdateinvcommission = "",
                    Canapproveinvcommission = "",
                    Worklocation = "",
                    Usespecprintingutility = "",
                    Isacounting = "",
                    Password = "",
                    Username = "",
                    Passcode = "",
                    Mobiletheme = ""
                };
            }
            catch (Exception e2)
            {
                return new EmployeeMaintInfo
                {
                    Employeeid = "",
                    Firstname = e2.Message,
                    Lastname = "",
                    Email = "",
                    Email2 = "",
                    Active = "",
                    Activeforpricechange = "",
                    Dateadded = "",
                    Issalesman = "",
                    Sendofferemail = "",
                    Sendpricechangeemail = "",
                    Sendbatchquoteemail = "",
                    Sendcashreceivedemail = "",
                    Sendadvertisingemail = "",
                    Sendrequesttoaddmachine = "",
                    Securitylevel = "",
                    Isspanish = "",
                    Canchangeprice = "",
                    Cansendpricechangeemail = "",
                    Canaddcustomers = "",
                    Canaddinventory = "",
                    Candeleteparts = "",
                    Canremovefromoneliners = "",
                    Canexcludeserial = "",
                    Canupdatedealfields = "",
                    Canacceptoffer = "",
                    Isprocurement = "",
                    Cantagsold = "",
                    Canapprovesalesorder = "",
                    Createtaskforsaleorderapproval = "",
                    Canadddeletemachineplan = "",
                    Canupdateinvcommission = "",
                    Canapproveinvcommission = "",
                    Worklocation = "",
                    Usespecprintingutility = "",
                    Isacounting = "",
                    Password = "",
                    Username = "",
                    Passcode = "",
                    Mobiletheme = ""
                };
            }
        }
           


        // POST: api/EmployeeMaint
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EmployeeMaint/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EmployeeMaint/5
        public void Delete(int id)
        {
        }
    }
}
