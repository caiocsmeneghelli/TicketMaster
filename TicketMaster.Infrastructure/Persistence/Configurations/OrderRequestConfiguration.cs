using Microsoft.EntityFrameworkCore;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Infrastructure.Persistence.Configurations
{
    public class OrderRequestConfiguration : IEntityTypeConfiguration<OrderRequest>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderRequest> builder)
        {
            builder.HasKey(or => or.Guid);

            builder.HasOne(r => r.Payment)
                .WithOne(p => p.OrderRequest)
                .HasForeignKey<Payment>(p => p.GuidOrderRequest)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Tickets)
                .WithOne(t => t.OrderRequest)
                .HasForeignKey(t => t.GuidOrderRequest)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}