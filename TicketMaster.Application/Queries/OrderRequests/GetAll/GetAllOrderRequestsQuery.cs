using MediatR;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queries.OrderRequests
{
    public class GetAllOrderRequestQuery : IRequest<List<OrderRequest>>{}
}