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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentDto>>> GetAllContent()
        {
            try
            {
                var content = await contentLogic.GetAllContentAsync();

                return Ok(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContentDto>> GetContentById([FromRoute] Guid id)
        {
            try
            {
                var content = await contentLogic.GetContentByIdAsync(id);


                if (content == null)
                {
                    return NotFound($"Content with this ID: {id} not found");
                }

                return Ok(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("title")]
        public async Task<ActionResult<ContentDto>> GetContentByTitle([FromQuery] string title)
        {
            try
            {
                var content = await contentLogic.GetContentByTitleAsync(title);

                if (content == null)
                {
                    return NotFound($"Content with this title: {title} does not exist");
                }

                return Ok(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }


        [HttpGet("Released")]
        public async Task<ActionResult<ContentDto>> GetContentByReleaseDate([FromQuery] DateTime releaseDate)
        {
            try
            {
                var content = await contentLogic.GetContentByRelaseDateAsync(releaseDate);

                if (content == null)
                {
                    return NotFound($"Content with this relased date: {releaseDate} does not exist");
                }

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
