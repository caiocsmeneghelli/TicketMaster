using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.Helpers.Pagination;
using TicketMaster.Application.UnitOfWork;
using TicketMaster.Application.ViewModels.OrderRequests;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.OrderRequests.List
{
    public class ListOrderRequestQueryHandler : IRequestHandler<ListOrderRequestQuery, PagedResult<OrderRequestViewModel>>
    {
        private readonly IOrderRequestRepository _orderRequestRepository;
        private readonly IMapper _mapper;

        public ListOrderRequestQueryHandler(IOrderRequestRepository orderRequestRepository, IMapper mapper)
        {
            _orderRequestRepository = orderRequestRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<OrderRequestViewModel>> Handle(ListOrderRequestQuery request, CancellationToken cancellationToken)
        {
            var pageRequest = request.PageRequest;

            var response = await _orderRequestRepository.ListAsync(pageRequest);
            var vwModel = _mapper.Map<List<OrderRequestViewModel>>(response);

            var result = new PagedResult<OrderRequestViewModel>(vwModel, pageRequest.PageNumber, pageRequest.PageSize);
            return result;
        }
    }
}
