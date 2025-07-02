using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cast
    {
        [Key]
        public Guid CastId { get; set; }

        [Required]
        // Name of the Actor
        public string Name { get; set; }

        // Many to Many with Content
        public ICollection<ContentCast> ContentCasts {  get; set; }


    }
}
