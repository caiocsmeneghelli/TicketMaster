using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.Tickets.GetByGuid
{
    public class GetTicketByGuidQueryHandler : IRequestHandler<GetTicketByGuidQuery, Ticket?>
    {
        private readonly ITicketRepository _repository;

        public GetTicketByGuidQueryHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Ticket?> Handle(GetTicketByGuidQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetByGuidAsync(request.Guid);
            if (ticket == null) { return null; }

            // add mapper
            return ticket;
        }
    }
}
