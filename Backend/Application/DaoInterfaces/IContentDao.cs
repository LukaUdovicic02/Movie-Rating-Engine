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

        Task<IEnumerable<Content>> SearchContentAsync(string? title, DateTime? releaseDate, int? minRating);

        Task<IEnumerable<Content?>> GetContentsByTypePaginatedAsync(ContentType type, int page, int pageSize);

        Task<IEnumerable<Cast>> GetCastByContentIdAsync(Guid contentId);

        Task<Content?> GetContentByIdAsync(Guid id);

    }
}
