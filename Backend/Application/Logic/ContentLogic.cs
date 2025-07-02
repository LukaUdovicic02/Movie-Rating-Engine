using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.LogicInterfaces;
using Domain.Models;

namespace Application.Logic 
{
    public class ContentLogic : IContentLogic
    {
        public ContentLogic() {}

        public Task<IEnumerable<Content>> GetAllContentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Content?> GetContentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
