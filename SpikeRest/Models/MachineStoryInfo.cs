using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class MachineStoryInfo
    {
        [DataMember(Name = "column1")]
        public string Column1 { get; set; }
    }
}