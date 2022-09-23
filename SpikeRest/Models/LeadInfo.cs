using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace SpikeRest.Models
{
    [DataContract]
    public class LeadInfo
    {

        [DataMember(Name = "leadid")]
        public string Leadid { get; set; }

        [DataMember(Name = "note")]
        public string Note { get; set; }

        [DataMember(Name = "leadtype")]
        public string Leadtype { get; set; }

        [DataMember(Name = "leadsource")]
        public string Leadsource { get; set; }

        [DataMember(Name = "Leaddate")]
        public string Leaddate { get; set; }

       
        [DataMember(Name = "assignedto")]
        public string Assignedto { get; set; }

        [DataMember(Name = "contactcompany")]
        public string Contactcompany { get; set; }

        [DataMember(Name = "contactname")]
        public string Contactname { get; set; }

        [DataMember(Name = "custname")]
        public string Custname { get; set; }

        [DataMember(Name = "cstno")]
        public string Cstno { get; set; }

        [DataMember(Name = "contactemail")]
        public string Contactemail { get; set; }

        [DataMember(Name = "regarding")]
        public string Regarding { get; set; }

        [DataMember(Name = "currentstep")]
        public string Currentstep { get; set; }

        [DataMember(Name = "nextappt")]
        public string Nextappt { get; set; }

        [DataMember(Name = "completed")]
        public string Completed { get; set; }

        [DataMember(Name = "hot")]
        public string Hot { get; set; }




    }
}