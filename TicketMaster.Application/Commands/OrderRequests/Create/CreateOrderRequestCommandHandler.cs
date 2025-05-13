using MediatR;
using TicketMaster.Application.UnitOfWork;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Commands.OrderRequests.Create
{
    public class CreateOrderRequestCommandHandler : IRequestHandler<CreateOrderRequestCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderRequestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateOrderRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                MovieSession? movieSesion = await _unitOfWork.MovieSessionRepository.GetByGuidAsync(request.GuidMovieSession);
                if (movieSesion is null)
                {
                    await _unitOfWork.Rollback();
                    return Result.Failure("Sessão de filme não encontrada.");
                }

                bool isAvailable = movieSesion.IsAvailable(request.Tickets.Count);
                if(!isAvailable)
                {
                    await _unitOfWork.Rollback();
                    return Result.Failure("Ingressos não disponíveis.");
                }

                Payment payment = new Payment(request.Payment.PaymentType);
                Guid guidPayment = await _unitOfWork.PaymentRepository.CreateAsync(payment);

                decimal totalValue = movieSesion.TicketValue * request.Tickets.Count;
                OrderRequest orderRequest = new OrderRequest(totalValue, guidPayment);
                Guid guidOrderRequest = await _unitOfWork.OrderRequestRepository.CreateAsync(orderRequest);

                var tickets = request.Tickets.Select(t => new Ticket(movieSesion.Guid, t.Seat, guidOrderRequest)).ToList();

                foreach (var ticket in tickets)
                {
                    await _unitOfWork.TicketRepository.CreateAsync(ticket);
                }

                await _unitOfWork.CommitAsync();

                return Result<Guid>.Success(guidOrderRequest);
            }catch(Exception ex)
            {
                await _unitOfWork.Rollback();
                return Result.Failure("Erro ao criar pedido de compra: " + ex.Message);
            }
        }
    }
}
