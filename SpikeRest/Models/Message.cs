using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]

    public class Message
    {

        [DataMember(Name = "messagetext")]
        public string MessageText { get; set; }

    }
}