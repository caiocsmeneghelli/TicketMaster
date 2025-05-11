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
                .WithOne()
                .HasForeignKey<Ticket>(t => t.GuidMovieSession)
                .HasPrincipalKey<MovieSession>(ms => ms.Guid);
        }
    }
}
