using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queies.Auditoriums.GetAll
{
    public class GetAllAuditoriumsQueryHandler : IRequestHandler<GetAllAuditoriumsQuery, List<Auditorium>>
    {
        private readonly IAuditoriumRepository _repository;

        public GetAllAuditoriumsQueryHandler(IAuditoriumRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Auditorium>> Handle(GetAllAuditoriumsQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetAllAsync();
            return results;
        }
    }
}
