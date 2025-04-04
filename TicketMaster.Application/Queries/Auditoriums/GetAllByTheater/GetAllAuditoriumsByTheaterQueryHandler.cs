using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.Auditoriums.GetAllByTheater
{
    public class GetAllAuditoriumsByTheaterQueryHandler : IRequestHandler<GetAllAuditoriumsByTheaterQuery, List<Auditorium>>
    {
        private readonly IAuditoriumRepository _repository;

        public GetAllAuditoriumsByTheaterQueryHandler(IAuditoriumRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Auditorium>> Handle(GetAllAuditoriumsByTheaterQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllByTheaterAsync(request.IdTheater);
        }
    }
}
