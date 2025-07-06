using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Repositories
{
    public interface ICacheMovieSessionRepository
    {
        Task<List<MovieSession>> GetMovieByMovieAndDate(int idMovie, DateTime date);
    }
}