using MediatR;
using TicketMaster.Application.ViewModels.MovieSessions;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queries.MovieSessions.GetAll{
    public class GetAllMovieSessionsQuery : IRequest<List<MovieSessionViewModel>>
    {
    }
}