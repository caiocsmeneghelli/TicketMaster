using AutoMapper;
using MediatR;
using TicketMaster.Application.ViewModels.MovieSessions;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.MovieSessions.GetAll
{
    public class GetAllSessionsQueryHandler : IRequestHandler<GetAllMovieSessionsQuery, List<MovieSessionViewModel>>
    {
        private readonly IMovieSessionRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSessionsQueryHandler(IMovieSessionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MovieSessionViewModel>> Handle(GetAllMovieSessionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();
            var viewModel = _mapper.Map<List<MovieSessionViewModel>>(result);
            return viewModel;
        }
    }
}