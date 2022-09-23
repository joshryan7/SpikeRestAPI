using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class AppointmentsInfo
    {

        [DataMember(Name = "appdate")]
        public string Appdate { get; set; }

        [DataMember(Name = "custname")]
        public string Custname { get; set; }

        [DataMember(Name = "fullname")]
        public string Fullname { get; set; }

        [DataMember(Name = "note")]
        public string Note { get; set; }

        [DataMember(Name = "cstno")]
        public string Cstno { get; set; }

        [DataMember(Name = "appttime")]
        public string Appttime { get; set; }

    }
}