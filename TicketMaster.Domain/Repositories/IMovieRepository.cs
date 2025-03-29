using TicketMaster.Domain.Entities;

namespace TicketMaster.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<List<Movie>> GetAllActiveAsync(string? query);
        Task<int> CreateAsync(Movie movie);
    }
}
