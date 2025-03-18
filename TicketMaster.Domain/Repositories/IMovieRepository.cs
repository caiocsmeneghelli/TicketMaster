using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<List<Movie>> GetAllActiveAsync();
    }
}
