using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class MachineNotes
    {
        [DataMember(Name = "invno")]
        public string Invno { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "notedate")]
        public string Notedate { get; set; }

        [DataMember(Name = "thenote")]
        public string Thenote { get; set; }

        [DataMember(Name = "employeefullname")]
        public string Employeefullname { get; set; }
    }
}