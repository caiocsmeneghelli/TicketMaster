using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketMaster.API.Common;
using TicketMaster.Application.Commands.OrderRequests.Create;
using TicketMaster.Domain.Common;

namespace TicketMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderRequestController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public OrderRequestController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            return Ok();
        }

        [HttpGet("list")]
        public async Task<IActionResult> List(){
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequestCommand command)
        {
            var result = await _mediatr.Send(command);
            if (result.IsFailure)
            {
                return BadRequest(ApiResponse<Guid>.FromResult(result));
            }
            return Ok(ApiResponse<Guid>.FromResult(result));
        }

        [HttpPut]
        public async Task<IActionResult> Cancel(){
            return Ok();
        }
    }
}