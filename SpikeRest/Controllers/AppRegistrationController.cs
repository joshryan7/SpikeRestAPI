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
using System.Web.Http.Results;
using SpikeRest.DAL;

namespace SpikeRest.Controllers
{
    public class AppRegistrationController : ApiController
    {
        private List<AppUserInfo> userList;
        // GET: api/AppRegistration
        public List<AppUserInfo> Get()
        {
            userList = new List<AppUserInfo>();

            AppUserInfo i = new AppUserInfo();
            i.Id = 0.ToString();
            i.Email = "Test Email";
            i.Password = "Test Password";
            i.Fname = "";
            i.Lname = "";
            i.Dateadded = "";
            i.Firstuse = "";
            i.Validationcode = "";
            i.Active = "";
            i.Validationexpires = "";
            i.Phone = "";
            i.Pglcontact = "";
            i.Company = "";

            userList.Add(i);

            return userList;
        }

        // GET: api/AppRegistration/5
        public AppUserInfo Get(string em, 
            string pw, 
            string fn, 
            string ln, 
            string ph,
            string pgl,
            string co
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
                cmd.CommandText = "App_Users_Insert";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@email", em));
                cmd.Parameters.Add(new SqlParameter("@password", pw));
                cmd.Parameters.Add(new SqlParameter("@fname", fn));
                cmd.Parameters.Add(new SqlParameter("@lname", ln));
                cmd.Parameters.Add(new SqlParameter("@phone", ph));
                cmd.Parameters.Add(new SqlParameter("@pglcontact", pgl));
                cmd.Parameters.Add(new SqlParameter("@company", co));

                string qresult = cmd.ExecuteScalar().ToString();
                string validationCode = "";

                if (qresult.Contains("success:"))
                {
                    validationCode = qresult.Substring(8).Trim();
                }

                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                return new AppUserInfo
                {
                    Id = "-1",
                    Email = qresult,
                    Password = "",
                    Fname = "",
                    Lname = "",
                    Dateadded = "",
                    Firstuse = "",
                    Validationcode = validationCode,
                    Active = "",
                    Validationexpires = "",
                    Phone = "",
                    Pglcontact = "",
                    Company = ""
                };
            }
            catch { }


            return new AppUserInfo
            {
                Id = "-1",
                Email = "fail",
                Password = "",
                Fname = "",
                Lname = "",
                Dateadded = "",
                Firstuse = "",
                Validationcode = "",
                Active = "",
                Validationexpires = "",
                Phone = "",
                Pglcontact = "",
                Company = ""
            };
        }

    public AppUserInfo Get(string em,
    string vc
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
                cmd.CommandText = "AppRegistrationValidation";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@email", em));
                cmd.Parameters.Add(new SqlParameter("@validationcode", vc));

                string qresult = cmd.ExecuteScalar().ToString();

                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                //SpikeRest.DAL.dsAppUsers.AppUserLoginDataTable dt = new DAL.dsAppUsers.AppUserLoginDataTable();

                //SpikeRest.DAL.dsAppUsersTableAdapters.AppUserLoginTableAdapter ta = new DAL.dsAppUsersTableAdapters.AppUserLoginTableAdapter();

                //dt = ta.GetData(em, qresult);
                //if (dt.Rows.Count > 0)

                if(!qresult.ToUpper().Contains("FAIL"))
                {
                    return new AppUserInfo
                    {
                        Id = "-1",
                        Email = "success",
                        Password = qresult,
                        Fname = "",
                        Lname = "",
                        Dateadded = "",
                        Firstuse = "",
                        Validationcode = "",
                        Active = "",
                        Validationexpires = "",
                        Phone = "",
                        Pglcontact = "",
                        Company = ""
                    };
                }
            }
            catch { }


            return new AppUserInfo
            {
                Id = "-1",
                Email = "fail",
                Password = "",
                Fname = "",
                Lname = "",
                Dateadded = "",
                Firstuse = "",
                Validationcode = "",
                Active = "",
                Validationexpires = "",
                Phone = "",
                Pglcontact = "",
                Company = ""
            };

        }

        public AppUserInfo Get(string em,
        string pw, string active
        )
        {
            SpikeRest.DAL.dsAppUsers.AppUserLoginDataTable dt = new DAL.dsAppUsers.AppUserLoginDataTable();

            SpikeRest.DAL.dsAppUsersTableAdapters.AppUserLoginTableAdapter ta = new DAL.dsAppUsersTableAdapters.AppUserLoginTableAdapter();

            dt = ta.GetData(em, pw);
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

        //update password
        public AppUserInfo Get(string un, string op, string np, string action, string a2)
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
                cmd.CommandText = "AppUserPassword_Update";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@useremail", un));
                cmd.Parameters.Add(new SqlParameter("@oldpassword", op));
                cmd.Parameters.Add(new SqlParameter("@newpassword", np));

                qresultpgl = cmd.ExecuteScalar().ToString();
                if (qresultpgl == "1")
                {
                    qresultpgl = "success";
                }

                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }
            catch (Exception e2)
            {
                qresultpgl = "fail";
            }

            return new AppUserInfo
            {
                Id = "-1",
                Email = qresultpgl,
                Password = "",
                Fname = "",
                Lname = "",
                Firstuse = "",
                Phone = "",
                Pglcontact = "",
                Company = ""

            };
        }

        //delete App User Account
        public AppUserInfo Get(string em, string id, string action, string request)
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

                /* the stored procedure called in the below code will remove the user record from our CRM database, table int_users, and 
                 * create a user removal request record so that our back end process will remove the user record from our website 
                 * database, tables int_user and int_register. 
                 */
                SqlCommand cmd = new SqlCommand();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = cnToUse;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppUserDelete";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@email", em));
                cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id)));

                SqlParameter output1 = new SqlParameter("@resultValue", SqlDbType.VarChar);
                output1.Direction = ParameterDirection.Output;
                output1.Size = 100;
                cmd.Parameters.Add(output1);

                int nrows = Convert.ToInt32(cmd.ExecuteNonQuery());

                string qresult = output1.Value.ToString();

                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                return new AppUserInfo
                {
                    Id = qresult,
                    Email = em,
                    Password = "",
                    Fname = "",
                    Lname = "",
                    Firstuse = "",
                    Phone = "",
                    Pglcontact = "",
                    Company = ""
                };
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


        // POST: api/AppRegistration
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AppRegistration/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AppRegistration/5
        public void Delete(int id)
        {
        }
    }
}
