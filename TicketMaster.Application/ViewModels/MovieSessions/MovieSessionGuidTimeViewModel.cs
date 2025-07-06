using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Application.ViewModels.MovieSessions
{
    public class MovieSessionGuidTimeViewModel
    {
        public Guid Guid { get; set; }
        public string Time { get; set; } = string.Empty;
    }
}
