using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Repositories
{
    public interface ICachedMovieSessionRepository
    {
        Task<List<MovieSession>> GetMovieByMovieAndDate(int idMovie, DateTime date);
    }
}