using AutoMapper;
using TicketMaster.Application.Commands.Theaters.Create;
using TicketMaster.Application.ViewModels.Theaters;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Mapper
{
    public class TheaterProfile : Profile
    {
        public TheaterProfile()
        {
            CreateMap<Theater, TheaterViewModel>();
        }
    }
}
