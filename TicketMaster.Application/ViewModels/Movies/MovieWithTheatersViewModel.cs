using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Application.ViewModels.MovieSessions;
using TicketMaster.Application.ViewModels.Theaters;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;

namespace TicketMaster.Application.ViewModels.Movies
{
    public class MovieWithTheatersViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<TheaterWithSessionViewModel> Theaters { get; set; } = new();

        public void FromMovieSessions(List<MovieSession> movies)
        {
            var first = movies.First();
            Id = first.Movie.Id;
            Title = first.Movie.Title;
            Theaters = movies
                .GroupBy(x => x.Auditorium.Theater.Id)
                .Select(g => new TheaterWithSessionViewModel
                {
                    Id = g.First().Auditorium.Theater.Id,
                    Name = g.First().Auditorium.Theater.Name,
                    Sessions = g.Select(s => new MovieSessionGuidTimeViewModel
                    {
                        Guid = s.Guid,
                        Time = s.SessionTime.ToString("HH:mm")
                    }).ToList()
                }).ToList();
        }
    }
}
