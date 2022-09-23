using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class CategoryInfo
    {
        [DataMember(Name = "catdesc")]
        public string Catdesc { get; set; }

        [DataMember(Name = "catno")]
        public string Catno { get; set; }

        [DataMember(Name = "letter")]
        public string Letter { get; set; }
    }
}