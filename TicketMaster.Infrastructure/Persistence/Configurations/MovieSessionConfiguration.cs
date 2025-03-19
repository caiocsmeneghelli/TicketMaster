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
    public class MovieSessionConfiguration : IEntityTypeConfiguration<MovieSession>
    {
        public void Configure(EntityTypeBuilder<MovieSession> builder)
        {
            builder.HasKey(ms => ms.Id);

            builder.Ignore(ms => ms.Available);
        }
    }
}
