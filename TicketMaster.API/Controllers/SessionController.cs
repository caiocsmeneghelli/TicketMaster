using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Retorna todas
            return Ok();
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
