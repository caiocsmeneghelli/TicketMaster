using MediatR;
using TicketMaster.Domain.Enums;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.Auditoriums.Create
{
    public class CreateAuditoriumCommand : IRequest<Result<int>>
    {
        public string Name { get; set; }
        public int TotalSeats { get; set; }
        public EAuditoriumType AuditoriumType { get; set; }
        public int IdTheater { get; set; }
    }
}
