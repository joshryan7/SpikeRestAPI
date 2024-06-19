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
    public class UserController : ApiController
    {
        private List<UserInfo> userList;
        // GET: api/User
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

        // GET: api/User/5
        public UserInfo Get(string em, string fn, string ln, string ph, string wa)
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
                cmd.CommandText = "SAMUser_Update";
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@email", em));
                cmd.Parameters.Add(new SqlParameter("@firstName", fn));
                cmd.Parameters.Add(new SqlParameter("@lastname", ln));
                cmd.Parameters.Add(new SqlParameter("@phone", ph));
                cmd.Parameters.Add(new SqlParameter("@workAddress", wa));

                qresultpgl = cmd.ExecuteScalar().ToString();

                if (qresultpgl == "1")
                {
                    qresultpgl = "success";
                    cmd.Dispose();
                    cn.Close();
                    cn.Dispose();

                    SqlCommand cmdWeb = new SqlCommand();
                    SqlConnection cnWeb = new SqlConnection();
                    cnWeb.ConnectionString = webConnection;
                    cnWeb.Open();
                    cmdWeb.Connection = cnWeb;
                    cmdWeb.CommandType = CommandType.StoredProcedure;
                    cmdWeb.CommandText = "SAMUser_Update";
                    cmdWeb.Parameters.Clear();

                    cmdWeb.Parameters.Add(new SqlParameter("@email", em));
                    cmdWeb.Parameters.Add(new SqlParameter("@firstName", fn));
                    cmdWeb.Parameters.Add(new SqlParameter("@lastname", ln));
                    cmdWeb.Parameters.Add(new SqlParameter("@phone", ph));
                    cmdWeb.Parameters.Add(new SqlParameter("@workAddress", wa));

                    qresultpgl = "";

                    qresultWeb = cmdWeb.ExecuteScalar().ToString();
                    if (qresultWeb == "1")
                    {
                        qresultpgl = "success";
                    }

                    cmdWeb.Dispose();
                    cnWeb.Close();
                    cnWeb.Dispose();
                }
                else
                {
                    qresultpgl = "fail";
                }

            }
            catch
            {
                qresultpgl = "fail";
            }

            return new UserInfo
            {
                Vendorid = "-1",
                FirstName = qresultpgl,
                LastName = ln,
                Username = "",
                Phone = ph,
                Email = "",
                Lastinvno = "",
                Workaddress = wa,
                Addanasset = ""
            };

        }
        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
