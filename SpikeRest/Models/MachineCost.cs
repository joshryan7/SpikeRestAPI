using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SpikeRest.Models
{
    [DataContract]
    public class MachineCost
    {
        [DataMember(Name = "jvpinfo")]
        public string Jvpinfo { get; set; }
   
        [DataMember(Name = "externalvendorcost")]
        public string Externalvendorcost { get; set; }

        [DataMember(Name = "laborcost")]
        public string Laborcost{ get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "costdate")]
        public string Costdate { get; set; }

        [DataMember(Name = "doctype")]
        public string Doctype { get; set; }

        [DataMember(Name = "refno")]
        public string Refno { get; set; }

        [DataMember(Name = "invoiced")]
        public string Invoiced { get; set; }

        [DataMember(Name = "amount")]
        public string Amount { get; set; }

        [DataMember(Name = "vendor")]
        public string Vendor { get; set; }

        [DataMember(Name = "excludepost")]
        public string Excludepost { get; set; }

      

    }
}