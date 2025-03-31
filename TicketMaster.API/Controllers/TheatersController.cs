using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMaster.Application.Commands.Theaters.Create;
using TicketMaster.Application.Queies.Theaters.GetAll;

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
            var result = _mediatr.Send(new GetAllTheatersQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTheaterCommand command)
        {
            int idTheater = await _mediatr.Send(command);
            return Ok(idTheater);
        }
    }
}
