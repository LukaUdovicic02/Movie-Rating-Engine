using Application.LogicInterfaces;
using Domain.DTOs.ContentDtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentLogic contentLogic;

        public ContentController(IContentLogic contentLogic)
        {
            this.contentLogic = contentLogic;
        }

        [HttpGet("type")]
        public async Task<ActionResult<IEnumerable<ContentDto>>> GetContentByTypePaginated(
            [FromQuery] ContentType type,
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10
            )
        {
            try
            {
                var content = await contentLogic.GetContentsByTypePaginatedAsync(type, page, pageSize);
                return Ok(content);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<ContentDto>>> SearchContent(
            [FromQuery] string? title,
            [FromQuery] DateTime? releaseDate)
        {
            try
            {
                var content = await contentLogic.SearchContentAsync(title, releaseDate);
                return Ok(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }



    }
}
