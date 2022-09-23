using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;



namespace SpikeRest.Models
{
    [DataContract]
    public class MachineCash
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "checknumber")]
        public string Checknumber { get; set; }

        [DataMember(Name = "ref")]
        public string Ref { get; set; }
        
        [DataMember(Name = "formatted")]
        public string formatted { get; set; }

        [DataMember(Name = "amount")]
        public string Amount { get; set; }

        [DataMember(Name = "checkdate")]
        public string Checkdate{ get; set; }
    }
}