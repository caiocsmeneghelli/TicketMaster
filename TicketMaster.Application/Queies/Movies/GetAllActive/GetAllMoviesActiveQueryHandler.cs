using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.ViewModels.Movies;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queies.Movies.GetAllActive
{
    public class GetAllMoviesActiveQueryHandler : IRequestHandler<GetAllMoviesActiveQuery, List<MovieViewModel>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllMoviesActiveQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieViewModel>> Handle(GetAllMoviesActiveQuery request, CancellationToken cancellationToken)
        {
            var result = await _movieRepository.GetAllActiveAsync(request.Query);
            return new List<MovieViewModel>();
        }
    }
}
