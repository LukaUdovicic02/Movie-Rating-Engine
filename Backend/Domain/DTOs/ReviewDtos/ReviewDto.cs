using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.ReviewDtos
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public int rating { get; set; }
    }

    public class ReviewCreateDto
    {
        public Guid ContentId { get; set; } 
        public int Rating { get; set; }
    }
}
