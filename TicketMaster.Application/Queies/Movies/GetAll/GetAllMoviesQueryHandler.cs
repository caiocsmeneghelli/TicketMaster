using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.ViewModels.Movies;

namespace TicketMaster.Application.Queies.Movies.GetAll
{
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieViewModel>>
    {
        public async Task<List<MovieViewModel>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            return new List<MovieViewModel>();
        }
    }
}
