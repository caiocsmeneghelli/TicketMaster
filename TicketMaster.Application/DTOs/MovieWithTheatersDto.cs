using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.DTOs
{
    public class MovieWithTheatersViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<TheaterWithSessionDto> Theaters { get; set; } = new();

        public void FromMovieSessions(List<MovieSession> movies)
        {
            var first = movies.First();
            Id = first.Movie.Id;
            Title = first.Movie.Title;
            Theaters = movies
                .GroupBy(x => x.Auditorium.Theater.Id)
                .Select(g => new TheaterWithSessionDto
                {
                    Id = g.First().Auditorium.Theater.Id,
                    Name = g.First().Auditorium.Theater.Name,
                    Sessions = g.Select(s => new MovieSessionGuidTimeDto
                    {
                        Guid = s.Guid,
                        Time = s.SessionTime.ToString("HH:mm")
                    }).ToList()
                }).ToList();
        }
    }
}
