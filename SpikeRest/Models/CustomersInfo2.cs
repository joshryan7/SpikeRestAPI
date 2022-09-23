using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class CustomersInfo2
    {
        [DataMember(Name = "cstno")]
        public string Cstno { get; set; }

        [DataMember(Name = "custname")]
        public string Custname { get; set; }

        [DataMember(Name = "address1")]
        public string Address1 { get; set; }

        [DataMember(Name = "address2")]
        public string Address2 { get; set; }

        [DataMember(Name = "countylong")]
        public string Countylong { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "state_long")]
        public string State_long { get; set; }

        [DataMember(Name = "zip")]
        public string Zip { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "faxphone")]
        public string Faxphone { get; set; }

        [DataMember(Name = "samjvp")]
        public string Samjvp { get; set; }

        [DataMember(Name = "numberofnotes")]
        public string Numberofnotes { get; set; }
    }
}