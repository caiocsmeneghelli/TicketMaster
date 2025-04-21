using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.UnitOfWork;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Commands.Tickets.Create
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            // validar command
            // validar movie session
            var payment = new Payment(request.PaymentType);
            var guidPayment = await _unitOfWork.PaymentRepository.CreateAsync(payment);

            // Add result
            var movieSession = await _unitOfWork.MovieSessionRepository.GetByGuidAsync(request.GuidMovieSession);
            if (movieSession is null) { throw new Exception(); }

            var ticket = new Ticket(movieSession.Guid, request.Seat, guidPayment);

            // enviar para paymentservice
            // retornar guid
            return new Guid();
        }
    }
}
