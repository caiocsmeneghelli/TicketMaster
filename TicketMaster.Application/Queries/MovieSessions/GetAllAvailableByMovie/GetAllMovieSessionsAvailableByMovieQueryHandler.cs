using AutoMapper;
using MediatR;
using TicketMaster.Application.ViewModels.MovieSessions;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.MovieSessions.GetAllAvailableByMovie
{
    public class GetAllMovieSessionsAvailableByMovieQueryHandler : IRequestHandler<GetAllMovieSessionsAvailableByMovieQuery, List<MovieSessionViewModel>>
    {
        private readonly IMovieSessionRepository _movieSessionRepository;
        private readonly IMapper _mapper;

        public GetAllMovieSessionsAvailableByMovieQueryHandler(IMovieSessionRepository movieSessionRepository, IMapper mapper)
        {
            _movieSessionRepository = movieSessionRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieSessionViewModel>> Handle(GetAllMovieSessionsAvailableByMovieQuery request, CancellationToken cancellationToken)
        {
            var results = await _movieSessionRepository.GetAllAvailableByMovieAsync(request.IdMovie);
            var vwModels = _mapper.Map<List<MovieSessionViewModel>>(results);
            return vwModels;
        }
    }
}
