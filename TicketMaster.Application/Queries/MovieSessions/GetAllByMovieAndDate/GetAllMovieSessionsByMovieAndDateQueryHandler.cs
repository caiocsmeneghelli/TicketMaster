using MediatR;
using TicketMaster.Application.DTOs;
using TicketMaster.Application.Repositories;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.MovieSessions.GetAllByMovieAndDate
{
    public class GetAllMovieSessionsByMovieAndDateQueryHander : IRequestHandler<GetAllMovieSessionsByMovieAndDateQuery, MovieWithTheatersDto>
    {
        private readonly IMovieSessionRepository _repository;
        private readonly ICachedMovieSessionRepository _cache;

        public GetAllMovieSessionsByMovieAndDateQueryHander(IMovieSessionRepository repository, ICachedMovieSessionRepository cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<MovieWithTheatersDto> Handle(GetAllMovieSessionsByMovieAndDateQuery request, CancellationToken cancellationToken)
        {
            var result = await _cache.GetMovieByMovieAndDate(request.IdMovie, request.Date);
            return result;
        }
    }
}