using MediatR;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.OrderRequests
{
    public class GetAllOrderRequestQueryHandler : IRequestHandler<GetAllOrderRequestQuery, List<OrderRequest>>
    {
        private readonly IOrderRequestRepository _repository;

        public GetAllOrderRequestQueryHandler(IOrderRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<OrderRequest>> Handle(GetAllOrderRequestQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAllAsync();
            return response;
        }
    }
}