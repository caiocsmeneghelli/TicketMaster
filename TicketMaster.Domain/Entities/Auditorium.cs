﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.Entities
{
    public class Auditorium
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public int IdTheater { get; set; }
    }
}
