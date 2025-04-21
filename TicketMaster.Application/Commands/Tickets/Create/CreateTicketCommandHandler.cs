using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Application.Commands.Tickets.Create
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
    {
        // Add IUnitOfWork
        public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            // validar command
            // validar movie session
            // criar payment
            // criar ticket

            // enviar para paymentservice
            // retornar guid
            return new Guid();
        }
    }
}
