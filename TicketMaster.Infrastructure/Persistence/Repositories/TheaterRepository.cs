using Microsoft.EntityFrameworkCore;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Infrastructure.Persistence.Repositories
{
    public class TheaterRepository : ITheaterRepository
    {
        private readonly TicketMasterDbContext _ticketMasterDbContext;

        public TheaterRepository(TicketMasterDbContext ticketMasterDbContext)
        {
            _ticketMasterDbContext = ticketMasterDbContext;
        }

        public async Task<int> CreateAsync(Theater theater)
        {
            await _ticketMasterDbContext.Theaters.AddAsync(theater);
            await _ticketMasterDbContext.SaveChangesAsync();
            return theater.Id;
        }

        public async Task<List<Theater>> GetAllAsync()
        {
            return await _ticketMasterDbContext.Theaters.ToListAsync();
        }
    }
}
