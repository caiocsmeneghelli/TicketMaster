using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.Queries.Auditoriums.GetAllByTheater
{
    public class GetAllAuditoriumsByTheaterQuery : IRequest<List<Auditorium>>
    {
        public int IdTheater { get; set; }
    }
}
