using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class WantedInfo
    {

        [DataMember(Name = "howmatched")]
        public string Howmatched { get; set; }

        [DataMember(Name = "wanted_mfg_short")]
        public string Wanted_mfg_short { get; set; }

        [DataMember(Name = "wanted_model")]
        public string Wanted_model { get; set; }

        [DataMember(Name = "wanted_category")]
        public string Wanted_category { get; set; }

        [DataMember(Name = "wanted_field1")]
        public string Wanted_field1 { get; set; }

        [DataMember(Name = "match_invno")]
        public string Match_invno { get; set; }

        [DataMember(Name = "match_mfg_short")]
        public string Match_mfg_short { get; set; }

        [DataMember(Name = "match_model")]
        public string Match_model { get; set; }

        [DataMember(Name = "match_field1")]
        public string Match_field1 { get; set; }

    }
}