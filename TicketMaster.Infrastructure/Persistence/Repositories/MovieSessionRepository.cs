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

        public async Task<int> CreateAsync(MovieSession movieSession)
        {
            await _context.MovieSessions.AddAsync(movieSession);
            await _context.SaveChangesAsync();
            return movieSession.Id;
        }

        public async Task<List<MovieSession>> GetAllAsync()
        {
            return await _context
                .MovieSessions
                .Include(reg => reg.Auditorium)
                .ToListAsync();
        }

        public async Task<List<MovieSession>> GetAllAvailableAsync()
        {
            var results = await _context.MovieSessions
                .Include(reg => reg.Auditorium)
                .ToListAsync();

            return results.Where(reg => reg.Available())
                .ToList();
        }

        public async Task<List<MovieSession>> GetAllAvailableByMovieAsync(int idMovie)
        {
            var results = await _context
                .MovieSessions
                .Where(reg => reg.IdMovie == idMovie)
                .Include(reg => reg.Auditorium)
                .AsNoTracking()
                .ToListAsync();

            return results.Where(reg => reg.Available())
                .ToList();
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
