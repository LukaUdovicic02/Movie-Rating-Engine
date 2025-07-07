using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DaoInterfaces;
using Domain.DTOs.ReviewDtos;

namespace Application.LogicInterfaces
{
    public interface IReviewLogic
    {
        Task AddReviewAsync(Guid contentId, int rating);
        Task<IEnumerable<ReviewDto>> GetReviewsByContentAsync(Guid contentId);

    }
}
