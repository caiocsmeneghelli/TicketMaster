using TicketMaster.Application.ViewModels.MovieSessions;
using TicketMaster.Domain.Entities;
using AutoMapper;

namespace TicketMaster.Application.Mapper
{
    public class MovieSessionProfile : Profile
    {
        public MovieSessionProfile()
        {
            CreateMap<MovieSession, MovieSessionViewModel>()
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.Theater, opt => opt.MapFrom(src => src.Auditorium.Theater.Name))
                .ForMember(dest => dest.Auditorium, opt => opt.MapFrom(src => src.Auditorium.Name))
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.Auditorium.TotalSeats));   
        }
    }
}
