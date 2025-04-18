using Microsoft.Extensions.DependencyInjection;
using TicketMaster.Application.Commands.Auditoriums.Create;
using TicketMaster.Application.Commands.MovieSessions.Create;
using TicketMaster.Application.Commands.Movies.Create;
using TicketMaster.Application.Commands.Theaters.Create;
using TicketMaster.Application.Mapper;
using TicketMaster.Application.Queries.Movies.GetAll;
using FluentValidation;

namespace TicketMaster.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatr()
                .AddMapper()
                .AddValidators();
            return services;
        }

        private static IServiceCollection AddMediatr(this IServiceCollection service)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllMoviesQuery).Assembly));
            return service;
        }

        private static IServiceCollection AddMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(MovieProfile));
            return service;
        }

        private static IServiceCollection AddValidators(this IServiceCollection service)
        {
            service.AddValidatorsFromAssemblyContaining<CreateMovieCommandValidator>();
            return service;
        }
    }
}
