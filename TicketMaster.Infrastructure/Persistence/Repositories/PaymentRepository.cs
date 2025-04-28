using Microsoft.EntityFrameworkCore;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Infrastructure.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly TicketMasterDbContext _ticketMasterDbContext;

        public PaymentRepository(TicketMasterDbContext ticketMasterDbContext)
        {
            _ticketMasterDbContext = ticketMasterDbContext;
        }

        public async Task<Guid> CreateAsync(Payment payment)
        {
            await _ticketMasterDbContext.Payments.AddAsync(payment);
            await _ticketMasterDbContext.SaveChangesAsync();
            return payment.Guid;
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _ticketMasterDbContext.Payments
                .ToListAsync();
        }

        public async Task<Payment?> GetByGuidAsync(Guid id)
        {
            return await _ticketMasterDbContext.Payments
                .SingleOrDefaultAsync(p => p.Guid == id);
        }
    }
}