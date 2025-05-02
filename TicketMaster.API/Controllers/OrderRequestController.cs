using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> List(){
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Cancel(){
            return Ok();
        }
    }
}