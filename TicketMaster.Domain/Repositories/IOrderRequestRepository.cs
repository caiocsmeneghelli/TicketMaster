using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Domain.Repositories
{
    public interface IOrderRequestRepository
    {
        Task<List<OrderRequest>> GetAllAsync();
        // Add pagination
        Task<List<OrderRequest>> ListAsync(PageRequest pageRequest);
        Task<Guid> CreateAsync(OrderRequest orderRequest);
    }
}