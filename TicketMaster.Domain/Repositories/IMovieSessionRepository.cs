using TicketMaster.Domain.Entities;

namespace TicketMaster.Domain.Repositories
{
    public interface IMovieSessionRepository
    {
        Task<List<MovieSession>> GetAllAsync();
        Task<List<MovieSession>> GetAllAvailableAsync();
        Task<List<MovieSession>> GetAllByMovieAndDate(int idMovie, DateTime dateTime);
        Task<List<MovieSession>> GetAllAvailableByMovieAsync(int idMovie);
        Task<int> CreateAsync(MovieSession movieSession);
    }
}