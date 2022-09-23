using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class MTPinfo
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "machinetype")]
        public string Machinetype { get; set; }

        [DataMember(Name = "mtorder")]
        public string Mtorder { get; set; }
    }
}