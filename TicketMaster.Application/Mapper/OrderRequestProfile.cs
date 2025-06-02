using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.ViewModels.OrderRequests;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Mapper
{
    public class OrderRequestProfile : Profile
    {
        public OrderRequestProfile()
        {
            CreateMap<OrderRequest, OrderRequestViewModel>()
            .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
            .ForMember(dest => dest.GuidPayment, opt => opt.MapFrom(src => src.GuidPayment))
            .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.Payment.PaymentStatus))
            .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.Payment.PaymentType))
            .ForMember(dest => dest.TotalValue, opt => opt.MapFrom(src => src.TotalValue));
        }
    }
}
