using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SubscriptionService.Api.Commands;

namespace SubscriptionService.Controllers
{
    [Route("api/subscription")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionsController(IMediator mediator) => _mediator = mediator;

        [HttpGet("1")]
        public async Task<IActionResult> Get()
        {
            return new JsonResult(1);
        }

        [HttpPost("addrss")]
        public async Task<IActionResult> CreateUserRss([FromBody] CreateUserRssCommand request)
        {
            var result = await _mediator.Send(request);
            return new JsonResult(result);
        }
    }
}
