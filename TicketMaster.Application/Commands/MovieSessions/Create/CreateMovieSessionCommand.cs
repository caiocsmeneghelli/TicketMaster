using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Application.Commands.MovieSessions.Create
{
    public class CreateMovieSessionCommand : IRequest<int>
    {
        public int IdMovie { get; set; }
        public int IdAuditorium { get; set; }
        public DateTime SessionTime { get; set; }
    }
}
