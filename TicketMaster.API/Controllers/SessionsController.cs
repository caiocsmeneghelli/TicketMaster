using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMaster.Application.Queries.MovieSessions.GetAll;

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

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            // Retorna ativos
            return Ok();
        }

        [HttpGet("active/by-date")]
        public async Task<IActionResult> GetAllActiveByDate([FromQuery]DateTime date, int idMovie)
        {
            // retorna todas sessoes por dia e por filme
            return Ok(date);
        }
    }
}
