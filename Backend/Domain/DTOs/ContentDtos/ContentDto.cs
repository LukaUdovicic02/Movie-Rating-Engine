using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.CastDtos;
using Domain.Models;

namespace Domain.DTOs.ContentDtos
{
    public class ContentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ContentType Type { get; set; }
        public string ImageURL { get; set; }
        public IEnumerable<CastDto> Casts { get; set; }
        public double AverageRating { get; set; }
        public int RatingCount { get; set; }



    }
}
