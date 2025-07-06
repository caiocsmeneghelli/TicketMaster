using MediatR;
using TicketMaster.Application.ViewModels.Movies;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queries.MovieSessions.GetAllByMovieAndDate
{
    public class GetAllMovieSessionsByMovieAndDateQuery : IRequest<MovieWithTheatersViewModel>
    {
        public int IdMovie { get; set; }
        public DateTime Date { get; set; }
    }
}