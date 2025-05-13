using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Guid);

            builder.HasOne(p => p.OrderRequest)
                .WithOne(o => o.Payment)
                .HasForeignKey<OrderRequest>(p => p.GuidPayment)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
