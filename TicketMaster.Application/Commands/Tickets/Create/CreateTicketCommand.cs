using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Enums;

namespace TicketMaster.Application.Commands.Tickets.Create
{
    public class CreateTicketCommand : IRequest<Guid>
    {
        public int IdMovieSession { get; set; }
        public string? Seat { get; set; }
        public EPaymentType PaymentType { get; set; }
    }
}
