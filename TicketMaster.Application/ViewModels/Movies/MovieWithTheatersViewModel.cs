using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.ViewModels.Theaters;

namespace TicketMaster.Application.ViewModels.Movies
{
    public class MovieWithTheatersViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<TheaterWithSessionViewModel> Theaters { get; set; } = new();
    }
}
