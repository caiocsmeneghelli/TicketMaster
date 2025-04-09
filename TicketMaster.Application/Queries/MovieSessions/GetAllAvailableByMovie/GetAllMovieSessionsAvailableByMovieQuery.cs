using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.ViewModels.MovieSessions;

namespace TicketMaster.Application.Queries.MovieSessions.GetAllAvailableByMovie
{
    public class GetAllMovieSessionsAvailableByMovieQuery : IRequest<List<MovieSessionViewModel>>
    {
        public int IdMovie { get; set; }
    }
}
