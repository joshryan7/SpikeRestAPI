using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SpikeRest.Models
{
    [DataContract]
    public class Pricehistory
    {

        [DataMember(Name = "datechange")]
        public string Datechanged { get; set; }

        [DataMember(Name = "oldprice")]
        public string Oldprice { get; set; }

        [DataMember(Name = "newprice")]
        public string Newprice { get; set; }

        [DataMember(Name = "changedby")]
        public string Changedby { get; set; }

       
    }
}