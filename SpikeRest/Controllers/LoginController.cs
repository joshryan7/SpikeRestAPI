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
                    LastName = dt[0].lastname
                };
            }

            return new UserInfo
            {
                Vendorid = "-1",
                FirstName = "",
                LastName = ""
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