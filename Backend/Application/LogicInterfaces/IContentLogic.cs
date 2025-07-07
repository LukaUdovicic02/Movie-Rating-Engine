using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.CastDtos;
using Domain.DTOs.ContentDtos;
using Domain.Models;

namespace Application.LogicInterfaces
{
    public interface IContentLogic
    {
        Task<IEnumerable<ContentDto>> GetContentsByTypePaginatedAsync(ContentType type, int page, int pageSize);

        Task<IEnumerable<ContentDto>> SearchContentAsync(string? title, DateTime? releaseDate, int? minRating);

        Task<ContentDto?> GetContentByIdAsync(Guid id);

    }
}
