using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class RecentsInfo
    {
        [DataMember(Name = "recordtype")]
        public string Recordtype { get; set; }

        [DataMember(Name = "recordkey")]
        public string Recordkey { get; set; }

        [DataMember(Name = "displaydesc")]
        public string Displaydesc { get; set; }
    }
}