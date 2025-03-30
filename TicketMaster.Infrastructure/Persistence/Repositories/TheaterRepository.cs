using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Task<int> CreateAsync(Theater theater)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Theater>> GetAllAsync()
        {
            return await _ticketMasterDbContext.Theaters.ToListAsync();
        }
    }
}
