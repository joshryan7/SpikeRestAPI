using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class AppraisalLocationsInfo
    {

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "projectid")]
        public string Projectid { get; set; }

        [DataMember(Name = "locname")]
        public string Locaname { get; set; }

        [DataMember(Name = "forgncode")]
        public string Forgncode { get; set; }

        [DataMember(Name = "address1")]
        public string Address1 { get; set; }

        [DataMember(Name = "address2")]
        public string Address2 { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "zip")]
        public string Zip { get; set; }

        [DataMember(Name = "notes")]
        public string Notes { get; set; }

        [DataMember(Name = "contactname")]
        public string Contactname { get; set; }

        [DataMember(Name = "contactemail")]
        public string Contactemail { get; set; }

    }
}