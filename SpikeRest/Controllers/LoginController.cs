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
    public class LoginController : ApiController
    {
        private List<UserInfo> userList;

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
        public UserInfo Get(string username, string password)
        {
            dsUser.UsersSAMSelectLoginDataTable dt = new dsUser.UsersSAMSelectLoginDataTable();
            SpikeRest.DAL.dsUserTableAdapters.UsersSAMSelectLoginTableAdapter ta = new DAL.dsUserTableAdapters.UsersSAMSelectLoginTableAdapter();


            dt = ta.GetDataLogin(username, password);
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
        // 1-11-2024 put in for the currently being developed SAM app
        // this is used for validating if the username is already a registered SAM user
        public UserInfo Get(string un)
        {
            dsUser.UsersSAMSelectLoginDataTable dt = new dsUser.UsersSAMSelectLoginDataTable();
            SpikeRest.DAL.dsUserTableAdapters.UsersSAMSelectLoginTableAdapter ta = new DAL.dsUserTableAdapters.UsersSAMSelectLoginTableAdapter();


            dt = ta.GetDataByUsername(un);
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

        // POST: api/User
        public List<UserInfo> Post([FromBody]string value)
        {
            System.IO.File.AppendAllText(@"d:\web2\andy\api_log.txt", value);
            System.IO.File.AppendAllText(@"d:\web2\andy\api_log.txt", Environment.NewLine + "Hello");

            userList = new List<UserInfo>();

            UserInfo i = new UserInfo();
            i.Vendorid = 0.ToString();
            i.FirstName = "Post FirstName";
            i.LastName = "Post LastName";

            userList.Add(i);

            return userList;
        }
    }
}