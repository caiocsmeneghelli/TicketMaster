﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Application.ViewModels.Auditorium
{
    public class AuditoriumViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int IdTheater { get; set; }
        public string? TheaterName { get; set; }
    }
}
