using Learn_CQRS.Features.Heros.DeleteHeroById;
using Learn_CQRS.Features.Heros.GetHeroById;
using Learn_CQRS.Features.Heros.PostHero;
using Learn_CQRS.Features.Heros.UpdateHeroById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Learn_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerosController : ControllerBase
    {
        private readonly ISender _sender;
        public HerosController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> PostHero([FromBody]PostHeroCommand request, CancellationToken cancellationToken)
        {
            var heroId = await _sender.Send(request, cancellationToken);
            return StatusCode(201, new
            {
                message = "Create hero successfully.",
                heroId,
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetHeroById([FromQuery]GetHeroByIdQuery request, CancellationToken cancellationToken)
        {
            var hero = await _sender.Send(request, cancellationToken);
            if (hero is null) return StatusCode(404, new { 
                message = "Hero not found.",
                statusCode = 404
            });
            return StatusCode(200, new
            {
                message = "Get hero successfully.",
                hero,
            });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHeroById([FromQuery]DeleteHeroByIdCommand request, CancellationToken cancellationToken)
        {
            var isSuccess = await _sender.Send(request, cancellationToken);
            if(!isSuccess)
            {
                return StatusCode(404, new { 
                    message = "Hero not found.",
                    statusCode = 404
                });
            }
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHeroById([FromBody]UpdateHeroByIdCommand request, CancellationToken cancellationToken)
        {
            var isSuccess = await _sender.Send(request, cancellationToken);
            if (!isSuccess)
            {
                return StatusCode(404, new
                {
                    message = "Hero not found.",
                    statusCode = 404
                });
            }
            return StatusCode(200, new
            {
                message = "Update hero successfully.",
                statusCode = 200
            });
        }
    }
}
