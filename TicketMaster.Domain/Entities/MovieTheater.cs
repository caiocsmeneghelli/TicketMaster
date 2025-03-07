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
        public Movie Movie { get; private set; }
        public int IdTheater { get; private set; }

        public DateTime EndDate { get; private set; }
        public bool NowShowing => Movie.ReleaseDate >= DateTime.UtcNow && Movie.ReleaseDate < EndDate;
    }
}
