using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.LogicInterfaces
{
    public interface IContentLogic
    {
        Task<IEnumerable<Content>> GetAllContentAsync();
        Task<Content?> GetContentByIdAsync(int id);

    }
}
