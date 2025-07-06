using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketMaster.Application.UnitOfWork;
using TicketMaster.Domain.Repositories;
using TicketMaster.Infrastructure.Persistence;
using TicketMaster.Infrastructure.Persistence.Repositories;

namespace TicketMaster.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories()
                .AddUnitOfWrok()
                .AddCache(configuration)
                .AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TicketMasterCs");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            service.AddDbContext<TicketMasterDbContext>(cfg => cfg.UseMySql(connectionString, serverVersion));

            return service;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IMovieRepository, MovieRepository>();
            service.AddScoped<IMovieSessionRepository, MovieSessionRepository>();
            service.AddScoped<IAuditoriumRepository, AuditoriumRepository>();
            service.AddScoped<ITheaterRepository, TheaterRepository>();
            service.AddScoped<ITicketRepository, TicketRepository>();
            service.AddScoped<IPaymentRepository, PaymentRepository>();
            service.AddScoped<IOrderRequestRepository, OrderRequestRepository>();
            service.AddScoped<ICachedMovieRepository, CachedMovieRepositoy>();
            service.AddScoped<ICachedMovieSessionRepository, CachedMovieSessionRepository>();

            return service;
        }

        private static IServiceCollection AddUnitOfWrok(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            return service;
        }

        private static IServiceCollection AddCache(this IServiceCollection service, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("Redis");
            if (!string.IsNullOrEmpty(connection))
            {
                service.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = connection;
                    options.InstanceName = "TicketMasterCache";
                });
            }
            return service;
        }
    }
}
