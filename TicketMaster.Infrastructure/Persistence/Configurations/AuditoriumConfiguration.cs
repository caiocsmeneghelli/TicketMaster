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
    public class AuditoriumConfiguration : IEntityTypeConfiguration<Auditorium>
    {
        public void Configure(EntityTypeBuilder<Auditorium> builder)
        {
            builder.HasKey(reg => reg.Id);
            
            builder.HasOne(reg => reg.Theater)
                .WithMany(reg => reg.Auditoriums)
                .HasForeignKey(reg => reg.IdTheater)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
