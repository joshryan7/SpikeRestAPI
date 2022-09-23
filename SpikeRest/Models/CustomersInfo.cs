using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class CustomersInfo
    {

        [DataMember(Name = "cstno")]
        public string Cstno { get; set; }

        [DataMember(Name = "custname")]
        public string Custname { get; set; }

        [DataMember(Name = "forgncode")]
        public string Forgncode { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }


        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "csttype")]
        public string Csttype { get; set; }

    }
}