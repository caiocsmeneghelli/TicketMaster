using AutoMapper;
using MediatR;
using TicketMaster.Application.ViewModels.Movies;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.Movies.GetAll
{
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieViewModel>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetAllMoviesQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieViewModel>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var results = await _movieRepository.GetAllAsync();
            return _mapper.Map<List<MovieViewModel>>(results);
        }
    }
}
