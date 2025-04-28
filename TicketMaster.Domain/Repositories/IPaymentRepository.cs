using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetByGuidAsync(Guid id);
        Task<Guid> CreateAsync(Payment payment);
        Task<List<Payment>> GetAllAsync();
    }
}
