using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    public class SettingsInfo
    {
        [DataMember(Name = "openaiapikey")]
        public string OpenAIApiKey { get; set; }
    }
}