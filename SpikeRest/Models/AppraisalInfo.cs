using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class AppraisalInfo
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "pname")]
        public string Pname { get; set; }

        [DataMember(Name = "companycstno")]
        public string Companycstno { get; set; }

        [DataMember(Name = "clientcstno")]
        public string Clientcstno { get; set; }

        [DataMember(Name = "contactname")]
        public string Contactname { get; set; }

        [DataMember(Name = "paddress1")]
        public string Paddress1 { get; set; }

        [DataMember(Name = "paddress2")]
        public string Paddress2 { get; set; }

        [DataMember(Name = "pcity")]
        public string Pcity { get; set; }

        [DataMember(Name = "pstate")]
        public string Pstate { get; set; }

        [DataMember(Name = "pzip")]
        public string Pzip { get; set; }

        [DataMember(Name = "contactphone")]
        public string Contactphone { get; set; }

        [DataMember(Name = "contactemail")]
        public string Contactemail { get; set; }

        [DataMember(Name = "pforgncode")]
        public string Pforgncode { get; set; }

        [DataMember(Name = "pdateadded")]
        public string Pdateadded { get; set; }

        [DataMember(Name = "pstartdate")]
        public string Pstartdate { get; set; }

        [DataMember(Name = "value1")]
        public string Value1 { get; set; }

        [DataMember(Name = "value2")]
        public string Value2 { get; set; }

        [DataMember(Name = "ptype")]
        public string Ptype { get; set; }

        [DataMember(Name = "intendeduse")]
        public string Intendeduse { get; set; }

        [DataMember(Name = "pnotes")]
        public string Pnotes { get; set; }

        [DataMember(Name = "custname")]
        public string Custname { get; set; }

        [DataMember(Name = "clientname")]
        public string Clientname { get; set; }

        [DataMember(Name = "recordtype")]
        public string Recordtype { get; set; }

        [DataMember(Name = "itemid")]
        public string Itemid { get; set; }

        [DataMember(Name = "mfg")]
        public string Mfg { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "year")]
        public string Year { get; set; }

        [DataMember(Name = "serial")]
        public string Serial { get; set; }

        [DataMember(Name = "appraiseddate")]
        public string Appraisddate { get; set; }
    }
}