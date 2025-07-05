using TicketMaster.Domain.Entities;

namespace TicketMaster.Domain.Repositories
{
    public interface IMovieSessionRepository
    {
        Task<MovieSession?> GetByGuidAsync(Guid id);
        Task<List<MovieSession>> GetAllAsync();
        Task<List<MovieSession>> GetAllAvailableAsync();
        Task<List<MovieSession>> GetAllByMovieAndDate(int idMovie, DateTime dateTime);
        Task<List<MovieSession>> GetAllAvailableByMovieAsync(int idMovie);
        Task<List<MovieSession>> GetAllAvailableByMovieWithTickets(int idMovie);
        Task<Guid> CreateAsync(MovieSession movieSession);
    }
}