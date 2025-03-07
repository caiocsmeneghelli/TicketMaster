using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.Entities
{
    public class MovieSession
    {
        public MovieSession(int idMovieTheater, int idAuditorium, DateTime sessionTime, int totalSeats)
        {
            IdMovieTheater = idMovieTheater;
            IdAuditorium = idAuditorium;
            SessionTime = sessionTime;
            TotalSeats = totalSeats;
        }

        public int Id { get; private set; }
        public int IdMovieTheater { get; private set; }
        public int IdAuditorium { get; private set; }
        public DateTime SessionTime { get; private set; }
        public int TotalSeats { get; private set; }
        public int ReservedSeats { get; private set; }
        public bool Available => TotalSeats > ReservedSeats;

        // add validation
        public void AddReservedSeats(int reservedSeats)
        {
            ReservedSeats += reservedSeats;
        }
    }
}
