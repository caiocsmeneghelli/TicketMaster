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
        private readonly ICachedMovieSessionRepository _cache;

        public GetAllMovieSessionsByMovieAndDateQueryHander(IMovieSessionRepository repository, ICachedMovieSessionRepository cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<MovieWithTheatersViewModel> Handle(GetAllMovieSessionsByMovieAndDateQuery request, CancellationToken cancellationToken)
        {
            var results = await _cache.GetMovieByMovieAndDate(request.IdMovie, request.Date);
            if (results == null || results.Count == 0)
            {
                return new MovieWithTheatersViewModel();
            }

            var movieViewModel = new MovieWithTheatersViewModel();
            movieViewModel.FromMovieSessions(results);

            return movieViewModel;
        }
    }
}