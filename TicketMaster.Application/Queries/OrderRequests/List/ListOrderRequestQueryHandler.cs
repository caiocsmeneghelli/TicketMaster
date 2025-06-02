using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.Helpers.Pagination;
using TicketMaster.Application.UnitOfWork;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.OrderRequests.List
{
    public class ListOrderRequestQueryHandler : IRequestHandler<ListOrderRequestQuery, Result<PagedResult<OrderRequest>>>
    {
        private readonly IOrderRequestRepository _orderRequestRepository;

        public ListOrderRequestQueryHandler(IOrderRequestRepository orderRequestRepository)
        {
            _orderRequestRepository = orderRequestRepository;
        }

        public async Task<Result<PagedResult<OrderRequest>>> Handle(ListOrderRequestQuery request, CancellationToken cancellationToken)
        {
            var pageRequest = request.PageRequest ?? new PageRequest
            {
                PageSize = 10, // Default page size
                PageNumber = 1 // Default page number
            };

            var response = await _orderRequestRepository.ListAsync(pageRequest);
            var result = new PagedResult<OrderRequest>(response, pageRequest.PageNumber, pageRequest.PageSize);

            return Result<PagedResult<OrderRequest>>.Success(result);
        }
    }
}
