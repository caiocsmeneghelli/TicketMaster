using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.Entities
{
    public class Auditorium
    {
        public Auditorium(int id, string? name, int idTheater, Theater theater)
        {
            Id = id;
            Name = name;
            MovieSessions = new List<MovieSession>();
            IdTheater = idTheater;
            Theater = theater;
        }

        public int Id { get; private set; }
        public string? Name { get; private set; }
        public List<MovieSession> MovieSessions { get; private set; }
        public int IdTheater { get; private set; }
        public Theater Theater { get; private set; }
    }
}
