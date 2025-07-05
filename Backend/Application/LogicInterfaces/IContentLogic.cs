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
        Task<IEnumerable<ContentDto>> GetAllContentAsync();
        Task<ContentDto?> GetContentByIdAsync(Guid id);

        Task<ContentDto?> GetContentByTitleAsync(string title);

        Task<ContentDto?> GetContentByTypeAsync(ContentType type);

        Task<ContentDto?> GetContentByRelaseDateAsync(DateTime dateRelased);

        Task<IEnumerable<ContentDto>> GetContentsByTypePaginatedAsync(ContentType type, int page, int pageSize);


    }
}
