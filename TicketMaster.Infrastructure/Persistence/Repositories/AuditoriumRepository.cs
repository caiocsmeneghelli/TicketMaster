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
    public class AuditoriumRepository : IAuditoriumRepository
    {
        private readonly TicketMasterDbContext _ticketMasterDbContext;

        public AuditoriumRepository(TicketMasterDbContext ticketMasterDbContext)
        {
            _ticketMasterDbContext = ticketMasterDbContext;
        }

        public async Task<int> CreateAsync(Auditorium auditorium)
        {
            await _ticketMasterDbContext.Auditoriums.AddAsync(auditorium);
            await _ticketMasterDbContext.SaveChangesAsync();
            return auditorium.Id;
        }

        public async Task<List<Auditorium>> GetAllAsync()
        {
            return await _ticketMasterDbContext
                .Auditoriums
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Auditorium>> GetAllByTheaterAsync(int idTheater)
        {
            return await _ticketMasterDbContext
                .Auditoriums
                .Where(reg => reg.IdTheater == idTheater)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
