using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Infrastructure.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Guid);

            builder.HasOne(t => t.MovieSession)
                .WithMany(ms => ms.Tickets)
                .HasForeignKey(t => t.GuidMovieSession)
                .HasPrincipalKey(ms => ms.Guid)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
