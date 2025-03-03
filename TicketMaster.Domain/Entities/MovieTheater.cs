using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.Entities
{
    public class MovieTheater
    {
        public int Id { get; private set; }
        public int IdMovie { get; private set; }
        public int IdTheater { get; private set; }

        // fix: name
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
    }
}
