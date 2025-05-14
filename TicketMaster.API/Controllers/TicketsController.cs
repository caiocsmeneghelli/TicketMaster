using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketMaster.Application.Commands.Tickets.Cancel;
using TicketMaster.Application.Queries.Tickets.GetAllPending;
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
            if (result.IsFailure) { return NotFound(result); }

            return Ok(result);
        }

        [HttpPut("cancel/{guid}")]
        public async Task<IActionResult> Cancel(Guid guid)
        {
            var command = new CancelTicketCommand(guid);
            var result = await _mediatr.Send(command);

            if (!result.IsSuccess)
            {
                // use result pattern
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetAllPending()
        {
            var query = new GetAllPendingQuery();
            var result = await _mediatr.Send(query);

            return Ok(result);
        }
    }
}
