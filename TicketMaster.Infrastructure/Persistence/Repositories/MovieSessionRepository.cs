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
    public class MovieSessionRepository : IMovieSessionRepository
    {
        private readonly TicketMasterDbContext _context;

        public MovieSessionRepository(TicketMasterDbContext context)
        {
            _context = context;
        }

        public Task<int> CreateAsync(MovieSession movieSession)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieSession>> GetAllAsync()
        {
            return await _context.MovieSessions.ToListAsync();
        }

        public async Task<List<MovieSession>> GetAllAvailableAsync()
        {
            return await _context.MovieSessions
                .Where(reg => reg.Available)
                .ToListAsync();
        }

        public async Task<List<MovieSession>> GetAllByMovieAndDate(int idMovie, DateTime dateTime)
        {
            return await _context
                .MovieSessions
                .Where(reg => reg.IdMovie == idMovie)
                .Where(reg => reg.SessionTime.Date == dateTime.Date)
                .Include(reg => reg.Movie)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
