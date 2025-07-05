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

        public async Task<Guid> CreateAsync(MovieSession movieSession)
        {
            await _context.MovieSessions.AddAsync(movieSession);
            await _context.SaveChangesAsync();
            return movieSession.Guid;
        }

        public async Task<List<MovieSession>> GetAllAsync()
        {
            return await _context
                .MovieSessions
                .Include(reg => reg.Auditorium)
                .ThenInclude(reg => reg.Theater)
                .Include(reg => reg.Movie)
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
            IQueryable<MovieSession> query = _context
                .MovieSessions
                .Where(reg => reg.IdMovie == idMovie)
                .Include(reg => reg.Movie)
                .Include(reg => reg.Auditorium)
                .ThenInclude(reg => reg.Theater)
                .AsNoTracking();
            
            var results =  await query.ToListAsync();
             
            return results.Where(reg => reg.Available())
                .ToList();
        }

        public async Task<List<MovieSession>> GetAllAvailableByMovieWithTickets(int idMovie)
        {
            return await _context
                .MovieSessions.Where(reg => reg.IdMovie == idMovie)
                .Include(reg => reg.Tickets)
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

        public async Task<MovieSession?> GetByGuidAsync(Guid id)
        {
            return await _context
                .MovieSessions
                .Include(reg => reg.Auditorium)
                .AsNoTracking()
                .SingleOrDefaultAsync(reg => reg.Guid == id);
        }
    }
}
