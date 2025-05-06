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
            MovieSession? movieSesion = await _unitOfWork.MovieSessionRepository.GetByGuidAsync(request.GuidMovieSession);
            if(movieSesion is null){
                return Result.Failure("Sessão de filme não encontrada.");
            }

            await _unitOfWork.BeginTransaction();

            Payment payment = new Payment(request.Payment.PaymentType);
            Guid guidPayment = await _unitOfWork.PaymentRepository.CreateAsync(payment);

            decimal totalValue = movieSesion.TicketValue * request.Tickets.Count();
            OrderRequest orderRequest = new OrderRequest(guidPayment, totalValue);
            Guid guidOrderRequest = await _unitOfWork.OrderRequestRepository.CreateAsync(orderRequest);

            List<Ticket> tickets = new List<Ticket>();
            foreach(var ticketDto in request.Tickets){
                var ticket = new Ticket(movieSesion.Guid, ticketDto.Seat, guidOrderRequest);
                tickets.Add(ticket);

                await _unitOfWork.TicketRepository.CreateAsync(ticket);
            }
            
            await _unitOfWork.CommitAsync();

            return Result<Guid>.Success(guidOrderRequest);
        }
    }
}
