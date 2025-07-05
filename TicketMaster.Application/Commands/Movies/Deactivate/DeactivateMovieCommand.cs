using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.Movies.Deactivate
{
    public class DeactivateMovieCommand : IRequest<Result>
    {
        public DeactivateMovieCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
