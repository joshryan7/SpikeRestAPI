using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class MachinePhotosInfo
    {
        [DataMember(Name = "imagename")]
        public string Imagename { get; set; }
    }
}