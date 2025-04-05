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
    public class MovieRepository : IMovieRepository
    {
        private readonly TicketMasterDbContext _context;

        public MovieRepository(TicketMasterDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie.Id;
        }

        public async Task<List<Movie>> GetAllActiveAsync(string? query)
        {
            return await _context.Movies
                .Include(reg => reg.MovieSessions)
                .ThenInclude(reg => reg.Auditorium)
                .Where(m => m.MovieSessions.Any(ms => ms.Available()))
                .ToListAsync();
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }
    }
}
