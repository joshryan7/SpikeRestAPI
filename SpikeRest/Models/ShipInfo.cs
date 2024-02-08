using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class ShipInfo
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "shipno")]
        public string Shipno { get; set; }

        [DataMember(Name = "rigger")]
        public string Rigger { get; set; }

        [DataMember(Name = "trucker")]
        public string Trucker { get; set; }

        [DataMember(Name = "shiptype")]
        public string Shiptype { get; set; }

        [DataMember(Name = "invno")]
        public string Invno { get; set; }

        [DataMember(Name = "shipdate")]
        public string Shipdate { get; set; }

        [DataMember(Name = "pickup")]
        public string Pickup { get; set; }

        [DataMember(Name = "pickupcity")]
        public string Pickupcity { get; set; }

        [DataMember(Name = "destination")]
        public string Destination { get; set; }

        [DataMember(Name = "container")]
        public string Container { get; set; }

        [DataMember(Name = "comments")]
        public string Comments { get; set; }

        [DataMember(Name = "descript")]
        public string Descript { get; set; }
    }
}