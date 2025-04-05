using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.Entities
{
    public class Auditorium
    {
        public Auditorium(string? name, int idTheater, int totalSeats)
        {
            Name = name;
            IdTheater = idTheater;
            TotalSeats = totalSeats;
            MovieSessions = new List<MovieSession>();
        }

        public int Id { get; private set; }
        public string? Name { get; private set; }
        public int TotalSeats { get; private set; }
        public List<MovieSession> MovieSessions { get; private set; }
        public int IdTheater { get; private set; }
        public Theater Theater { get; private set; }
    }
}
