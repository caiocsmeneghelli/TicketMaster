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
                var payment = new Payment(request.PaymentType, Guid.NewGuid());
                var guidPayment = await _unitOfWork.PaymentRepository.CreateAsync(payment);

                // Add result
                var movieSession = await _unitOfWork.MovieSessionRepository.GetByGuidAsync(request.GuidMovieSession);
                if (movieSession is null) { return Result.Failure("Sessão não encontrada."); }

                if (movieSession.Available())
                {
                    return Result.Failure("Não existe mais assentos vagos.");
                }

                movieSession.AddReservedSeats(1);

                // Mock value
                var ticket = new Ticket(movieSession.Guid, request.Seat, new Guid());
                var guidTicket = await _unitOfWork.TicketRepository.CreateAsync(ticket);

                // enviar para paymentservice
                return Result<Guid>.Success(guidTicket);
            }
            catch (Exception ex)
            {
                return Result.Failure("Erro ao criar o ticket: " + ex.Message);
            }
        }
    }
}
