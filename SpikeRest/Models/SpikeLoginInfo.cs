using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class SpikeLoginInfo
    {
        [DataMember(Name = "userid")]
        public string Userid { get; set; }

        [DataMember(Name = "firstname")]
        public string Firstname { get; set; }

        [DataMember(Name = "lastname")]
        public string Lastname { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "issalesman")]
        public string Issalesman { get; set; }

        [DataMember(Name = "securitylevel")]
        public string Securitylevel { get; set; }

        [DataMember(Name = "canchangeprice")]
        public string Canchangeprice { get; set; }

        [DataMember(Name = "canaddinventory")]
        public string Canaddinventory { get; set; }

        [DataMember(Name = "canupdatedealfields")]
        public string Canupdatedealfields { get; set; }

        [DataMember(Name = "cantagsold")]
        public string Cantagsold { get; set; }

        [DataMember(Name = "isaccounting")]
        public string Isaccounting { get; set; }

        [DataMember(Name = "mobiletheme")]
        public string Mobiletheme { get; set; }
    }
}