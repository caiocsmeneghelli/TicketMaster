using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Repositories
{
    public interface ICachedMovieRepository
    {
        Task<List<Movie>> GetAllActiveMovies();
        Task RefreshActiveMovies();
    }
}