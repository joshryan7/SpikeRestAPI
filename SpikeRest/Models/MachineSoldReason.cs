using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace SpikeRest.Models
{
    [DataContract]

    public class MachineSoldReason
    {
        [DataMember(Name = "cstno")]
        public string Cstno { get; set; }

        [DataMember(Name = "reason")]
        public string Reason { get; set; }
    }
}