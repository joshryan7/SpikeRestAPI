using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
  
        [DataContract]
        public class UserInfo
        {
            [DataMember(Name = "vendorid")]
            public string Vendorid { get; set; }

            [DataMember(Name = "firstname")]
            public string FirstName { get; set; }

            [DataMember(Name = "lastname")]
            public string LastName { get; set; }

            [DataMember(Name = "username")]
            public string Username { get; set; }

            [DataMember(Name = "email")]
            public string Email { get; set; }

            [DataMember(Name = "phone")]
            public string Phone { get; set; }

            [DataMember(Name = "workaddress")]
            public string Workaddress { get; set; }

            [DataMember(Name = "lastinvno")]
            public string Lastinvno { get; set; }

            [DataMember(Name = "addanasset")]
            public string Addanasset { get; set; }


    }
  
}