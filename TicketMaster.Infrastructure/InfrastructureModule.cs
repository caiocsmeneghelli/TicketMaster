using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Infrastructure.Persistence;

namespace TicketMaster.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TicketMasterCs");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            service.AddDbContext<TicketMasterDbContext>(cfg => cfg.UseMySql(connectionString, serverVersion));
            
            return service;
        }
            
    }
}
