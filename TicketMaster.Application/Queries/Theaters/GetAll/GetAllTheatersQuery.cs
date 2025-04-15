using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.ViewModels.Theaters;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queries.Theaters.GetAll
{
    public class GetAllTheatersQuery : IRequest<List<TheaterViewModel>>
    {
    }
}
