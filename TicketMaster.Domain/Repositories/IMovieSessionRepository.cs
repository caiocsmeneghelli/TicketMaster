using TicketMaster.Domain.Entities;

namespace TicketMaster.Domain.Repositories
{
    public interface IMovieSessionRepository
    {
        Task<List<MovieSession>> GetAllAsync();
    }
}