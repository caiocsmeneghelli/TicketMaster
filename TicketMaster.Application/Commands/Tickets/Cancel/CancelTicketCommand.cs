using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.Tickets.Cancel
{
    public class CancelTicketCommand : IRequest<Result>
    {
        public Guid GuidTicket { get; set; }

        public CancelTicketCommand(Guid guidTicket)
        {
            GuidTicket = guidTicket;
        }
    }
}
