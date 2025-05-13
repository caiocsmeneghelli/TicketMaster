using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Infrastructure.Persistence.Configurations
{
    public class OrderRequestConfiguration : IEntityTypeConfiguration<OrderRequest>
    {
        public void Configure(EntityTypeBuilder<OrderRequest> builder)
        {
            builder.HasKey(or => or.Guid);

            builder.HasMany(r => r.Tickets)
                .WithOne(t => t.OrderRequest)
                .HasForeignKey(t => t.GuidOrderRequest)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}