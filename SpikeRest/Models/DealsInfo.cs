using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class DealsInfo
    {


        //primary key, needs to go first because
        // the iOS app needs to pasre primary key first
        [DataMember(Name = "id")]
        public string Id { get; set; }

        //A

        [DataMember(Name = "addr1")]
        public string Addr1 { get; set; }

        [DataMember(Name = "addr2")]
        public string Addr2 { get; set; }

        [DataMember(Name = "addr3")]
        public string Addr3 { get; set; }


        [DataMember(Name = "appraisedbyfull")]
        public string Appraisedbyfull { get; set; }

        [DataMember(Name = "approvedby")]
        public string Approvedby { get; set; }

        [DataMember(Name = "appointmentdate")]
        public string Appointmentdate { get; set; }

        [DataMember(Name = "appointmenttime")]
        public string Appointmenttime { get; set; }

        [DataMember(Name = "auctionclosedate")]
        public string Auctionclosedate { get; set; }

        [DataMember(Name = "auctionclosetime")]
        public string Auctionclosetime { get; set; }

        [DataMember(Name = "auctionstartdate")]
        public string Auctionstartdate { get; set; }

        [DataMember(Name = "auctionstarttime")]
        public string Auctionstarttime { get; set; }

        [DataMember(Name = "auctionurl")]
        public string Auctionurl { get; set; }

        //B

        [DataMember(Name = "bptext")]
        public string Bptext { get; set; }


        [DataMember(Name = "brochureimageurl")]
        public string Brochureimageurl { get; set; }

        [DataMember(Name = "brochuredestinationurl")]
        public string Brochuredestinationurl { get; set; }


        [DataMember(Name = "buyerpremium")]
        public string Buyerpremium { get; set; }


        //C
        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "companylogo")]
        public string Companylogo { get; set; }

        [DataMember(Name = "customurl")]
        public string Customurl { get; set; }


        //D

        [DataMember(Name = "dateadded")]
        public string Dateadded { get; set; }

        [DataMember(Name = "datefound")]
        public string Datefound { get; set; }

        [DataMember(Name = "dcompanyaka")]
        public string Dcompanyaka { get; set; }

        [DataMember(Name = "dcompanycstno")]
        public string Dcompanycstno { get; set; }

        [DataMember(Name = "dcompanyfull")]
        public string Dcompanyfull { get; set; }

       

        [DataMember(Name = "dcontactfull")]
        public string Dcontactfull { get; set; }

        [DataMember(Name = "dealfromcstnonumber")]
        public string Dealfromcstnonumber { get; set; }

        [DataMember(Name = "dealfromcstnofull")]
        public string Dealfromcstnofull { get; set; }

        [DataMember(Name = "deallocation")]
        public string Deallocation { get; set; }

        [DataMember(Name = "dname")]
        public string Dname { get; set; }

        [DataMember(Name = "documentfolder")]
        public string Documentfolder { get; set; }

        [DataMember(Name = "dstatus")]
        public string Dstatus { get; set; }

        [DataMember(Name = "dsubtype")]
        public string Dsubtype { get; set; }

        [DataMember(Name = "dtype")]
        public string Dtype { get; set; }

        [DataMember(Name = "dvalue")]
        public string Dvalue { get; set; }

        //E
        [DataMember(Name = "equipdetailsweb")]
        public string Equipdetailsweb { get; set; }

        [DataMember(Name = "equipmentremoval")]
        public string Equipmentremoval { get; set; }

        //F
        [DataMember(Name = "findercommission")]
        public string Findercommission { get; set; }

        [DataMember(Name = "forgncode")]
        public string Forgncode { get; set; }

        [DataMember(Name = "forgncodefull")]
        public string Forgncodefull { get; set; }

        [DataMember(Name = "foundbyfull")]
        public string Foundbyfull { get; set; }
        // H
        [DataMember(Name = "howfound")]
        public string Howfound { get; set; }

        //I
       



        [DataMember(Name = "inspectionweb")]
        public string Inspectionweb { get; set; }

        [DataMember(Name = "internetdescription")]
        public string Internetdescription { get; set; }

        [DataMember(Name = "internetdisplayorder")]
        public string Internetdisplayorder { get; set; }

        [DataMember(Name = "invnoaccounting")]
        public string Invnoaccounting { get; set; }


        //L

        [DataMember(Name = "leadtype")]
        public string Leadtype { get; set; }

        [DataMember(Name = "lob")]
        public string Lob { get; set; }

        [DataMember(Name = "lotlisting")]
        public string Lotlisting { get; set; }

        //M
        [DataMember(Name = "metakeyword")]
        public string Metakeyword { get; set; }

        [DataMember(Name = "metadescription")]
        public string Metadescription { get; set; }

        //N

        [DataMember(Name = "nofollowuprequired")]
        public string NoFollowuprequired { get; set; }

        [DataMember(Name = "nolongerforsale")]
        public string Nolongerforsale { get; set; }

        //O

        [DataMember(Name = "oninternet")]
        public string Oninternet { get; set; }

        [DataMember(Name = "othercompany1cstno")]
        public string Othercompany1cstno { get; set; }

        [DataMember(Name = "othercompany1full")]
        public string Othercompany1full { get; set; }

        [DataMember(Name = "othercompany1comment")]
        public string Othercompany1comment { get; set; }

        [DataMember(Name = "othercompany2cstno")]
        public string Othercompany2cstno { get; set; }

        [DataMember(Name = "othercompany2full")]
        public string Othercompany2full { get; set; }

        [DataMember(Name = "othercompany2comment")]
        public string Othercompany2comment { get; set; }

        //P
        [DataMember(Name = "pdfthumb")]
        public string Pdfthumb { get; set; }

        [DataMember(Name = "pdflocation")]
        public string Pdflocation { get; set; }

        //Q
        [DataMember(Name = "quoteverbiage")]
        public string Quoteverbiage { get; set; }

        [DataMember(Name = "registerurl")]
        public string Registerurl { get; set; }

        //S
        [DataMember(Name = "sellercommission")]
        public string Sellercommission { get; set; }


        [DataMember(Name = "showonwebsite")]
        public string Showonwebsite { get; set; }

        [DataMember(Name = "signornote")]
        public string Signornote { get; set; }

        [DataMember(Name = "sitecontactinfo")]
        public string Sitecontactinfo { get; set; }

        [DataMember(Name = "stateabbr")]
        public string Stateabbr { get; set; }

        [DataMember(Name = "statefull")]
        public string Statefull { get; set; }

        [DataMember(Name = "submitbydate")]
        public string Submitbydate { get; set; }

        [DataMember(Name = "submitbytime")]
        public string Submitbytime { get; set; }

        //T

        [DataMember(Name = "tagverbiage")]
        public string Tagsiteverbiage { get; set; }

        [DataMember(Name = "terms1")]
        public string terms1 { get; set; }

        [DataMember(Name = "termnotes")]
        public string termnotes { get; set; }


        [DataMember(Name = "timezonetext")]
        public string Timezonetext { get; set; }

        [DataMember(Name = "titletag")]
        public string Titletag { get; set; }

        //W
        [DataMember(Name = "webdatetimetext")]
        public string Webdatetimetext { get; set; }


        [DataMember(Name = "webpageviews")]
        public string Webpageviews { get; set; }

        [DataMember(Name = "webshowin")]
        public string Webshowin { get; set; }

        [DataMember(Name = "websiteverbiage")]
        public string Websiteverbiage { get; set; }

        [DataMember(Name = "weburl")]
        public string Weburl { get; set; }


        [DataMember(Name = "zip")]
        public string Zip { get; set; }

        [DataMember(Name = "companylogourl")]
        public string Companylogourl { get; set; }


        //[DataMember(Name = "oninternet")]
        //public int oninternet { get; set; }

        //[DataMember(Name = "nofollowup")]
        //public int Nofollowup { get; set; }

    }
}