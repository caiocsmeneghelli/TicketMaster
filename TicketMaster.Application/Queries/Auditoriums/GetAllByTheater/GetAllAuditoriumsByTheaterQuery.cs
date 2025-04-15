using MediatR;
using TicketMaster.Application.ViewModels.Auditorium;

namespace TicketMaster.Application.Queries.Auditoriums.GetAllByTheater
{
    public class GetAllAuditoriumsByTheaterQuery : IRequest<List<AuditoriumViewModel>>
    {
        public int IdTheater { get; set; }
    }
}
