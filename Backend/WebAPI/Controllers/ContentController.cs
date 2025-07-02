using Application.LogicInterfaces;
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
        public async Task<ActionResult<IEnumerable<Content>>> GetAllContent()
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Content>> GetContentById([FromRoute] Guid id)
        {
            try
            {
                var content = await contentLogic.GetContentByIdAsync(id);
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
