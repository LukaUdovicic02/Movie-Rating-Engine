using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DaoInterfaces;
using Domain.Models;
using EfcDataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.DAOs
{
    public class ContentEfcDao : IContentDao
    {
        private readonly MovieReviewEngineContext context;

        public ContentEfcDao(MovieReviewEngineContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Content>> GetAllContentAsync()
        {
            return await context.Contents.ToListAsync();
        }

        public async Task<Content?> GetContentByIdAsync(Guid id)
        {
            var content = await context.Contents.FirstOrDefaultAsync(c => c.ContentId == id);
            return content;
        }
    }
}
