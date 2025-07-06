using TicketMaster.Domain.Entities;

namespace TicketMaster.Infrastructure.Persistence.Caching.Repositories
{
    public interface ICachedMovieRepository
    {
        Task<List<Movie>> GetAllActiveMovies();
        Task RefreshActiveMovies();
    }
}
