using MediatR;
using TicketMaster.Application.UnitOfWork;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Commands.OrderRequests.Create
{
    public class CreateOrderRequestCommandHandler : IRequestHandler<CreateOrderRequestCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderRequestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateOrderRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                MovieSession? movieSesion = await _unitOfWork.MovieSessionRepository.GetByGuidAsync(request.GuidMovieSession);
                if (movieSesion is null)
                {
                    await _unitOfWork.Rollback();
                    return Result<Guid>.Failure("Sessão de filme não encontrada.");
                }

                bool isAvailable = movieSesion.IsAvailable(request.Tickets.Count);
                if(!isAvailable)
                {
                    await _unitOfWork.Rollback();
                    return Result<Guid>.Failure("Ingressos não disponíveis.");
                }

                decimal totalValue = movieSesion.TicketValue * request.Tickets.Count;
                OrderRequest orderRequest = new OrderRequest(totalValue);
                Guid guidOrderRequest = await _unitOfWork.OrderRequestRepository.CreateAsync(orderRequest);

                Payment payment = new Payment(request.Payment.PaymentType, guidOrderRequest);
                Guid guidPayment = await _unitOfWork.PaymentRepository.CreateAsync(payment);

                orderRequest.SetPayment(payment);
                await _unitOfWork.CompleteAsync();

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
                return Result<Guid>.Failure("Erro ao criar pedido de compra: " + ex.Message);
            }
        }
    }
}
