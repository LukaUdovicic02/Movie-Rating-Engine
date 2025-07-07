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
    public class ReviewDao : IReviewDao
    {
        private readonly MovieReviewEngineContext _engineContext;
        public ReviewDao(MovieReviewEngineContext ctx)
        {
            _engineContext = ctx;
        }

        public async Task CreateAsync(Review review)
        {
            await _engineContext.AddAsync(review);
            await _engineContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetByContentIdAsync(Guid contentId)
        {
            return await _engineContext.Reviews
                .Where(r => r.ContentId == contentId)
                .OrderByDescending(r => r.Rating)
                .ToListAsync();
        }
    }
}
