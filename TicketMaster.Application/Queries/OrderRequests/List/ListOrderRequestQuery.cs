using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.Helpers.Pagination;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queries.OrderRequests.List
{
    public class ListOrderRequestQuery : IRequest<Result<PagedResult<OrderRequest>>>
    {
        public PageRequest PageRequest { get; set; }
    }
}
