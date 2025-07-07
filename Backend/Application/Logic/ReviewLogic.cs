using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs.ReviewDtos;
using Domain.Models;

namespace Application.Logic
{
    public class ReviewLogic : IReviewLogic
    {

        private readonly IReviewDao reviewDao;
        private readonly IContentDao contentDao;

        public ReviewLogic(IReviewDao dao, IContentDao contentDao)
        {
            reviewDao = dao;
            this.contentDao = contentDao;
        }

        public async Task AddReviewAsync(Guid contentId, int rating)
        {
            if(rating < 0 || rating > 5)
            {
                throw new ValidationException("Rating has to be between 1 and 5");
            }

            var exists = await contentDao.GetCastByContentIdAsync(contentId);
            if (!exists.Any())
            {
                throw new ValidationException("Content does not exist");
            }

            var review = new Review
            {
                ReviewId = Guid.NewGuid(),
                ContentId = contentId,
                Rating = rating
            };

            await reviewDao.CreateAsync(review);

            
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByContentAsync(Guid contentId)
        {
            var reviews = await reviewDao.GetByContentIdAsync(contentId);

            var list = reviews.Select(r => new ReviewDto
            {
                Id = r.ReviewId,
                rating = r.Rating,
            });

            return list;
        }
    }
}
