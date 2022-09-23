using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SpikeRest.Models
{
    [DataContract]
    public class MachineAdvertised
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "yearmfg")]
        public string Yearmfg { get; set; }

        [DataMember(Name = "manufacturer")]
        public string Manufacturer { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "price")]
        public string Price { get; set; }

        [DataMember(Name = "currencycode")]
        public string Currencycode { get; set; }

        [DataMember(Name = "listingurl")]
        public string Listingurl { get; set; }

        [DataMember(Name = "countrycode")]
        public string Countrycode { get; set; }

        [DataMember(Name = "specstandard")]
        public string Specstandard { get; set; }

        [DataMember(Name = "specmetric")]
        public string Specmetric { get; set; }

        


    }
}