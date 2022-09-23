using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class CommissionsPreInfo
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

        [DataMember(Name = "basisamount")]
        public string Basisamount { get; set; }

        [DataMember(Name = "commamount")]
        public string Commamount { get; set; }

        [DataMember(Name = "basisamounttype")]
        public string Basisamounttype { get; set; }

        [DataMember(Name = "commtype")]
        public string Commtype { get; set; }

        [DataMember(Name = "proactive")]
        public string Proactive { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "dateadded")]
        public string Dateadded { get; set; }

        [DataMember(Name = "addedbyid")]
        public string Addedbyid { get; set; }

        [DataMember(Name = "addedbyname")]
        public string Addedbyname { get; set; }

        [DataMember(Name = "datemodified")]
        public string Datemodified { get; set; }

        [DataMember(Name = "modifiedbyid")]
        public string Modifiedbyid { get; set; }

        [DataMember(Name = "modifiedbyname")]
        public string Modifiedbyname { get; set; }

        [DataMember(Name = "commDate")]
        public string Commdate { get; set; }

        [DataMember(Name = "pifdate")]
        public string Pifdate { get; set; }

        [DataMember(Name = "shipdate")]
        public string Shipdate { get; set; }

        [DataMember(Name = "jvpandpercentage")]
        public string Jvpandpercentage { get; set; }

        [DataMember(Name = "invoicedate")]
        public string Invoicedate { get; set; }

        [DataMember(Name = "descript")]
        public string Descript { get; set; }

        [DataMember(Name = "totalcommamount")]
        public string Totalcommamount { get; set; }

    }
}