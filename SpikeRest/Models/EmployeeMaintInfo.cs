using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class EmployeeMaintInfo
    {
        [DataMember(Name = "employeeid")]
        public string Employeeid { get; set; }

        [DataMember(Name = "firstname")]
        public string Firstname { get; set; }

        [DataMember(Name = "lastname")]
        public string Lastname { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "email2")]
        public string Email2 { get; set; }

        [DataMember(Name = "active")]
        public string Active { get; set; }

        [DataMember(Name = "activeforpricechange")]
        public string Activeforpricechange { get; set; }

        [DataMember(Name = "dateadded")]
        public string Dateadded { get; set; }

        [DataMember(Name = "issalesman")]
        public string Issalesman { get; set; }

        [DataMember(Name = "sendofferemail")]
        public string Sendofferemail { get; set; }

        [DataMember(Name = "sendpricechangeemail")]
        public string Sendpricechangeemail { get; set; }

        [DataMember(Name = "sendbatchquoteemail")]
        public string Sendbatchquoteemail { get; set; }

        [DataMember(Name = "sendchashrecievedemail")]
        public string Sendcashreceivedemail { get; set; }

        [DataMember(Name = "sendadvertsisingemail")]
        public string Sendadvertisingemail { get; set; }

        [DataMember(Name = "sendrequesttoaddmachine")]
        public string Sendrequesttoaddmachine { get; set; }

        [DataMember(Name = "securitylevel")]
        public string Securitylevel { get; set; }

        [DataMember(Name = "isspanish")]
        public string Isspanish { get; set; }

        [DataMember(Name = "canchangeprice")]
        public string Canchangeprice { get; set; }

        [DataMember(Name = "cansendpricechangeemail")]
        public string Cansendpricechangeemail { get; set; }

        [DataMember(Name = "canaddcustomers")]
        public string Canaddcustomers { get; set; }

        [DataMember(Name = "canaddinventory")]
        public string Canaddinventory { get; set; }

        [DataMember(Name = "candeleteparts")]
        public string Candeleteparts { get; set; }

        [DataMember(Name = "canremovefromoneliners")]
        public string Canremovefromoneliners { get; set; }

        [DataMember(Name = "canexcludeserial")]
        public string Canexcludeserial { get; set; }

        [DataMember(Name = "canupdatedealfields")]
        public string Canupdatedealfields { get; set; }

        [DataMember(Name = "canacceptoffer")]
        public string Canacceptoffer { get; set; }

        [DataMember(Name = "isprocurement")]
        public string Isprocurement { get; set; }

        [DataMember(Name = "cantagsold")]
        public string Cantagsold { get; set; }

        [DataMember(Name = "canapprovesalesorder")]
        public string Canapprovesalesorder { get; set; }

        [DataMember(Name = "createtaskforsaleorderapproval")]
        public string Createtaskforsaleorderapproval { get; set; }

        [DataMember(Name = "canadddeletemachineplan")]
        public string Canadddeletemachineplan { get; set; }

        [DataMember(Name = "canupdateinvcommission")]
        public string Canupdateinvcommission { get; set; }

        [DataMember(Name = "canapproveinvcommission")]
        public string Canapproveinvcommission { get; set; }

        [DataMember(Name = "worklocation")]
        public string Worklocation { get; set; }

        [DataMember(Name = "usespecprintingutility")]
        public string Usespecprintingutility { get; set; }

        [DataMember(Name = "isaccounting")]
        public string Isacounting { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "passcode")]
        public string Passcode { get; set; }

        [DataMember(Name = "mobiletheme")]
        public string Mobiletheme { get; set; }
    }
}