using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class LocationInfo
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "lcode")]
        public string Lcode { get; set; }

        [DataMember(Name = "lname")]
        public string Lname { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "zip")]
        public string Zip { get; set; }

        [DataMember(Name = "contact")]
        public string Contact { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "sqft")]
        public string Sqft { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "deleteyn")]
        public string Deleteyn { get; set; }

        [DataMember(Name = "daysfree")]
        public string Daysfree { get; set; }

        [DataMember(Name = "glacct")]
        public string glacct { get; set; }

        [DataMember(Name = "fdate")]
        public string Fdate { get; set; }

        [DataMember(Name = "shipterm")]
        public string Shipterm { get; set; }

        [DataMember(Name = "termother")]
        public string Termother { get; set; }

        [DataMember(Name = "prints")]
        public string Prints { get; set; }

        [DataMember(Name = "manuals")]
        public string Manuals { get; set; }

        [DataMember(Name = "actneer")]
        public string Actneer { get; set; }

        [DataMember(Name = "actnnam")]
        public string Actnnam { get; set; }

        [DataMember(Name = "buyer")]
        public string Buyer { get; set; }

        [DataMember(Name = "lot")]
        public string Lot { get; set; }

        [DataMember(Name = "addby")]
        public string Addby { get; set; }

        [DataMember(Name = "editby")]
        public string Editby { get; set; }

        [DataMember(Name = "forgncode")]
        public string Forncode { get; set; }

        //[DataMember(Name = "yesno")]
        //public string Yesno { get; set; }

        [DataMember(Name = "addbyid")]
        public string Addbyid { get; set; }

        [DataMember(Name = "adddate")]
        public string Addate { get; set; }

        [DataMember(Name = "editbyid")]
        public string Editbyid { get; set; }

        [DataMember(Name = "editbydate")]
        public string Editbydate { get; set; }

        [DataMember(Name = "jvpcstno")]
        public string Jvpcstno { get; set; }

        [DataMember(Name = "samjvp")]
        public string Samjvp { get; set; }

        [DataMember(Name = "responsiblesalesman")]
        public string Responsiblesalesman { get; set; }

        [DataMember(Name = "jvpcode")]
        public string Jvpcode { get; set; }

        [DataMember(Name = "responsiblesalesmanlong")]
        public string Responsiblesalesmanlong { get; set; }
    }
}