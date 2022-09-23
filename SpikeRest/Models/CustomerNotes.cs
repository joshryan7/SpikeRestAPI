using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class CustomerNotes
    {
        [DataMember(Name = "cstno")]
        public string Cstno { get; set; }

        [DataMember(Name = "note")]
        public string Note { get; set; }
               
        [DataMember(Name = "transdate")]
        public string Transdate { get; set; }

        [DataMember(Name = "firstname")]
        public string Firstname { get; set; }

        [DataMember(Name = "lastname")]
        public string Lastname { get; set; }

        [DataMember(Name = "transtype")]
        public string Transtype { get; set; }
    }
}