using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Enums;

namespace TicketMaster.Domain.Entities
{
    public class MovieSession
    {
        public MovieSession(int idMovie, int idAuditorium, DateTime sessionTime,
            EImageAttribute imageAttribute, EAudioAttribute audioAttribute, decimal ticketValue)
        {
            Guid = new Guid();
            IdMovie = idMovie;
            IdAuditorium = idAuditorium;
            SessionTime = sessionTime;
            ImageAttribute = imageAttribute;
            AudioAttribute = audioAttribute;
            TicketValue = ticketValue;
        }

        public Guid Guid { get; private set; }
        public int IdMovie { get; private set; }
        public Movie Movie { get; private set; }
        public int IdAuditorium { get; private set; }
        public Auditorium Auditorium { get; private set; }
        public DateTime SessionTime { get; private set; }
        public int ReservedSeats { get; private set; }
        public EImageAttribute ImageAttribute { get; private set; }
        public EAudioAttribute AudioAttribute { get; private set; }
        public decimal TicketValue { get; private set; }

        public List<Ticket> Tickets { get; private set; }

        // add validation
        public void AddReservedSeats(int reservedSeats)
        {
            ReservedSeats += reservedSeats;
        }

        public bool Available()
        {
            return ReservedSeats < Auditorium.TotalSeats;
        }
    }
}
