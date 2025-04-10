using MediatR;
using TicketMaster.Domain.Enums;

namespace TicketMaster.Application.Commands.MovieSessions.Create
{
    public class CreateMovieSessionCommand : IRequest<int>
    {
        public int IdMovie { get; set; }
        public int IdAuditorium { get; set; }
        public EAudioAttribute AudioAttribute { get; set; }
        public EImageAttribute ImageAttribute { get; set; }
        public DateTime SessionTime { get; set; }
    }
}
