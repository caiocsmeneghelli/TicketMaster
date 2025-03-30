using MediatR;
using TicketMaster.Application.ViewModels.Movies;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queies.Movies.GetAll
{
    public class GetAllMoviesQuery : IRequest<List<Movie>>
    {
    }
}
