using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMaster.Application.Commands.MovieSessions.Create;
using TicketMaster.Application.Queries.MovieSessions.GetAll;
using TicketMaster.Application.Queries.MovieSessions.GetAllAvailable;
using TicketMaster.Application.Queries.MovieSessions.GetAllByMovieAndDate;

namespace TicketMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public SessionsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllMovieSessionsQuery();
            var result = await _mediatr.Send(query);
            return Ok(result);
        }

        [HttpGet("movie/{idMovie}/by-date")]
        public async Task<IActionResult> GetAllByMovieDate(int idMovie, [FromQuery]DateTime date)
        {
            var query = new GetAllMovieSessionsByMovieAndDateQuery();
            query.IdMovie = idMovie;
            query.Date = date;

            var result = await _mediatr.Send(query);
            return Ok(result);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllAvailable()
        {
            var query = new GetAllMovieSessionsAvailableQuery();
            var result = await _mediatr.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieSessionCommand command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }

    }
}
