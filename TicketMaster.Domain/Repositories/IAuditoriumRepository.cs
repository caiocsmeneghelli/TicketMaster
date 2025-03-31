using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Domain.Repositories
{
    public interface IAuditoriumRepository
    {
        Task<List<Auditorium>> GetAllAsync();
        Task<List<Auditorium>> GetAllByTheaterAsync(int idTheater);
        Task<int> CreateAsync(Auditorium auditorium);
    }
}
