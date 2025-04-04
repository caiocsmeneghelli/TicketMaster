using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMaster.Application.Commands.Auditoriums.Create;
using TicketMaster.Application.Queries.Auditoriums.GetAll;
using TicketMaster.Application.Queries.Auditoriums.GetAllByTheater;
using TicketMaster.Domain.Entities;

namespace TicketMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriumsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public AuditoriumsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllAuditoriumsQuery();
            var results = await _mediatr.Send(query);
            return Ok(query);
        }

        [HttpGet("by-theater/{idTheater}")]
        public async Task<IActionResult> GetAllByTheater(int idTheater)
        {
            var query = new GetAllAuditoriumsByTheaterQuery();
            query.IdTheater = idTheater;
            var results = await _mediatr.Send(query);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAuditoriumCommand command)
        {
            int idAuditorium = await _mediatr.Send(command);
            return Ok(idAuditorium);
        }
    }
}
