using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.Entities
{
    public class MovieSession
    {
        public int Id { get; private set; }
        public int IdMovieTheater { get; private set; }
        public DateTime SessionTime { get; private set; }
    }
}
