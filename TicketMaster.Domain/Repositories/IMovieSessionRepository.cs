using TicketMaster.Domain.Entities;

namespace TicketMaster.Domain.Repositories
{
    public interface IMovieSessionRepository
    {
        Task<List<MovieSession>> GetAllAsync();
        Task<List<MovieSession>> GetAllAvailableAsync();
        Task<List<MovieSession>> GetAllByMovieAndDate(int idMovie, DateTime dateTime);
    }
}