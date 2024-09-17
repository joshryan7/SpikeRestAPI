using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpikeRest.Models.App;
using SpikeRest.DAL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using SpikeRest.Models;

namespace SpikeRest.Controllers
{
    public class AppUsersController : ApiController
    {
        private List<AppUserInfo> userList;
        // GET: api/AppUsers
        public List<AppUserInfo> Get()
        {
            userList = new List<AppUserInfo>();

            AppUserInfo i = new AppUserInfo();
            i.Id = 0.ToString();
            i.Email = "Test Email";
            i.Password = "";
            i.Fname = "";
            i.Lname = "";
            i.Firstuse = "";
            i.Phone = "";
            i.Pglcontact = "";
            i.Company = "";

            userList.Add(i);

            return userList;
        }

        // GET: api/AppUsers/5
        public AppUserInfo Get(string em, string fn, string ln, string ph, string co)
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            string pglConnection = "";
            string qresultpgl = "";
           


            try
            {
                foreach (ConnectionStringSettings connection in connectionStrings)
                {
                    if (connection.Name == "CRMConnectionString")
                    {
                        pglConnection = connection.ConnectionString;

                        break;
                    }
                }

                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = pglConnection;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppUser_Update";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@email", em));
                cmd.Parameters.Add(new SqlParameter("@firstName", fn));
                cmd.Parameters.Add(new SqlParameter("@lastname", ln));
                cmd.Parameters.Add(new SqlParameter("@phone", ph));
                cmd.Parameters.Add(new SqlParameter("@company", co));

                qresultpgl = cmd.ExecuteScalar().ToString();

                if (qresultpgl == "1")
                {
                    qresultpgl = "success";
                }
                else
                {
                    qresultpgl = "fail";
                }

                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }
            catch
            {
                qresultpgl = "fail";
            }

            return new AppUserInfo
            {
                Id = "-1",
                Email = qresultpgl,
                Password = "",
                Fname = fn,
                Lname = ln,
                Firstuse = "",
                Phone = ph,
                Pglcontact = "",
                Company = co
            };

        }

        // call this method to validate the reset code
        public AppUserInfo Get(string useremail, string vcode)
        {
            dsAppUsers.AppUserLoginDataTable dt = new dsAppUsers.AppUserLoginDataTable();
            SpikeRest.DAL.dsAppUsersTableAdapters.AppUserLoginTableAdapter ta = new DAL.dsAppUsersTableAdapters.AppUserLoginTableAdapter();

            dt = ta.GetDataByValidationCode(useremail, vcode);
            if (dt.Rows.Count == 1)
            {
                return new AppUserInfo
                {
                    Id = dt[0].id.ToString(),
                    Email = dt[0].email,
                    Password = dt[0].password,
                    Fname = dt[0].fname,
                    Lname = dt[0].lname,
                    Firstuse = dt[0].firstuse.ToString(),
                    Phone = dt[0].phone,
                    Pglcontact = dt[0].pglcontact,
                    Company = dt[0].company
                };
            }
            else
            {
                return new AppUserInfo
                {
                    Id = "-1",
                    Email = "",
                    Password = "",
                    Fname = "",
                    Lname = "",
                    Firstuse = "",
                    Phone = "",
                    Pglcontact = "",
                    Company = ""
                };
            }
        }

        public AppUserInfo Get(string useremail, string np, string vcode)
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
                cmd.CommandText = "SellMachineryPassword_Update";
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

                // get the user's record to return to the Sell Machinery app, as it uses the info for validation
                dsAppUsers.AppUserLoginDataTable dt = new dsAppUsers.AppUserLoginDataTable();
                SpikeRest.DAL.dsAppUsersTableAdapters.AppUserLoginTableAdapter ta = new DAL.dsAppUsersTableAdapters.AppUserLoginTableAdapter();

                dt = ta.GetData(useremail, "hockey23csharp01");
                if (dt.Rows.Count > 0)
                {
                    return new AppUserInfo
                    {

                        Id = dt[0].id.ToString(),
                        Email = dt[0].email,
                        Password = dt[0].password,
                        Fname = dt[0].fname,
                        Lname = dt[0].lname,
                        Firstuse = dt[0].firstuse.ToString(),
                        Phone = dt[0].phone,
                        Pglcontact = dt[0].pglcontact,
                        Company = dt[0].company
                    };
                }

            }
            catch { }

            return new AppUserInfo
            {
                Id = "-1",
                Email = "",
                Password = "",
                Fname = "",
                Lname = "",
                Firstuse = "",
                Phone = "",
                Pglcontact = "",
                Company = ""
            };
        }


                // POST: api/AppUsers
                public void Post([FromBody]string value)
        {
        }

        // PUT: api/AppUsers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AppUsers/5
        public void Delete(int id)
        {
        }
    }
}
