using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Infrastructure.Persistence.Repositories
{
    public class OrderRequestRepository : IOrderRequestRepository
    {
        private readonly TicketMasterDbContext _ticketMasterDbContext;

        public OrderRequestRepository(TicketMasterDbContext ticketMasterDbContext)
        {
            _ticketMasterDbContext = ticketMasterDbContext;
        }

        public async Task<Guid> CreateAsync(OrderRequest orderRequest)
        {
            await _ticketMasterDbContext.OrderRequests.AddAsync(orderRequest);
            await _ticketMasterDbContext.SaveChangesAsync();
            return orderRequest.Guid;
        }

        public Task<List<OrderRequest>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderRequest>> ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
