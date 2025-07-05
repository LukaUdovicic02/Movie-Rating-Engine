using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.ContentDtos;
using Domain.Models;

namespace Application.LogicInterfaces
{
    public interface IContentLogic
    {
        Task<IEnumerable<ContentDto>> SearchContentAsync(string? title, DateTime? releasedDate);

        Task<IEnumerable<ContentDto>> GetContentsByTypePaginatedAsync(ContentType type, int page, int pageSize);


    }
}
