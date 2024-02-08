using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class ShipItemInfo
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "inbno")]
        public string Inbno { get; set; }

        [DataMember(Name = "invno")]
        public string Invno { get; set; }

        [DataMember(Name = "dest")]
        public string Dest { get; set; }

        [DataMember(Name = "pickup")]
        public string Pickup { get; set; }

        [DataMember(Name = "shipdate")]
        public string Shipdate { get; set; }

        [DataMember(Name = "deldate")]
        public string Deldate { get; set; }

        [DataMember(Name = "destcust")]
        public string Destcust { get; set; }

        [DataMember(Name = "destcstno")]
        public string Destcstno { get; set; }

        [DataMember(Name = "destaddr1")]
        public string Destaddr1 { get; set; }

        [DataMember(Name = "destaddr2")]
        public string Destaddr2 { get; set; }

        [DataMember(Name = "destcity")]
        public string Destcity { get; set; }

        [DataMember(Name = "deststate")]
        public string Deststate { get; set; }

        [DataMember(Name = "destforn")]
        public string Destforn { get; set; }

        [DataMember(Name = "destzip")]
        public string Destzip { get; set; }

        [DataMember(Name = "rg_amt")]
        public string Rg_amt { get; set; }

        [DataMember(Name = "trk_amt")]
        public string Trk_amt { get; set; }

        [DataMember(Name = "trk_amt2")]
        public string Trk_amt2 { get; set; }

        [DataMember(Name = "trk_amt3")]
        public string Trk_amt3 { get; set; }

        [DataMember(Name = "lastupdt")]
        public string Lastupdt { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "mfg_short")]
        public string Mfg_short { get; set; }

        [DataMember(Name = "mfg_long")]
        public string Mfg_long { get; set; }

        [DataMember(Name = "pifshort")]
        public string Pifshort { get; set; }

        [DataMember(Name = "piflong")]
        public string Piflong { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        [DataMember(Name = "serial")]
        public string Serial { get; set; }

        [DataMember(Name = "jvpper")]
        public string Jvpper { get; set; }

        [DataMember(Name = "rpt_amt")]
        public string Rpt_amt { get; set; }
    }
}