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


namespace SpikeRest.Controllers
{
    public class SamRegistrationController : ApiController
    {
        private List<UserInfo> userList;
        // GET: api/SamRegistration
        public List<UserInfo> Get()
        {
            userList = new List<UserInfo>();

            UserInfo i = new UserInfo();
            i.Vendorid = 0.ToString();
            i.FirstName = "Test FirstName";
            i.LastName = "Test LastName";
            i.Workaddress = "";
            i.Phone = "";
            i.Email = "";
            i.Lastinvno = "";
            i.Username = "";
            i.Addanasset = "false";

            userList.Add(i);

            return userList;
        }

        // GET: api/SamRegistration/5
        public UserInfo Get(string fn,
            string ln,
            string em,
            string ph,
            string pw,
            string wa
            )
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            string cnToUse = "";

            try
            {
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
                cmd.CommandText = "SAMRegistrationRequest_Insert";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@firstName", fn));
                cmd.Parameters.Add(new SqlParameter("@lastname", ln));
                cmd.Parameters.Add(new SqlParameter("@email", em));
                cmd.Parameters.Add(new SqlParameter("@phone", ph));
                cmd.Parameters.Add(new SqlParameter("@pwd", pw));
                cmd.Parameters.Add(new SqlParameter("@workAddress", wa));

                string qresult = cmd.ExecuteScalar().ToString();
                string validationCode = "";

                if (qresult.Contains("success:"))
                {
                    validationCode = qresult.Substring(8).Trim();
                }

                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                return new UserInfo
                {
                    Vendorid = "-1",
                    FirstName = qresult,
                    LastName = validationCode,
                    Username = em,
                    Phone = ph,
                    Email = em,
                    Lastinvno = "",
                    Workaddress = wa,
                    Addanasset = ""
                };
            }
            catch { }
        

            return new UserInfo
            {
                Vendorid = "-1",
                FirstName = "",
                LastName = "",
                Workaddress = "",
                Phone = "",
                Email = "",
                Lastinvno = "",
                Username = "",
                Addanasset = "false"
            };

        }


        // validate the email + validation code combination,
        // if valid this method will create the int_users record both on our CRM database and on the it_users database

        public UserInfo Get(string em,
            string vc
            )
        {
            string result = "";
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            string cnToUse = "";

            try
            {
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
                cmd.CommandText = "SAMRegistrationValidation";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@email", em));
                cmd.Parameters.Add(new SqlParameter("@validationcode", vc));

                string qresult = cmd.ExecuteScalar().ToString();
                string validationCode = "";

                if (qresult.Contains("success"))
                {
                    // create the user record on table int_users on the website database, this way the user can login on SAM on the website
                    // first grab the user record information that was just created on our CRM database
                    SpikeRest.DAL.dsUser.UsersSAMSelectLoginDataTable dt = new dsUser.UsersSAMSelectLoginDataTable();
                    SpikeRest.DAL.dsUserTableAdapters.UsersSAMSelectLoginTableAdapter ta = new DAL.dsUserTableAdapters.UsersSAMSelectLoginTableAdapter();

                    dt = ta.GetDataByUsername(em);

                    if(dt.Rows.Count > 0)
                    {
                        // now add the record to the American Eagle / website database table int_users
                        try
                        {
                            this.AddUsertoWebsite(dt[0]);
                            qresult = "success";
                        }
                        catch(Exception e2)
                        {
                            qresult = "fail "+e2.Message;
                        }
                    }


                }

                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                return new UserInfo
                {
                    Vendorid = "-1",
                    FirstName = qresult,
                    LastName = "",
                    Username = em,
                    Phone = "",
                    Email = em,
                    Lastinvno = "",
                    Workaddress = "",
                    Addanasset = ""
                };
            }
            catch { }


            return new UserInfo
            {
                Vendorid = "-1",
                FirstName = "",
                LastName = "",
                Workaddress = "",
                Phone = "",
                Email = "",
                Lastinvno = "",
                Username = "",
                Addanasset = "false"
            };

        }

        private bool AddUsertoWebsite(SpikeRest.DAL.dsUser.UsersSAMSelectLoginRow u)
        { 
            string americaneaglestring = "Data Source=172.25.37.19;Initial Catalog=Perfectionmachinery_vpn;User ID=pmvpnuser;Password=J3Niw(vk";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = americaneaglestring;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "int_users_insert";  // this sp will also perform an update if the record already exists

            
            cn.Open();  // open the connection to the database

            cmd.Parameters.Add(new SqlParameter("@username", u.username));
            cmd.Parameters.Add(new SqlParameter("@useremail", u.useremail));
            cmd.Parameters.Add(new SqlParameter("@firstname", u.firstname));
            cmd.Parameters.Add(new SqlParameter("@lastname", u.lastname));
            cmd.Parameters.Add(new SqlParameter("@vendorid", u.vendorid));
            cmd.Parameters.Add(new SqlParameter("@password", u.pwd));
            cmd.Parameters.Add(new SqlParameter("@locationid", 0));
            cmd.Parameters.Add(new SqlParameter("@phone", u.phone));
            cmd.Parameters.Add(new SqlParameter("@addamachine", u.addamachine));
            cmd.Parameters.Add(new SqlParameter("@isenabled", true));
            cmd.Parameters.Add(new SqlParameter("@workaddress", u.workaddress));

            int nrows1 = Convert.ToInt32(cmd.ExecuteScalar());

            cn.Close();
            cn.Dispose();
            cmd.Dispose();

            return true;
        }

        // POST: api/SamRegistration
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SamRegistration/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SamRegistration/5
        public void Delete(int id)
        {
        }
    }
}
