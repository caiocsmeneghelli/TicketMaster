using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queries.Tickets.GetByGuid
{
    public class GetTicketByGuidQuery : IRequest<Ticket?>
    {
        public Guid Guid { get; private set; }

        public GetTicketByGuidQuery(Guid guid)
        {
            Guid = guid;
        }
    }
}
