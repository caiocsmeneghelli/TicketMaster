using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
