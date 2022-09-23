using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class ContactInfo
    {
        [DataMember(Name = "PKEY")]
        public string Pkey { get; set; }

        [DataMember(Name = "CSTNO")]
        public string Cstno { get; set; }

        [DataMember(Name = "LAST")]
        public string Last { get; set; }

        [DataMember(Name = "First")]
        public string First { get; set; }

        [DataMember(Name = "PHONE1")]
        public string Phone1 { get; set; }

        [DataMember(Name = "TITLE")]
        public string Title { get; set; }

        [DataMember(Name = "EMAIL")]
        public string Email { get; set; }
    }
}