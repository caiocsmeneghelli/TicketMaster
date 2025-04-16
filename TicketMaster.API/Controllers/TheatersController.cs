using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMaster.API.Common;
using TicketMaster.Application.Commands.Theaters.Create;
using TicketMaster.Application.Queries.Theaters.GetAll;
using TicketMaster.Domain.Common;

namespace TicketMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public TheatersController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediatr.Send(new GetAllTheatersQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<int>>> Create([FromBody] CreateTheaterCommand command)
        {
            var result = await _mediatr.Send(command);
            var response = ApiResponse<int>.FromResult(result);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
