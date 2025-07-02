using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Models;

namespace Application.Logic 
{
    public class ContentLogic : IContentLogic
    {
        private readonly IContentDao contentDao; 

        public ContentLogic(IContentDao dao)
        {
            contentDao = dao;
        }

        public async Task<IEnumerable<Content>> GetAllContentAsync()
        {
            return await contentDao.GetAllContentAsync();
        }

        public async Task<Content?> GetContentByIdAsync(Guid id)
        {
            
            if(id == Guid.Empty)
            {
                throw new ValidationException("Content cannot be empty");
            }

            var content = await contentDao.GetContentByIdAsync(id);

            return content;

        }
    }
}
