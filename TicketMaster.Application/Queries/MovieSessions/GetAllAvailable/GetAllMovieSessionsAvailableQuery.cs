using MediatR;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queries.MovieSessions.GetAllAvailable
{
    public class GetAllMovieSessionsAvailableQuery : IRequest<List<MovieSession>>
    {}
}