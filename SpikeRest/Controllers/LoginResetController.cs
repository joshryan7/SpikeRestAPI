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
    public class LoginResetController : ApiController
    {
        private List<UserInfo> userList;
        // GET: api/LoginReset
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


        // call this method to request a password reset
        public UserInfo Get(string useremail)
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
                cmd.CommandText = "PasswordResetRequest_Insert";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@useremail", useremail));

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                // get the user's record to return to the SAM app, as it uses the info for
                // validation
                dsUser.UsersSAMSelectLoginDataTable dt = new dsUser.UsersSAMSelectLoginDataTable();
                SpikeRest.DAL.dsUserTableAdapters.UsersSAMSelectLoginTableAdapter ta = new DAL.dsUserTableAdapters.UsersSAMSelectLoginTableAdapter();


                dt = ta.GetDataByUsername(useremail);
                if (dt.Rows.Count > 0)
                {
                    return new UserInfo
                    {
                        Vendorid = dt[0].vendorid.ToString(),
                        FirstName = dt[0].firstname,
                        LastName = dt[0].lastname,
                        Username = dt[0].username,
                        Phone = dt[0].phone,
                        Email = dt[0].useremail,
                        Lastinvno = dt[0].lastinvno,
                        Workaddress = dt[0].workaddress,
                        Addanasset = dt[0].addamachine.ToString()
                    };
                }
            }
            catch
            {
                
            }

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


        // call this method to validate the reset code
        public UserInfo Get(string useremail, string vcode)
        {
            dsUser.UsersSAMSelectLoginDataTable dt = new dsUser.UsersSAMSelectLoginDataTable();
            SpikeRest.DAL.dsUserTableAdapters.UsersSAMSelectLoginTableAdapter ta = new DAL.dsUserTableAdapters.UsersSAMSelectLoginTableAdapter();


            dt = ta.GetDataByCode(useremail, vcode);
            if (dt.Rows.Count == 1)
            {
                return new UserInfo
                {
                    Vendorid = dt[0].vendorid.ToString(),
                    FirstName = dt[0].firstname,
                    LastName = dt[0].lastname,
                    Username = dt[0].username,
                    Phone = dt[0].phone,
                    Email = dt[0].useremail,
                    Lastinvno = dt[0].lastinvno,
                    Workaddress = dt[0].workaddress,
                    Addanasset = dt[0].addamachine.ToString()

                };
            }
            else
            {
                return new UserInfo
                {
                    Vendorid = "-1",
                    FirstName = "",
                    LastName = "",
                    Username = "",
                    Phone = "",
                    Email = "",
                    Lastinvno = "",
                    Workaddress = "",
                    Addanasset = ""

                };
            }
        }

        public UserInfo Get(string useremail, string np , string vcode)
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            string pglConnection = "";
            string webConnection = "";

            string qresultpgl = "";
            string qresultWeb = "";
            

            try
            {
                foreach (ConnectionStringSettings connection in connectionStrings)
                {
                    if (connection.Name == "CRMConnectionString")
                    {
                        pglConnection = connection.ConnectionString;
                    }
                    else if (connection.Name == "WEBConnectionString")
                    {
                        webConnection = connection.ConnectionString;
                    }
                }

                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = pglConnection;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PasswordSAM_Update";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@useremail", useremail));
                cmd.Parameters.Add(new SqlParameter("@newpassword", np));
                cmd.Parameters.Add(new SqlParameter("@validationcode", vcode));

                qresultpgl = cmd.ExecuteScalar().ToString();
                if (qresultpgl == "1")
                {
                    qresultpgl = "success";
                }

                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                // Update the website int_users too.
                if (qresultpgl == "success")
                {

                    SqlCommand cmdWeb = new SqlCommand();
                    SqlConnection cnWeb = new SqlConnection();
                    cnWeb.ConnectionString = webConnection;
                    cnWeb.Open();

                    cmdWeb.Connection = cnWeb;
                    cmdWeb.CommandType = CommandType.StoredProcedure;
                    cmdWeb.CommandText = "PasswordSAM_Update";
                    cmdWeb.Parameters.Clear();

                    /* However, the website database is not aware of the validation code, thus we use this special code 8675309 so that the update works
                     */

                    cmdWeb.Parameters.Add(new SqlParameter("@useremail", useremail));
                    cmdWeb.Parameters.Add(new SqlParameter("@newpassword", np));
                    cmdWeb.Parameters.Add(new SqlParameter("@validationcode", "8675309"));

                    qresultWeb = cmdWeb.ExecuteScalar().ToString();
                    if (qresultWeb == "1")
                    {
                        qresultWeb = "success";
                    }

                    cmdWeb.Dispose();
                    cnWeb.Close();
                    cnWeb.Dispose();
                }

                // get the user's record to return to the SAM app, as it uses the info for
                // validation
                dsUser.UsersSAMSelectLoginDataTable dt = new dsUser.UsersSAMSelectLoginDataTable();
                SpikeRest.DAL.dsUserTableAdapters.UsersSAMSelectLoginTableAdapter ta = new DAL.dsUserTableAdapters.UsersSAMSelectLoginTableAdapter();


                dt = ta.GetDataByUsername(useremail);
                if (dt.Rows.Count > 0)
                {
                    return new UserInfo
                    {
                        Vendorid = dt[0].vendorid.ToString(),
                        FirstName = dt[0].firstname,
                        LastName = dt[0].lastname,
                        Username = dt[0].username,
                        Phone = dt[0].phone,
                        Email = dt[0].useremail,
                        Lastinvno = dt[0].lastinvno,
                        Workaddress = dt[0].workaddress,
                        Addanasset = dt[0].addamachine.ToString()
                    };
                }
            }
            catch
            {
            }

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

        // POST: api/LoginReset
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LoginReset/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LoginReset/5
        public void Delete(int id)
        {
        }
    }
}
