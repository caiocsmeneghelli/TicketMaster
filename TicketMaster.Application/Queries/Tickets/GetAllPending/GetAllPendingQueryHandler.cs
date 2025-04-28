using MediatR;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.Tickets.GetAllPending
{
    public class GetAllPendingQueryHandler : IRequestHandler<GetAllPendingQuery, List<Ticket>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetAllPendingQueryHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<Ticket>> Handle(GetAllPendingQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketRepository.GetAllPendingAsync();
            return tickets;
        }
    }
}
