﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.Entities
{
    public class MovieSession
    {
        public MovieSession(int idMovie, int idAuditorium, DateTime sessionTime)
        {
            IdMovie = idMovie;
            IdAuditorium = idAuditorium;
            SessionTime = sessionTime;
        }

        public int Id { get; private set; }
        public int IdMovie { get; private set; }
        public Movie Movie { get; private set; }
        public int IdAuditorium { get; private set; }
        public Auditorium Auditorium { get; private set; }
        public DateTime SessionTime { get; private set; }
        public int ReservedSeats { get; private set; }

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
