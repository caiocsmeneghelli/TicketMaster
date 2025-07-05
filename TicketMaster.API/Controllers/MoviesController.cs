using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketMaster.API.Common;
using TicketMaster.Application.Commands.Movies.Create;
using TicketMaster.Application.Commands.Movies.Deactivate;
using TicketMaster.Application.Queries.Movies.GetAll;
using TicketMaster.Application.Queries.Movies.GetAllActive;
using TicketMaster.Application.ViewModels.Movies;
using TicketMaster.Domain.Common;

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
            return this.ToApiResponse(result);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActives([FromQuery]string? name)
        {
            var query = new GetAllMoviesActiveQuery(name);
            var result = await _mediatr.Send(query);
            return this.ToApiResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command)
        {
            Result<int> result = await _mediatr.Send(command);
            return this.ToApiResponse(result);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> InactivateMovie(int id)
        {
            var command = new DeactivateMovieCommand(id);
            Result result = await _mediatr.Send(command);
            return this.ToApiResponse(result);
        }
    }
}
