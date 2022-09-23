using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class OneLinersInfo
    {

        [DataMember(Name = "invno")]
        public string Invno { get; set; }

        [DataMember(Name = "mfg")]
        public string Mfg { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "field1")]
        public string Field1 { get; set; }


        [DataMember(Name = "field2")]
        public string Field2 { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        [DataMember(Name = "year")]
        public string Year { get; set; }

        [DataMember(Name = "retail")]
        public string Retail { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "label1")]
        public string Label1 { get; set; }

        [DataMember(Name = "label2")]
        public string Label2 { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "jvpcode")]
        public string Jvpcode { get; set; }

        [DataMember(Name = "machinepricingtype")]
        public string Machinepricingtype { get; set; }

        [DataMember(Name = "numberofoffers")]
        public string Numberofoffers { get; set; }

        [DataMember(Name = "numberofnotes")]
        public string Numberofnotes { get; set; }

        [DataMember(Name = "numberofdocs")]
        public string Numberofdocs { get; set; }

        [DataMember(Name = "jvpandpercentage")]
        public string Jvpandpercentage { get; set; }


        [DataMember(Name = "imagemain")]
        public string Imagemain { get; set; }

        [DataMember(Name = "compareprice")]
        public string Compareprice { get; set; }

        [DataMember(Name = "signorid")]
        public string Signorid { get; set; }



    }
}