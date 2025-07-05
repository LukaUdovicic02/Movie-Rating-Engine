using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.ContentDtos;
using Domain.Models;

namespace Application.DaoInterfaces
{
    public interface IContentDao
    {

        Task<IEnumerable<Content?>> SearchContentAsync(string? title, DateTime? releasedDate);

        Task<IEnumerable<Content?>> GetContentsByTypePaginatedAsync(ContentType type, int page, int pageSize);



    }
}
