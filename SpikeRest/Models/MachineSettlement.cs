using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SpikeRest.Models
{
    [DataContract]

    public class MachineSettlement
    {
        [DataMember(Name = "jvpcode")]
        public string Jvpcode { get; set; }

        [DataMember(Name = "settledate")]
        public string Settledate { get; set; }

        [DataMember(Name = "refno")]
        public string Refno { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "amount")]
        public string Amount { get; set; }

        [DataMember(Name = "custname")]
        public string Custname { get; set; }

        [DataMember(Name = "cstno")]
        public string Cstno { get; set; }
    }
}