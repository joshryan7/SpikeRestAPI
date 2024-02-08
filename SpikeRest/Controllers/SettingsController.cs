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
using System.Web.Http.Controllers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Metadata;
using System.Drawing;
using System.Web;
using System.Configuration;

namespace SpikeRest.Controllers
{
    public class SettingsController : ApiController
    {
        private List<SettingsInfo> settingsList;

        // GET: api/Settings
        public SettingsInfo Get()
        {
            string apikey = Environment.GetEnvironmentVariable("OpenAIApiKey", EnvironmentVariableTarget.Machine);

            return new SettingsInfo
            {
                OpenAIApiKey = apikey
            };
        }

        // GET: api/Settings/5
        public SettingsInfo Get(int id)
        {
            string apikey = Environment.GetEnvironmentVariable("OpenAIApiKey", EnvironmentVariableTarget.Machine);

            return new SettingsInfo
            {
                OpenAIApiKey = apikey
            };

        }

        // POST: api/Settings
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Settings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Settings/5
        public void Delete(int id)
        {
        }
    }
}
