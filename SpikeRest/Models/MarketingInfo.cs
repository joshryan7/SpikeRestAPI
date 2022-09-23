using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class MarketingInfo
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "subcategory")]
        public string Subcategory { get; set; }

        [DataMember(Name = "detailamount")]
        public string Detailamount { get; set; }
    }
}