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

            var movieViewModel = new MovieWithTheatersViewModel();
            movieViewModel.FromMovieSessions(results);

            return movieViewModel;
        }
    }
}