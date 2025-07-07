using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.DaoInterfaces
{
    public interface IReviewDao
    {
        Task CreateAsync(Review review);

        Task<IEnumerable<Review>> GetByContentIdAsync(Guid contentId);
    }
}
