using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ContentCast
    {
        public Guid ContentId { get; set; }
        public Content Content { get; set; }

        public Guid CastId { get; set; }
        public Cast Cast { get; set; }

        public ContentCast() { }
    }
}
