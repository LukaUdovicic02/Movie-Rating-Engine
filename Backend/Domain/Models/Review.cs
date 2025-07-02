using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Review
    {
        [Key]
        public Guid ReviewId { get; set; }
        
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        // Foreign Key
        public Guid ContentId { get; set; }

        // Navigation Property
        public Content Content { get; set; }
    }
}