using TicketMaster.Application.DTOs;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Repositories
{
    public interface ICachedMovieSessionRepository
    {
        Task<MovieWithTheatersDto> GetMovieByMovieAndDate(int idMovie, DateTime date);
    }
}