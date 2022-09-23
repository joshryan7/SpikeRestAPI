using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SpikeRest.Models
{
    [DataContract]
    public class ExcelSend
    {
        [DataMember(Name = "success")]
        public string Success { get; set; }
    }
}