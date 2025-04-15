using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.ViewModels.Theaters;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.Theaters.GetAll
{
    public class GetAllTheatersQueryHandler : IRequestHandler<GetAllTheatersQuery, List<TheaterViewModel>>
    {
        private readonly ITheaterRepository _repository;
        private readonly IMapper _mapper;

        public GetAllTheatersQueryHandler(ITheaterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TheaterViewModel>> Handle(GetAllTheatersQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetAllAsync();
            var vwModels = _mapper.Map<List<TheaterViewModel>>(results);
            return vwModels;
        }
    }
}
