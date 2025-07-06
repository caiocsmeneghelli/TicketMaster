using MediatR;
using System.Collections.Generic;
using TicketMaster.Application.Queries.Movies.GetAllActive;
using TicketMaster.Application.ViewModels.Movies;
using TicketMaster.Application.ViewModels.MovieSessions;
using TicketMaster.Application.ViewModels.Theaters;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Queries.MovieSessions.GetAllByMovieAndDate
{
    public class GetAllMovieSessionsByMovieAndDateQueryHander : IRequestHandler<GetAllMovieSessionsByMovieAndDateQuery, MovieWithTheatersViewModel>
    {
        private readonly IMovieSessionRepository _repository;

        public GetAllMovieSessionsByMovieAndDateQueryHander(IMovieSessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieWithTheatersViewModel> Handle(GetAllMovieSessionsByMovieAndDateQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetAllByMovieAndDate(request.IdMovie, request.Date);
            if(results == null || results.Count == 0)
            {
                return new MovieWithTheatersViewModel();
            }

            var first = results.First();
            var movieViewModel = new MovieWithTheatersViewModel
            {
                Id = first.Movie.Id,
                Title = first.Movie.Title,
                Theaters = results
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
                }).ToList()
            };

            return movieViewModel;
        }
    }
}