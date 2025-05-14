using AutoMapper;
using TicketMaster.Application.ViewModels.Movies;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Mapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieViewModel>();
        }
    }
}
