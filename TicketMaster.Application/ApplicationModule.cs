using Microsoft.Extensions.DependencyInjection;
using TicketMaster.Application.Queries.Movies.GetAll;

namespace TicketMaster.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatr();
            return services;
        }

        private static IServiceCollection AddMediatr(this IServiceCollection service)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllMoviesQuery).Assembly));
            return service;
        }
    }
}
