using MediatR;
using TicketMaster.Application.DTOs;

namespace TicketMaster.Application.Queries.MovieSessions.GetAllByMovieAndDate
{
    public class GetAllMovieSessionsByMovieAndDateQuery : IRequest<MovieWithTheatersDto>
    {
        public int IdMovie { get; set; }
        public DateTime Date { get; set; }
    }
}