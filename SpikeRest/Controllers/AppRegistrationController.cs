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

            userList.Add(i);

            return userList;
        }

        // GET: api/AppRegistration/5
        public AppUserInfo Get(string em, 
            string pw, 
            string fn, 
            string ln, 
            string ph)
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
                    Phone = ""
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
                Phone = ""
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
