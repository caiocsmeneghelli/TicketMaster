using Microsoft.EntityFrameworkCore;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Infrastructure.Persistence.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketMasterDbContext _ticketMasterDbContext;

        public TicketRepository(TicketMasterDbContext dbContext)
        {
            _ticketMasterDbContext = dbContext;
        }

        public async Task<Guid> CreateAsync(Ticket ticket)
        {
            await _ticketMasterDbContext.Tickets.AddAsync(ticket);
            await _ticketMasterDbContext.SaveChangesAsync();
            return ticket.Guid;
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _ticketMasterDbContext.Tickets.ToListAsync();
        }

        public async Task<List<Ticket>> GetAllPendingAsync()
        {
            return await _ticketMasterDbContext.Tickets
                .Where(reg => reg.TicketStatus == Domain.Enums.ETicketStatus.Pending)
                .ToListAsync();
        }

        public async Task<Ticket?> GetByGuidAsync(Guid guid)
        {
            return await _ticketMasterDbContext.Tickets
                .SingleOrDefaultAsync(t => t.Guid == guid);
        }
    }
}