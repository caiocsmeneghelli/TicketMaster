using TicketMaster.Domain.Entities;

namespace TicketMaster.Infrastructure.Persistence.Caching.Repositories
{
    public interface ICachedMovieSessionRepository
    {
        Task<List<MovieSession>> GetMovieByMovieAndDate(int idMovie, DateTime date);
    }
}
