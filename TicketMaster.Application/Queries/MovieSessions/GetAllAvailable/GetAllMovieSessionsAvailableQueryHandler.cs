using MediatR;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.MovieSessions.GetAllAvailable
{
    public class GetAllMovieSessionsAvailableQueryHandler : IRequestHandler<GetAllMovieSessionsAvailableQuery, List<MovieSession>>
    {
        private readonly IMovieSessionRepository _repository;

        public GetAllMovieSessionsAvailableQueryHandler(IMovieSessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MovieSession>> Handle(GetAllMovieSessionsAvailableQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAvailableAsync();
            return result;
        }
    }
}