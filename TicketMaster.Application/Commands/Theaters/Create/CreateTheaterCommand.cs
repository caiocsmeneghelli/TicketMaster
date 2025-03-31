using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Application.Commands.Theaters.Create
{
    public class CreateTheaterCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }
}
