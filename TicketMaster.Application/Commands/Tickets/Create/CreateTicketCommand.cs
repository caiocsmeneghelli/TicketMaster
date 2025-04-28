using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Enums;

namespace TicketMaster.Application.Commands.Tickets.Create
{
    public class CreateTicketCommand : IRequest<Result>
    {
        public Guid GuidMovieSession { get; set; }
        public string? Seat { get; set; }
        public EPaymentType PaymentType { get; set; }
    }
}
