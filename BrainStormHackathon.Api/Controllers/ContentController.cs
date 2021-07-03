using System.Threading.Tasks;
using BrainStormHackathon.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrainStormHackathon.Api.Controllers
{
    [Route("api/content")]
    public class ContentController : ControllerBase
    {
        private readonly IContentViewService _viewService;

        public ContentController(IContentViewService viewService)
        {
            _viewService = viewService;
        }
        
        [HttpGet("/users/{userId}/videos")]
        public async Task<IActionResult> GetContentByUserAsync([FromRoute] int userId, [FromQuery] string orderBy)
        {
            var result = await _viewService.SearchByUserIdAsync(userId, orderBy);
            return new JsonResult(result);
        }
        
        [HttpGet("/users/{userId}/videos/{videoId}")]
        public async Task<IActionResult> GetContentByUserAsync([FromRoute] int userId,[FromRoute] int videoId, [FromQuery] string orderBy)
        {
            var result = await _viewService.SearchAsync(userId,videoId, orderBy);
            return new JsonResult(result);
        }
    }
}