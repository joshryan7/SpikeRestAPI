using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class DealMachine
    {
        

        [DataMember(Name = "invno")]
        public string Invno { get; set; }

        [DataMember(Name = "descript")]
        public string Descript { get; set; }

        [DataMember(Name = "displayorder")]
        public string Displayorder { get; set; }

        [DataMember(Name = "year")]
        public string Year { get; set; }


    }
}