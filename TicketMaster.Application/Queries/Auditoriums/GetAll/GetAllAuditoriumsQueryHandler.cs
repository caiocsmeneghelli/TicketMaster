using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.ViewModels.Auditorium;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.Auditoriums.GetAll
{
    public class GetAllAuditoriumsQueryHandler : IRequestHandler<GetAllAuditoriumsQuery, List<AuditoriumViewModel>>
    {
        private readonly IAuditoriumRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAuditoriumsQueryHandler(IAuditoriumRepository repository, IMapper mapper = null)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AuditoriumViewModel>> Handle(GetAllAuditoriumsQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetAllAsync();
            var vwModels = _mapper.Map<List<AuditoriumViewModel>>(results);
            return vwModels;
        }
    }
}
