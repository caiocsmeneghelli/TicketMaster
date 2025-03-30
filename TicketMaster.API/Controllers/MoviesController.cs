using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMaster.Application.Commands.Movies.Create;
using TicketMaster.Application.Queies.Movies.GetAll;
using TicketMaster.Application.Queies.Movies.GetAllActive;

namespace TicketMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public MoviesController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllMoviesQuery();
            var result = await _mediatr.Send(query);
            return Ok(result);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActives([FromQuery]string? name)
        {
            var query = new GetAllMoviesActiveQuery(name);
            var result = await _mediatr.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieCommand command)
        {
            var idMovie = await _mediatr.Send(command);
            return Ok(idMovie);
        }
    }
}
