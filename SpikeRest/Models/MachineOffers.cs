using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class MachineOffers
    {
        [DataMember(Name = "invno")]
        public string Invno { get; set; }

        [DataMember(Name = "amount")]
        public string Amount { get; set; }

        [DataMember(Name = "status_long")]
        public string Status_long { get; set; }

        [DataMember(Name = "offnote")]
        public string Offnote { get; set; }

        [DataMember(Name = "employeelast")]
        public string Employeelast { get; set; }

        [DataMember(Name = "custname")]
        public string Custname { get; set; }

        [DataMember(Name = "offdate")]
        public string Offdate { get; set; }

        [DataMember(Name = "retail")]
        public string Retail { get; set; }
    }
}