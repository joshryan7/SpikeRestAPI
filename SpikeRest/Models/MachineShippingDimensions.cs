using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SpikeRest.Models
{
    [DataContract]
    public class MachineShippingDimensions
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "width")]
        public string Width { get; set; }

        [DataMember(Name = "length")]
        public string Length { get; set; }

        [DataMember(Name = "height")]
        public string Height { get; set; }

        [DataMember(Name = "weight")]
        public string Weight { get; set; }

        [DataMember(Name = "sqft")]
        public string Sqft { get; set; }

        [DataMember(Name = "note")]
        public string Note { get; set; }
    }
}