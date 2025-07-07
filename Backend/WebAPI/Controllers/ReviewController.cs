using Application.LogicInterfaces;
using Domain.DTOs.ReviewDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewLogic reviewLogic;

        public ReviewController(IReviewLogic reviewLogic) => this.reviewLogic = reviewLogic;


        [HttpPost]
        public async Task<ActionResult> PostReview([FromBody] ReviewCreateDto dto)
        {
            try
            {
                var review = reviewLogic.AddReviewAsync(dto.ContentId, dto.Rating);
                return Ok(review);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{contentId:guid}")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviewsByContentId([FromRoute] Guid contentId)
        {
            try
            {
                var reviews = await reviewLogic.GetReviewsByContentAsync(contentId);
                return Ok(reviews);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
