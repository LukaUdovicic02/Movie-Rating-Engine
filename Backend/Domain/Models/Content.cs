using System.ComponentModel.DataAnnotations;


namespace Domain.Models
{

    public enum ContentType
    {
        Movie,
        TVShow
    }

    public class Content
    {
        [Key]
        public Guid ContentId { get; set; }
        [Required]

        [MaxLength(100)]
        public string Title { get; set; }
        [Required]

        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        // Movie or TV Show
        public ContentType Type { get; set; }

        // image url as a string 
        public string ImageURL { get; set; }

        // One to many with Reviews
        public ICollection<Review> Reviews { get; set; }

        // Many to many with Cast
        public ICollection<ContentCast> ContentCasts { get; set; }

        public Content() {}

    }
}
