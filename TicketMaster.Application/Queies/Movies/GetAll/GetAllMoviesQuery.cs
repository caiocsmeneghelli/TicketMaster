using MediatR;
using TicketMaster.Application.ViewModels.Movies;

namespace TicketMaster.Application.Queies.Movies.GetAll
{
    public class GetAllMoviesQuery : IRequest<List<MovieViewModel>>
    {
    }
}
