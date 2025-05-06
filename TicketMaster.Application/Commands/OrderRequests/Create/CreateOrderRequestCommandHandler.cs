using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.UnitOfWork;
using TicketMaster.Domain.Common;

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
            // Busca movieSession
            // Cria ingressos
            // Cria pagamento
            // Cria pedido
            return Result<Guid>.Success(Guid.NewGuid());
        }
    }
}
