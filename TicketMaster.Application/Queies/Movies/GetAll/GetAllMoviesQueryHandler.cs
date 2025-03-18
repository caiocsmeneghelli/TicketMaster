using MediatR;
using TicketMaster.Application.ViewModels.Movies;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queies.Movies.GetAll
{
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieViewModel>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieViewModel>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var results = await _movieRepository.GetAllAsync();
            return new List<MovieViewModel>();
        }
    }
}
