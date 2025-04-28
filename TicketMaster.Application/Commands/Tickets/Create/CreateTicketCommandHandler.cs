using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.UnitOfWork;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Commands.Tickets.Create
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // validar command
                // validar movie session
                var payment = new Payment(request.PaymentType);
                var guidPayment = await _unitOfWork.PaymentRepository.CreateAsync(payment);

                // Add result
                var movieSession = await _unitOfWork.MovieSessionRepository.GetByGuidAsync(request.GuidMovieSession);
                if (movieSession is null) { throw new Exception(); }

                var ticket = new Ticket(movieSession.Guid, request.Seat, guidPayment);
                var guidTicket = await _unitOfWork.TicketRepository.CreateAsync(ticket);

                // enviar para paymentservice
                // retornar guid
                return Result<Guid>.Success(guidTicket);
            }
            catch (Exception ex)
            {
                // Logar erro
                return Result.Failure("Erro ao criar o ticket: " + ex.Message);
            }
        }
    }
}
}
