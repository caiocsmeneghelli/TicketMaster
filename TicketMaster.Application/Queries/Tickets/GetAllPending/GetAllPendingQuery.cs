using MediatR;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queries.Tickets.GetAllPending
{
    public class GetAllPendingQuery : IRequest<List<Ticket>>
    {
    }
}
