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
    public class SpikeLoginController : ApiController
    {
        private List<SpikeLoginInfo> loginlist;
        // GET: api/SpikeLogin
        public SpikeLoginInfo Get()
        {
            return new SpikeLoginInfo
            {
                Userid = "",
                Firstname = "",
                Lastname = "",
                Email = "",
                Issalesman = "",
                Securitylevel = "",
                Canchangeprice = "",
                Canaddinventory = "",
                Canupdatedealfields = "",
                Cantagsold = "",
                Isaccounting = "",
                Mobiletheme = ""
            };
        }

        // GET: api/SpikeLogin/5
        public List<SpikeLoginInfo> Get(string password)
        {
            dsSpikeLogin.UsersSelectLogin_MobileDataTable dt = new dsSpikeLogin.UsersSelectLogin_MobileDataTable();
            SpikeRest.DAL.dsSpikeLoginTableAdapters.UsersSelectLogin_MobileTableAdapter ta = new DAL.dsSpikeLoginTableAdapters.UsersSelectLogin_MobileTableAdapter();

            dt = ta.GetData(password, "iOS","");
            if (dt.Rows.Count > 0)
            {
                loginlist = new List<SpikeLoginInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    SpikeLoginInfo l = new SpikeLoginInfo();
                    l.Userid = dt[i].USERID.ToString();
                    l.Firstname = dt[i].FIRSTNAME;
                    l.Lastname = dt[i].LASTNAME;
                    l.Email = dt[i].EMAIL;
                    l.Issalesman = dt[i].ISSALESMAN.ToString();
                    l.Securitylevel = dt[i].SECURITY_LEVEL.ToString();
                    l.Canchangeprice = dt[i].CanChangePrice.ToString();
                    l.Canaddinventory = dt[i].CanAddInventory.ToString();
                    l.Canupdatedealfields = dt[i].CanUpdateDealFields.ToString();
                    l.Cantagsold = dt[i].CanTagSold.ToString();
                    l.Isaccounting = dt[i].isaccounting.ToString();
                    l.Mobiletheme = dt[i].mobiletheme;

                    loginlist.Add(l);
                    i++;

                }
            }
            return loginlist;

        }

        // GET: api/SpikeLogin/5
        public List<SpikeLoginInfo> Get(string password, string OS)
        {
            dsSpikeLogin.UsersSelectLogin_MobileDataTable dt = new dsSpikeLogin.UsersSelectLogin_MobileDataTable();
            SpikeRest.DAL.dsSpikeLoginTableAdapters.UsersSelectLogin_MobileTableAdapter ta = new DAL.dsSpikeLoginTableAdapters.UsersSelectLogin_MobileTableAdapter();

            dt = ta.GetData(password, OS,"");
            if(dt.Rows.Count > 0)
            {
                loginlist = new List<SpikeLoginInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    SpikeLoginInfo l = new SpikeLoginInfo();
                    l.Userid = dt[i].USERID.ToString();
                    l.Firstname = dt[i].FIRSTNAME;
                    l.Lastname = dt[i].LASTNAME;
                    l.Email = dt[i].EMAIL;
                    l.Issalesman = dt[i].ISSALESMAN.ToString();
                    l.Securitylevel = dt[i].SECURITY_LEVEL.ToString();
                    l.Canchangeprice = dt[i].CanChangePrice.ToString();
                    l.Canaddinventory = dt[i].CanAddInventory.ToString();
                    l.Canupdatedealfields = dt[i].CanUpdateDealFields.ToString();
                    l.Cantagsold = dt[i].CanTagSold.ToString();
                    l.Isaccounting = dt[i].isaccounting.ToString();
                    l.Mobiletheme = dt[i].mobiletheme;
                    loginlist.Add(l);
                    i++;

                }
            }
            return loginlist;

        }

        public List<SpikeLoginInfo> Get(string password, string OS, string userid)
        {
            dsSpikeLogin.UsersSelectLogin_MobileDataTable dt = new dsSpikeLogin.UsersSelectLogin_MobileDataTable();
            SpikeRest.DAL.dsSpikeLoginTableAdapters.UsersSelectLogin_MobileTableAdapter ta = new DAL.dsSpikeLoginTableAdapters.UsersSelectLogin_MobileTableAdapter();

            dt = ta.GetData(password, OS, userid);
            if (dt.Rows.Count > 0)
            {
                loginlist = new List<SpikeLoginInfo>();
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    SpikeLoginInfo l = new SpikeLoginInfo();
                    l.Userid = dt[i].USERID.ToString();
                    l.Firstname = dt[i].FIRSTNAME;
                    l.Lastname = dt[i].LASTNAME;
                    l.Email = dt[i].EMAIL;
                    l.Issalesman = dt[i].ISSALESMAN.ToString();
                    l.Securitylevel = dt[i].SECURITY_LEVEL.ToString();
                    l.Canchangeprice = dt[i].CanChangePrice.ToString();
                    l.Canaddinventory = dt[i].CanAddInventory.ToString();
                    l.Canupdatedealfields = dt[i].CanUpdateDealFields.ToString();
                    l.Cantagsold = dt[i].CanTagSold.ToString();
                    l.Isaccounting = dt[i].isaccounting.ToString();
                    l.Mobiletheme = dt[i].mobiletheme;
                    loginlist.Add(l);
                    i++;

                }
            }
            return loginlist;

        }

        public SpikeLoginInfo Get(int userid, string mobiletheme)
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
                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = cnToUse;
                cn.Open();


                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateUserTheme_Mobile";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@userid", userid));
                cmd.Parameters.Add(new SqlParameter("@mobiletheme", mobiletheme));
               

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();
                result = "true";

            }
            catch (Exception e2)
            {
                result = "false: " + e2.Message;
            }

            return new SpikeLoginInfo
            {
                Userid = "",
                Firstname = result,
                Lastname = "",
                Email = "",
                Issalesman = "",
                Securitylevel = "",
                Canchangeprice = "",
                Canaddinventory = "",
                Canupdatedealfields = "",
                Cantagsold = "",
                Isaccounting = "",
                Mobiletheme = ""
            };
        }

        // POST: api/SpikeLogin
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SpikeLogin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SpikeLogin/5
        public void Delete(int id)
        {
        }
    }
}
