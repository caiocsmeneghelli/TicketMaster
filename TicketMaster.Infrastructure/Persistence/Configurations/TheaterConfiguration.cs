using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Infrastructure.Persistence.Configurations
{
    public class TheaterConfiguration : IEntityTypeConfiguration<Theater>
    {
        public void Configure(EntityTypeBuilder<Theater> builder)
        {
            builder.HasKey(reg => reg.Id);
        }
    }
}
