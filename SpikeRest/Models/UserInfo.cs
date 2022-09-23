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

       
    }
  
}