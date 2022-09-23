using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SpikeRest.Models
{
    [DataContract]
    public class SalesPlan
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "invno")]
        public string Invno { get; set; }

        [DataMember(Name = "mfg")]
        public string Mfg { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "samjvp")]
        public string SamJvp { get; set; }

        [DataMember(Name = "jvpdescription")]
        public string Jvpdescription { get; set; }

        [DataMember(Name = "serial")]
        public string Serial { get; set; }

        [DataMember(Name = "jvpinvno")]
        public string Jvpinvno { get; set; }

        [DataMember(Name = "machinedescription")]
        public string Machinedescription { get; set; }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////
        /// description_other is where I left off
        /// </summary>
        /// 

        [DataMember(Name = "accountnumber")]
        public string Accountnumber { get; set; }

        [DataMember(Name = "addbyname")]
        public string Addbyname { get; set; }

        [DataMember(Name = "additionaldetails")]
        public string Additionaldetails { get; set; }

        [DataMember(Name = "agreeddate")]
        public string Agreeddate { get; set; }

        [DataMember(Name = "checkauction")]
        public string Checkauction { get; set; }

        [DataMember(Name = "checkprivate")]
        public string Checkprivate { get; set; }

        [DataMember(Name = "checkother")]
        public string Checkother { get; set; }

        [DataMember(Name = "commauction")]
        public string Commauction { get; set; }

        [DataMember(Name = "commprivate")]
        public string Commprivate { get; set; }

        [DataMember(Name = "commother")]
        public string Commother { get; set; }

        [DataMember(Name = "comments")]
        public string Comments { get; set; }


        [DataMember(Name = "condition")]
        public string Condition { get; set; }

        [DataMember(Name = "conditionservice")]
        public string Conditionservice { get; set; }

        [DataMember(Name = "daystosellauction")]
        public string Daystosellauction { get; set; }

        
        [DataMember(Name = "daystosellprivate")]
        public string Daystosellprivate { get; set; }

        [DataMember(Name = "daystosellother")]
        public string Daystosellother { get; set; }



        [DataMember(Name = "disposition")]
        public string Disposition { get; set; }

        [DataMember(Name = "expensesauction")]
        public string Expensesauction { get; set; }

        [DataMember(Name = "expensesprivate")]
        public string Expensesprivate { get; set; }

        [DataMember(Name = "expensesother")]
        public string Expensesother { get; set; }

        [DataMember(Name = "fmvauction")]
        public string Fmvauction { get; set; }

        [DataMember(Name = "fmvprivate")]
        public string Fmvprivate { get; set; }

        [DataMember(Name = "fmvother")]
        public string Fmvother { get; set; }


        [DataMember(Name = "locationcode")]
        public string Locationcode { get; set; }

        [DataMember(Name = "locname")]
        public string Locname { get; set; }

        [DataMember(Name = "nbv")]
        public string Nbv { get; set; }

        [DataMember(Name = "originalpurchaseprice")]
        public string Originalpurchaseprice { get; set; }

        [DataMember(Name = "pmsapprovaldate")]
        public string Pmsapprovaldate { get; set; }

        [DataMember(Name = "pmsapprovalsentfor")]
        public string Pmsapprovalsentfor { get; set; }

        [DataMember(Name = "pmsapprovedbyname")]
        public string Pmsapprovedbyname { get; set; }

        [DataMember(Name = "pmsapprovedflag")]
        public string Pmsapprovedflag { get; set; }

        [DataMember(Name = "pmsdisapprovaldate")]
        public string Pmsdisapprovaldate { get; set; }

      

        [DataMember(Name = "otherinfo")]
        public string Otherinfo { get; set; }

        [DataMember(Name = "repair")]
        public string Repair { get; set; }

        [DataMember(Name = "responsiblesalesmanemail")]
        public string Responsiblesalesmanemail { get; set; }

        [DataMember(Name = "returnauction")]
        public string Returnauction { get; set; }

        [DataMember(Name = "returnprivate")]
        public string Returnprivate { get; set; }

        [DataMember(Name = "returnother")]
        public string Returnother { get; set; }

        [DataMember(Name = "situation")]
        public string Situation { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "surpluscontact")]
        public string Surpluscontact { get; set; }

        [DataMember(Name = "validfor")]
        public string Validfor { get; set; }

        [DataMember(Name = "yrmfg")]
        public string Yrmfg { get; set; }

       




    }
}