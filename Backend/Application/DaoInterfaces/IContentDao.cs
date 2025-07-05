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
        Task<IEnumerable<Content>> GetAllContentAsync();
        Task<Content?> GetContentByIdAsync(Guid id);

        Task<Content?> GetContentByTitleAsync(string title);

        Task<Content?> GetContentByTypeAsync(ContentType type);

        Task<Content?> GetContentByRelaseDateAsync(DateTime dateRelased);

        Task<IEnumerable<Content?>> GetContentsByTypePaginatedAsync(ContentType type, int page, int pageSize);



    }
}
