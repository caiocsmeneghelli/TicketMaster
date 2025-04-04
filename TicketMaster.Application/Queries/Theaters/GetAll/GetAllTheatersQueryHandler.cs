using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.Theaters.GetAll
{
    public class GetAllTheatersQueryHandler : IRequestHandler<GetAllTheatersQuery, List<Theater>>
    {
        private readonly ITheaterRepository _repository;

        public GetAllTheatersQueryHandler(ITheaterRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Theater>> Handle(GetAllTheatersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
