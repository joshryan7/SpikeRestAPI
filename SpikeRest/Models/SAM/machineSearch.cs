using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models.SAM
{
    [DataContract]
    public class machineSearch
    {
        [DataMember(Name = "invno")]
        public string Invno { get; set; }

        [DataMember(Name = "itemname")]
        public string ItemName { get; set; }

        [DataMember(Name = "year")]
        public string Year { get; set; }

        [DataMember(Name = "itemimagename")]
        public string ImageMain { get; set; }

        [DataMember(Name = "jvpinvno")]
        public string Jvpinvno { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "reserved")]
        public string Reserved { get; set; }
    }
}