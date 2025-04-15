using AutoMapper;
using MediatR;
using TicketMaster.Application.ViewModels.Auditorium;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.Auditoriums.GetAllByTheater
{
    public class GetAllAuditoriumsByTheaterQueryHandler : IRequestHandler<GetAllAuditoriumsByTheaterQuery, List<AuditoriumViewModel>>
    {
        private readonly IAuditoriumRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAuditoriumsByTheaterQueryHandler(IAuditoriumRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AuditoriumViewModel>> Handle(GetAllAuditoriumsByTheaterQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetAllByTheaterAsync(request.IdTheater);
            var vwModels = _mapper.Map<List<AuditoriumViewModel>>(results);
            return vwModels;
        }
    }
}
