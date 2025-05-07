using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TicketMaster.Application.UnitOfWork;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TicketMasterDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ITicketRepository ticketRepository, IPaymentRepository paymentRepository,
            IMovieSessionRepository movieSessionRepository, IOrderRequestRepository orderRequestRepository, 
            TicketMasterDbContext dbContext)
        {
            TicketRepository = ticketRepository;
            PaymentRepository = paymentRepository;
            MovieSessionRepository = movieSessionRepository;
            OrderRequestRepository = orderRequestRepository;
            _dbContext = dbContext;
        }

        public ITicketRepository TicketRepository { get; }
        public IPaymentRepository PaymentRepository {get;}
        public IMovieSessionRepository MovieSessionRepository {get;}
        public IOrderRequestRepository OrderRequestRepository {get;}

        public async Task BeginTransaction()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw ex;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
