using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class CustomerHistoryInfo
    {
        [DataMember(Name = "cstno")]
        public string Cstno { get; set; }

        [DataMember(Name = "transtype")]
        public string Transtype { get; set; }

        [DataMember(Name = "trans2type")]
        public string Trans2type { get; set; }

        [DataMember(Name = "transtime")]
        public string Transtime { get; set; }

        [DataMember(Name = "thekey")]
        public string Thekey { get; set; }

        [DataMember(Name = "transdate")]
        public string Transdate { get; set; }

        [DataMember(Name = "sls")]
        public string Sls { get; set; }

        [DataMember(Name = "fullname")]
        public string Fullname { get; set; }

        [DataMember(Name = "invno")]
        public string Invno { get; set; }

        [DataMember(Name = "userprice")]
        public string Userprice { get; set; }

        [DataMember(Name = "retail")]
        public string Retail { get; set; }

        [DataMember(Name = "udf1")]
        public string Udf1 { get; set; }

        [DataMember(Name = "apptime")]
        public string Apptime { get; set; }

        [DataMember(Name = "mfg")]
        public string Mfg { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "note")]
        public string Note { get; set; }

        [DataMember(Name = "displaynote")]
        public string Displaynote { get; set; }

        [DataMember(Name = "emailaddress")]
        public string Emailaddress { get; set; }

        [DataMember(Name = "emailsubject")]
        public string Emailsubject { get; set; }
    }
}