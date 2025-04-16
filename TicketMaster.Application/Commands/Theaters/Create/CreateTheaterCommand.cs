using MediatR;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.Theaters.Create
{
    public class CreateTheaterCommand : IRequest<Result<int>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }
}
