using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        ITicketRepository TicketRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IMovieSessionRepository MovieSessionRepository { get; }
        IOrderRequestRepository OrderRequestRepository { get; }

        Task<int> CompleteAsync();
        Task BeginTransaction();
        Task CommitAsync();
    }
}
