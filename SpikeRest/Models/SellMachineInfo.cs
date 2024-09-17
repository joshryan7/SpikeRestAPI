using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class SellMachineInfo
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "mfg")]
        public string Mfg { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "year")]
        public string Year { get; set; }

        [DataMember(Name = "note")]
        public string Note { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "addbyid")]
        public string Addbyid { get; set; }
    }
}