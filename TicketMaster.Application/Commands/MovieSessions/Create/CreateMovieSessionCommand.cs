using MediatR;
using TicketMaster.Domain.Enums;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.MovieSessions.Create
{
    public class CreateMovieSessionCommand : IRequest<Result>
    {
        public int IdMovie { get; set; }
        public int IdAuditorium { get; set; }
        public EAudioAttribute AudioAttribute { get; set; }
        public EImageAttribute ImageAttribute { get; set; }
        public DateTime SessionTime { get; set; }
        public decimal TicketValue { get; set; }
    }
}
