using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<List<OrderRequest>> ListAsync(PageRequest pageRequest)
        {
            var query = _ticketMasterDbContext.OrderRequests
                .Include(or => or.Payment)
                .Include(or => or.Tickets);
                
            return await query.Skip((pageRequest.PageNumber - 1) * pageRequest.PageSize).Take(pageRequest.PageSize).ToListAsync();
        }
    }
}
