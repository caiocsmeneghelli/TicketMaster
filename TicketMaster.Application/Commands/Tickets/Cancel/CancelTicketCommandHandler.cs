using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.UnitOfWork;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Commands.Tickets.Cancel
{
    public class CancelTicketCommandHandler : IRequestHandler<CancelTicketCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CancelTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CancelTicketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Ticket? ticket = await _unitOfWork.TicketRepository.GetByGuidAsync(request.GuidTicket);
                if (ticket is null) { return Result.Failure("Ticket não encontrado"); }

                Payment? payment = await _unitOfWork.PaymentRepository.GetByGuidAsync(ticket.GuidPayment);
                if(payment is null) { return Result.Failure("Pagamento não encontrado"); }

                // Cancelar pagamento
                // Cancelar ticket

                await _unitOfWork.BeginTransaction();

                payment.Cancel();
                await _unitOfWork.CompleteAsync();

                ticket.Cancel();
                await _unitOfWork.CompleteAsync();

                await _unitOfWork.CommitAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                // Logar erro
                return Result.Failure("Erro ao cancelar o ticket: " + ex.Message);
            }
        }
    }
}
