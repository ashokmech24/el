using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using porthealthvis.DataBase;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace porthealthvis.Models
{
    public class Appoinment
    {
        public string? Id { get; set; }  
        public string? TransuctionID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public DateTime Dob { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Countrytovisit { get; set; }
        public string? Passportno { get; set; }
        public DateTime Expdate { get; set; }
        public string? Add { get; set; }
        public string? City { get; set; }
        public long? Phone { get; set; }
        public int Pincode { get; set; }
        public string? Egg_allergic { get; set; }
        public DateTime Appdate { get; set; }
        public int Amount { get; set; }
    }



}
