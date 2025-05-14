using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Application.ViewModels.MovieSessions
{
    public class MovieSessionViewModel
    {
        public Guid Guid { get; set; }
        public int IdMovie { get; set; }
        public string? Movie { get; set; }

        public int IdTheater { get; set; }
        public string? Theater { get; private set; }
        public int IdAuditorium { get; set; }
        public string Auditorium { get; set; }
        public DateTime SessionTime { get; set; }
        public int TotalSeats { get; set; }
        public int ReservedSeats { get; set; }
        public bool Available { get; set; }
    }
}
