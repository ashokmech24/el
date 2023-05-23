using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace porthealthvis.Models
{
    public class NotificationModel
    {
        [Key]
        public int Id { get; set; }
        public int Visibility { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? Footer { get; set; }
    }
}
