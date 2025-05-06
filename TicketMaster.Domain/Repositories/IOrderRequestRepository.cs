using TicketMaster.Domain.Entities;

namespace TicketMaster.Domain.Repositories
{
    public interface IOrderRequestRepository
    {
        Task<List<OrderRequest>> GetAllAsync();
        // Add pagination
        Task<List<OrderRequest>> ListAsync();
        Task<Guid> CreateAsync(OrderRequest orderRequest);
        Task Cancel();
    }
}