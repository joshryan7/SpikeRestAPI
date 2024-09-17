using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace SpikeRest.Models.App
{
    [DataContract]
    public class AppUserInfo
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "fname")]
        public string Fname { get; set; }

        [DataMember(Name = "lname")]
        public string Lname { get; set; }

        [DataMember(Name = "dateadded")]
        public string Dateadded { get; set; }

        [DataMember(Name = "firstuse")]
        public string Firstuse { get; set; }

        [DataMember(Name = "validationcode")]
        public string Validationcode { get; set; }

        [DataMember(Name = "active")]
        public string Active { get; set; }

        [DataMember(Name = "validationexpires")]
        public string Validationexpires { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "pglcontact")]
        public string Pglcontact { get; set; }

        [DataMember(Name = "company")]
        public string Company { get; set; }
    }
}