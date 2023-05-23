using System.ComponentModel.DataAnnotations;

namespace porthealthvis.Models
{
    public class NewAppointMent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TransactionID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Countrytovisit { get; set; }
        [Required]
        public string Passportno { get; set; }
        [Required]
        public DateTime Expdate { get; set; }
        [Required]
        public string Add { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public long Phone { get; set; }
        [Required]
        public int Pincode { get; set; }
        [Required]
        public string Egg_allergic { get; set; }
        [Required]
        public DateTime Appdate { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
