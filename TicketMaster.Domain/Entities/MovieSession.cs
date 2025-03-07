using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.Entities
{
    public class MovieSession
    {
        public MovieSession(int idMovieTheater, int idAuditorium, DateTime sessionTime)
        {
            IdMovieTheater = idMovieTheater;
            IdAuditorium = idAuditorium;
            SessionTime = sessionTime;
        }

        public int Id { get; private set; }
        public int IdMovieTheater { get; private set; }
        public int IdAuditorium { get; private set; }
        public DateTime SessionTime { get; private set; }
    }
}
