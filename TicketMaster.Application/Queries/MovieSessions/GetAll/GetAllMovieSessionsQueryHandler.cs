using MediatR;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.MovieSessions.GetAll
{
    public class GetAllSessionsQueryHandler : IRequestHandler<GetAllMovieSessionsQuery, List<MovieSession>>
    {
        private readonly IMovieSessionRepository _repository;

        public GetAllSessionsQueryHandler(IMovieSessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MovieSession>> Handle(GetAllMovieSessionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();
            return result;
        }
    }
}