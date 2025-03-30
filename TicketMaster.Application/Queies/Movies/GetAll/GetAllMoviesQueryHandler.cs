using MediatR;
using TicketMaster.Application.ViewModels.Movies;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queies.Movies.GetAll
{
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<Movie>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var results = await _movieRepository.GetAllAsync();
            return results;
        }
    }
}
