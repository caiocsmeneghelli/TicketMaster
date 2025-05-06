using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Application.DTOs
{
    public class TicketDto
    {
        public Guid GuidMovieSession { get; private set; }
        public string Seats { get; private set; }
    }
}
