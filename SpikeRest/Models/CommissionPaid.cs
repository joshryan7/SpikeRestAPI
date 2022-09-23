using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]   
    public class CommissionPaid
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "commpaidtoid")]
        public string Commpaidtoid { get; set; }

        [DataMember(Name = "commpaidtoname")]
        public string Commpaidtoname { get; set; }

        [DataMember(Name = "commmonth")]
        public string Commmonth { get; set; }

        [DataMember(Name = "commyear")]
        public string Commyear { get; set; }

        [DataMember(Name = "invno")]
        public string Invno { get; set; }

        [DataMember(Name = "commamount")]
        public string Commamount { get; set; }

        [DataMember(Name = "commtype")]
        public string Commtype { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "dateapproved")]
        public string Dateapproved { get; set; }

    }
}