using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SpikeRest.Models.SAM
{
    [DataContract]
    public class claimAsset
    {
        [DataMember(Name = "invno")]
        public string Invno { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "vendorid")]
        public int Vendorid { get; set; }

        [DataMember(Name = "companyname")]
        public string Companyname { get; set; }


        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}