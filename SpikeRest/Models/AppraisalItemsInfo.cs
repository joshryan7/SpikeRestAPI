using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class AppraisalItemsInfo
    {

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "locationid")]
        public string Locationid { get; set; }

        [DataMember(Name = "projectid")]
        public string Projectid { get; set; }

        [DataMember(Name = "mfg")]
        public string Mfg { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "year")]
        public string Year { get; set; }

        [DataMember(Name = "serial")]
        public string Serial { get; set; }

        [DataMember(Name = "value1a")]
        public string Value1a { get; set; }

        [DataMember(Name = "value1t")]
        public string Value1t { get; set; }

        [DataMember(Name = "value2a")]
        public string Value2a { get; set; }

        [DataMember(Name = "value2t")]
        public string Value2t { get; set; }

        [DataMember(Name = "quantity")]
        public string Quantity { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "capacity")]
        public string Capacity { get; set; }

        [DataMember(Name = "assettype")]
        public string Assettype { get; set; }

        [DataMember(Name = "refno")]
        public string Refno { get; set; }

        [DataMember(Name = "condition")]
        public string Condition { get; set; }

        [DataMember(Name = "notes")]
        public string Notes { get; set; }

        [DataMember(Name = "appraisedby")]
        public string Appraisedby { get; set; }

        [DataMember(Name = "appraisedate")]
        public string Appraisedate { get; set; }

        [DataMember(Name = "locationname")]
        public string Locationname { get; set; }

        [DataMember(Name = "appraisedbyfullname")]
        public string Appraidedbyfullname { get; set; }

        [DataMember(Name = "assetnum")]
        public string Assetnum { get; set; }

    }
}