using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.Entities
{
    public class Movie
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Director { get; private set; }
        public DateTime ReleaseDate { get; private set; }
    }
}
