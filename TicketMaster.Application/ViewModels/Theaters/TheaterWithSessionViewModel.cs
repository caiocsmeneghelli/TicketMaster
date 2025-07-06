using TicketMaster.Application.ViewModels.MovieSessions;

namespace TicketMaster.Application.ViewModels.Theaters
{
    public class TheaterWithSessionViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<MovieSessionGuidTimeViewModel> Sessions { get; set; } = new();
    }
}
