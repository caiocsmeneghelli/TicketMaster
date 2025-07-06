using AutoMapper;
using MediatR;
using TicketMaster.Application.Repositories;
using TicketMaster.Application.ViewModels.Movies;

namespace TicketMaster.Application.Queries.Movies.GetAllActive
{
    public class GetAllMoviesActiveQueryHandler : IRequestHandler<GetAllMoviesActiveQuery, List<MovieViewModel>>
    {
        private readonly ICachedMovieRepository _cacheReposiory;
        private readonly IMapper _mapper;

        public GetAllMoviesActiveQueryHandler(ICachedMovieRepository cacheRepository, IMapper mapper)
        {
            _cacheReposiory = cacheRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieViewModel>> Handle(GetAllMoviesActiveQuery request, CancellationToken cancellationToken)
        {
            var result = await _cacheReposiory.GetAllActiveMovies();
            var vwModel = _mapper.Map<List<MovieViewModel>>(result);
            return vwModel;
        }
    }
}
