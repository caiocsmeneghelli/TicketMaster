using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Domain.Repositories
{
    public interface ITheaterRepository
    {
        Task<List<Theater>> GetAllAsync();
        Task<int> CreateAsync(Theater theater);
    }
}
