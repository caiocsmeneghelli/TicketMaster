using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Application.Commands.Auditoriums.Create
{
    public class CreateAuditoriumCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int TotalSeats { get; set; }
        public int IdTheater { get; set; }
    }
}
