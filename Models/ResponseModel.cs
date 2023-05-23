using System.ComponentModel.DataAnnotations;

namespace porthealthvis.Models
{
    public class ResponseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Phone { get; set; }
        public decimal Surcharge { get; set; }
        public decimal Amt { get; set; }
        public string Name { get; set; }
        public string TransuctionID { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string BankName { get; set; }
        public string Description { get; set; }

    }
}
