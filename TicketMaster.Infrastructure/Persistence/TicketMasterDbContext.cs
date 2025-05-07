using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Infrastructure.Persistence
{
    public class TicketMasterDbContext : DbContext
    {
        public TicketMasterDbContext(DbContextOptions<TicketMasterDbContext> options) : base(options)
        { }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieSession> MovieSessions { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderRequest> OrderRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
