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

        public async Task<IEnumerable<Cast>> GetCastByContentIdAsync(Guid contentId)
        {
            return await context.ContentCasts
                .Where(c => c.ContentId == contentId)
                .Include(cc => cc.Cast)
                .Select(cc => cc.Cast)
                .ToListAsync();
        }

        public async Task<Content?> GetContentByIdAsync(Guid contentId)
        {
            return await context.Contents.FirstOrDefaultAsync(c => c.ContentId == contentId);
        }

        public async Task<IEnumerable<Content?>> GetContentsByTypePaginatedAsync(ContentType type, int page, int pageSize)
        {
            return await context
                .Contents.Where(t => t.Type.Equals(type))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        

        public async Task<IEnumerable<Content>> SearchContentAsync(string? title, DateTime? releaseDate, int? minRating)
        {
            IQueryable<Content> query = context.Contents.Include(c => c.Reviews).AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
                query = query.Where(c => c.Title.ToLower().Equals(title.ToLower()));

            if (releaseDate.HasValue)
                query = query.Where(c => c.ReleaseDate > releaseDate.Value);

            if (minRating.HasValue)
            {
                query = query.Where(c =>
                    c.Reviews.Any() &&
                    c.Reviews.Average(r => r.Rating) >= minRating.Value
                );
            }

            var result = await query
            .OrderByDescending(c => c.Reviews.Any() ? c.Reviews.Average(r => r.Rating) : 0)
            .ToListAsync();

            return result;
        }



    }


}
