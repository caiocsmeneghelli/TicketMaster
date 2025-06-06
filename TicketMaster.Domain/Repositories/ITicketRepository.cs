﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Domain.Repositories
{
    public interface ITicketRepository
    {
        Task<Guid> CreateAsync(Ticket ticket);
        Task<Ticket?> GetByGuidAsync(Guid guid);
        Task<List<Ticket>> GetAllAsync();
        Task<List<Ticket>> GetAllPendingAsync();

    }
}
