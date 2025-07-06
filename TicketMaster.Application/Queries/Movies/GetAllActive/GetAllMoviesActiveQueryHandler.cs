using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.ViewModels.Movies;
using TicketMaster.Domain.Repositories;

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
