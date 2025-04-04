using MediatR;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queries.MovieSessions.GetAll{
    public class GetAllMovieSessionsQuery : IRequest<List<MovieSession>>
    {
    }
}