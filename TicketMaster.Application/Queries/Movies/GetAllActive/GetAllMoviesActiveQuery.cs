using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.ViewModels.Movies;

namespace TicketMaster.Application.Queries.Movies.GetAllActive
{
    public class GetAllMoviesActiveQuery : IRequest<List<MovieViewModel>>
    {
        public string? Query { get; set; }

        public GetAllMoviesActiveQuery(string? query)
        {
            Query = query;
        }
    }
}
