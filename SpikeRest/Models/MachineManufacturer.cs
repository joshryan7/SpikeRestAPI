using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class MachineManufacturer
    {
        [DataMember(Name = "manufacturername")]
        public string ManufacturerName { get; set; }

        [DataMember(Name = "manufacturercode")]
        public string ManufacturerCode { get; set; }

        [DataMember(Name = "letter")]
        public string Letter { get; set; }
    }
}