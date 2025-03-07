using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.Queies.Movies.GetAll;

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
