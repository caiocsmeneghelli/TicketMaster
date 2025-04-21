using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketMaster.Application.Queries.Tickets.GetByGuid;

namespace TicketMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public TicketsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(Guid guid)
        {
            var query = new GetTicketByGuidQuery(guid);
            var result = await _mediatr.Send(query);

            // use result pattern
            if (result is null) { return NotFound(); }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        {
            return Ok();
        }

        [HttpPut("cancel/{guid")]
        public async Task<IActionResult> Cancel(Guid guid)
        {
            return Ok();
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetAllPending()
        {
            return Ok();
        }
    }
}
