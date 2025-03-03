﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.Entities
{
    public class Theater
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Address { get; private set; }
        public string? Contact { get; private set; }
    }
}
