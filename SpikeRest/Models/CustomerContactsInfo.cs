using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class CustomerContactsInfo
    {
        [DataMember(Name = "cstno")]
        public string Cstno { get; set; }

        [DataMember(Name = "firstname")]
        public string Firstname { get; set; }

        [DataMember(Name = "lastname")]
        public string Lastname { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "phone1")]
        public string Phone1 { get; set; }

        [DataMember(Name = "pkey")]
        public string Pkey { get; set; }
    }
}