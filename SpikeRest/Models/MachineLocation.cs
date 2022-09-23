using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace SpikeRest.Models
{
    [DataContract]
    public class MachineLocation
    {
        [DataMember(Name = "locationname")]
        public string LocationName { get; set; }

        [DataMember(Name = "locationcode")]
        public string LocationCode { get; set; }

        [DataMember(Name = "letter")]
        public string Letter { get; set; }
    }
}