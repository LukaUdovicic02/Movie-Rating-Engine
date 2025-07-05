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

        public async Task<IEnumerable<Content?>> GetContentsByTypePaginatedAsync(ContentType type, int page, int pageSize)
        {
            return await context
                .Contents.Where(t => t.Type.Equals(type))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Content>> SearchContentAsync(string? title, DateTime? releasedDate)
        {
            IQueryable<Content> query = context.Contents;

            if (!string.IsNullOrWhiteSpace(title))
                query = query.Where(c => c.Title.ToLower().Equals(title.ToLower()));

            if (releasedDate.HasValue)
                query = query.Where(c => c.ReleaseDate > releasedDate.Value);

            return await query.ToListAsync();
        }



    }


}
