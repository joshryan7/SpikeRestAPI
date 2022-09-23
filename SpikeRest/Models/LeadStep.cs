using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class LeadStep
    {

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "leadid")]
        public string Leadid { get; set; }

        [DataMember(Name = "stepdescription")]
        public string Stepdescription { get; set; }

        [DataMember(Name = "stepnumber")]
        public string Stepnumber { get; set; }

        [DataMember(Name = "completed")]
        public string Completed { get; set; }


        [DataMember(Name = "completeddate")]
        public string Completeddate { get; set; }

       
        [DataMember(Name = "note")]
        public string Note { get; set; }

    }
}