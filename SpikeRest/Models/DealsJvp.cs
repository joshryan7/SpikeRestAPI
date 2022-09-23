using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class DealsJvp
    {

        [DataMember(Name = "cstno")]
        public string Cstno { get; set; }

        [DataMember(Name = "custname")]
        public string Custname { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "jvpper")]
        public string Jvpper { get; set; }
   
    }
}