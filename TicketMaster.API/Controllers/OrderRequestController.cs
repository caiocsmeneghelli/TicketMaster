using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketMaster.API.Common;
using TicketMaster.Application.Commands.OrderRequests.Create;
using TicketMaster.Application.Helpers.Pagination;
using TicketMaster.Application.Queries.OrderRequests.List;
using TicketMaster.Application.ViewModels.OrderRequests;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;

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

        [HttpGet("list")]
        public async Task<IActionResult> List([FromQuery] PageRequest pageRequest)
        {
            var command = new ListOrderRequestQuery { PageRequest = pageRequest };
            var result = await _mediatr.Send(command);
            return this.ToApiResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequestCommand command)
        {
            var result = await _mediatr.Send(command);
            return this.ToApiResponse(result);
        }


        // to-do
        [HttpPut]
        public async Task<IActionResult> Cancel()
        {
            return Ok();
        }
    }
}