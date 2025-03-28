﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Infrastructure.Persistence.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(reg => reg.Id);

            builder.HasMany(reg => reg.MovieSessions)
                .WithOne(ms => ms.Movie)
                .HasForeignKey(m => m.IdMovie)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
