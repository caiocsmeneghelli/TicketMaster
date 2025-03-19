using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Infrastructure.Persistence.Configurations
{
    public class TheaterConfiguration : IEntityTypeConfiguration<Theater>
    {
        public void Configure(EntityTypeBuilder<Theater> builder)
        {
            builder.HasKey(reg => reg.Id);

            builder.HasMany(reg => reg.Auditoriums)
                .WithOne(a => a.Theater)
                .HasForeignKey(a => a.IdTheater)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
