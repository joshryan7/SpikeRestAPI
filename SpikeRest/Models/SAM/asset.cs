using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models.SAM
{
    [DataContract]
    public class asset
    {
        [DataMember(Name = "vendorid")]
        public string Vendorid { get; set; }

        [DataMember(Name = "assetnumber")]
        public string AssetNumber { get; set; }

        [DataMember(Name = "descript")]
        public string Descript { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }
    }
}