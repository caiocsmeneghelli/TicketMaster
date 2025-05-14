using MediatR;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.Tickets.GetByGuid
{
    public class GetTicketByGuidQueryHandler : IRequestHandler<GetTicketByGuidQuery, Result>
    {
        private readonly ITicketRepository _repository;

        public GetTicketByGuidQueryHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(GetTicketByGuidQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetByGuidAsync(request.Guid);
            if (ticket == null) { return Result.Failure("Ingresso não encontrado."); }

            // Add mapper
            return Result<Ticket>.Success(ticket);
        }
    }
}
