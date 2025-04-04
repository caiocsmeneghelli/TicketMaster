using MediatR;
using TicketMaster.Application.Queries.Movies.GetAllActive;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.MovieSessions.GetAllByMovieAndDate
{
    public class GetAllMovieSessionsByMovieAndDateQueryHander : IRequestHandler<GetAllMovieSessionsByMovieAndDateQuery, List<MovieSession>>
    {
        private readonly IMovieSessionRepository _repository;

        public GetAllMovieSessionsByMovieAndDateQueryHander(IMovieSessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MovieSession>> Handle(GetAllMovieSessionsByMovieAndDateQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetAllByMovieAndDate(request.IdMovie, request.Date);
            return results;
        }
    }
}