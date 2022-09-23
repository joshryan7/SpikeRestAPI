using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class DealLot
    {
        [DataMember(Name = "lot")]
        public string Lot { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "buynowprice")]
        public string Buynowprice { get; set; }

        [DataMember(Name = "buynowtext")]
        public string Buynowtext { get; set; }

        [DataMember(Name = "sold")]
        public string Sold { get; set; }

        [DataMember(Name = "dealid")]
        public string Dealid { get; set; }

    }
}