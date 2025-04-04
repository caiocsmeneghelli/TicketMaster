using MediatR;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queries.MovieSessions.GetAllByMovieAndDate
{
    public class GetAllMovieSessionsByMovieAndDateQuery : IRequest<List<MovieSession>>
    {
        public int IdMovie { get; set; }
        public DateTime Date { get; set; }
    }
}