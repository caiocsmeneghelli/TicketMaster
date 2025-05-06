using MediatR;
using TicketMaster.Application.DTOs;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.OrderRequests.Create
{
    public class CreateOrderRequestCommand : IRequest<Result<Guid>>
    {
        public List<TicketDto> Tickets { get; private set; }
        // Change?
        public  PaymentDto Payment { get; private set; }
    }
}
