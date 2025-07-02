using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.DaoInterfaces
{
    public interface IContentDao
    {
        Task<IEnumerable<Content>> GetAllContentAsync();
        Task<Content?> GetContentByIdAsync(Guid id);
    }
}
