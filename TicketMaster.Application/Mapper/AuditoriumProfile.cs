using AutoMapper;
using TicketMaster.Application.ViewModels.Auditorium;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Mapper
{
    public class AuditoriumProfile : Profile
    {
        public AuditoriumProfile()
        {
            CreateMap<Auditorium, AuditoriumViewModel>()
                .ForMember(dest => dest.TheaterName, opt => opt.MapFrom(src => src.Theater.Name));
        }
    }
}
