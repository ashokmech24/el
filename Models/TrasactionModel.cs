using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace porthealthvis.Models
{

    public class TrasactionModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        public string TransactionID { get; set; }
        [Required]
        public string PaymentID { get; set; }
        [Required]
        public string AppoinMentDate { get; set; }
        [Required]
        public string TransactionDateTime { get; set; }
        [Required]
        public string Status { get; set; }
        public string? AuthCode { get; set; }
        public string? CardNumber { get; set; }
        public string? BankName { get; set; }
        public string? BankTrasactionID { get; set; }
        public string? BankType { get; set; }

    }
}
