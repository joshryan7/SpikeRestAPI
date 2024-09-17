using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class MachineInfo
    {
        [DataMember(Name = "invno")]
        public string Invno { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "year")]
        public string Year { get; set; }

        [DataMember(Name = "imagemain")]
        public string ImageMain { get; set; }


        [DataMember(Name = "jvpinvno")]
        public string Jvpinvno { get; set; }

        [DataMember(Name = "jvpandpercentage")]
        public string JvpandPercentage { get; set; }

        [DataMember(Name = "numbofnotes")]
        public string Numbofnotes { get; set; }

        [DataMember(Name = "numbofoffers")]
        public string Numbofoffers { get; set; }

        [DataMember(Name = "pifstatus")]
        public string Pifstatus { get; set; }

        [DataMember(Name = "tag_long")]
        public string Tag_long { get; set; }

        [DataMember(Name = "tagdate")]
        public string Tagdate { get; set; }

        [DataMember(Name = "tagcustomer")]
        public string Tagcustomer { get; set; }

        [DataMember(Name = "tagcontact")]
        public string Tagcontact { get; set; }

        [DataMember(Name = "tagsalesperson")]
        public string Tagsalesperson { get; set; }

        [DataMember(Name = "tagamount")]
        public string Tagamount { get; set; }

        [DataMember(Name = "outbound")]
        public string Outbound { get; set; }

        [DataMember(Name = "inspdate")]
        public string Inspdate { get; set; }

        [DataMember(Name = "cstno")]
        public string Cstno { get; set; }

        [DataMember(Name = "retail")]
        public string Retail { get; set; }

        [DataMember(Name = "width")]
        public string Width { get; set; }

        [DataMember(Name = "length")]
        public string Length { get; set; }

        [DataMember(Name = "height")]
        public string Height { get; set; }

        [DataMember(Name = "approx_wt")]
        public string Approx_wt { get; set; }

        [DataMember(Name = "sqft")]
        public string Sqft { get; set; }

        [DataMember(Name = "dimensioncomment")]
        public string Dimensioncomment { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        //[DataMember(Name = "label1")]
        //public string Label1 { get; set; }

        //[DataMember(Name = "value1")]
        //public string Value1 { get; set; }

        //[DataMember(Name = "label2")]
        //public string Label2 { get; set; }

        //[DataMember(Name = "value2")]
        //public string Value2 { get; set; }


        //[DataMember(Name = "label3")]
        //public string Label3 { get; set; }

        //[DataMember(Name = "value3")]
        //public string Value3 { get; set; }

        //[DataMember(Name = "label4")]
        //public string Label4 { get; set; }

        //[DataMember(Name = "value4")]
        //public string Value4 { get; set; }

        //[DataMember(Name = "label5")]
        //public string Label5 { get; set; }

        //[DataMember(Name = "value5")]
        //public string Value5 { get; set; }

        //[DataMember(Name = "label6")]
        //public string Label6 { get; set; }

        //[DataMember(Name = "value6")]
        //public string Value6 { get; set; }

        //[DataMember(Name = "label7")]
        //public string Label7 { get; set; }

        //[DataMember(Name = "value7")]
        //public string Value7 { get; set; }

        //[DataMember(Name = "label8")]
        //public string Label8 { get; set; }

        //[DataMember(Name = "value8")]
        //public string Value8 { get; set; }

        //[DataMember(Name = "model")]
        //public string Model { get; set; }

        [DataMember(Name = "specsheet")]
        public string SpecSheet { get; set; }

        [DataMember(Name = "specmetric")]
        public string SpecMetric { get; set; }

        [DataMember(Name = "salesplanstatus")]
        public string Salesplanstatus { get; set; }

        //[DataMember(Name = "specmetric")]
        //public string SpecMetric { get; set; }

        [DataMember(Name = "signorid")]
        public string Signorid { get; set; }

        [DataMember(Name = "signorname")]
        public string Signorname { get; set; }

        [DataMember(Name = "leadtype")]
        public string Leadtype { get; set; }

        [DataMember(Name = "approvedby")]
        public string Approvedby { get; set; }

        [DataMember(Name = "howfound")]
        public string Howfound { get; set; }

        [DataMember(Name = "signornote")]
        public string Signornote { get; set; }

        [DataMember(Name = "exclEndDate")]
        public string Exclenddate { get; set; }

        [DataMember(Name = "netbacktoseller")]
        public string Netbacktoseller { get; set; }

        [DataMember(Name = "responsibleSalesmanid")]
        public string Responsiblesalesmanid { get; set; }

        [DataMember(Name = "netbacktoselleramount")]
        public string Netbacktoselleramount { get; set; }

        [DataMember(Name = "netbacktosellerpercentage")]
        public string Netbacktosellerpercentage { get; set; }

        [DataMember(Name = "transferamount")]
        public string Transferamount { get; set; }

        [DataMember(Name = "transfernote")]
        public string Transfernote { get; set; }

        [DataMember(Name = "removalamount")]
        public string Removalamount { get; set; }

        [DataMember(Name = "removalnote")]
        public string Removalnote { get; set; }

        [DataMember(Name = "assetcontactname")]
        public string Assetcontactname { get; set; }

        [DataMember(Name = "assetcontactemail")]
        public string Assetcontactemail { get; set; }

        [DataMember(Name = "assetcontactphone")]
        public string Assetcontactphone { get; set; }

        [DataMember(Name = "transferassets")]
        public string Transferassets { get; set; }

        [DataMember(Name = "reserved")]
        public string Reserved { get; set; }

        [DataMember(Name = "bookvalue")]
        public string Bookvalue { get; set; }

        [DataMember(Name = "lcode")]
        public string Lcode { get; set; }
    }
}