﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Enums;

namespace TicketMaster.Domain.Entities
{
    public class Auditorium
    {
        public Auditorium(string? name, int idTheater, int totalSeats)
        {
            Name = name;
            IdTheater = idTheater;
            TotalSeats = totalSeats;
        }

        public int Id { get; private set; }
        public string? Name { get; private set; }
        public int TotalSeats { get; private set; }
        public int IdTheater { get; private set; }
        public Theater Theater { get; private set; }
        public EAudioAttribute AudioAttribute { get; private set; }
    }
}
