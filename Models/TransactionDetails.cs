using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace porthealthvis.Models
{
   


    public class TransactionDetails
    {
        [Key]
        public int Id { get; set; }
        public decimal amt { get; set; }
        public string merchant_id { get; set; }
        public string mer_txn { get; set; }
        public string f_code { get; set; }
        public string ipg_txn_id { get; set; }
        public string prod { get; set; }
        public string mmp_txn { get; set; }
        public string udf1 { get; set; }
        public string udf2 { get; set; }
        public string udf3 { get; set; }
        public string udf4 { get; set; }
        public string udf5 { get; set; }
        public string udf6 { get; set; }
        public string udf9 { get; set; }
        public string udf10 { get; set; }
        public string udf11 { get; set; }
        public string udf12 { get; set; }
        public string udf13 { get; set; }
        public string udf14 { get; set; }
        public string udf15 { get; set; }
        public string bank_name { get; set; }
        public string bank_txn { get; set; }
        public string auth_code { get; set; }
        public string signature { get; set; }
        public string scheme { get; set; }
        public string clientcode { get; set; }
        public decimal surcharge { get; set; }
        public string discriminator { get; set; }
        public string desc { get; set; }
    }

}
