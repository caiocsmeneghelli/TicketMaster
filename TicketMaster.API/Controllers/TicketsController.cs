using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketMaster.Application.Commands.Tickets.Cancel;
using TicketMaster.Application.Commands.Tickets.Create;
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
        public async Task<IActionResult> CreateAsync(CreateTicketCommand command)
        {
            var result = await _mediatr.Send(command);
            if (!result.IsSuccess)
            {
                // use result pattern
                return BadRequest(result.Error);
            }

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
                return BadRequest(result.Error);
            }

            return Ok(result);
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetAllPending()
        {
            return Ok();
        }
    }
}
