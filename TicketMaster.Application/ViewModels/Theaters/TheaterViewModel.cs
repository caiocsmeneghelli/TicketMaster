﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Application.ViewModels.Theaters
{
    public class TheaterViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
    }
}
