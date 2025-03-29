using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Commands.Movies.Create
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly IMovieRepository _repository;

        public CreateMovieCommandHandler(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie(request.Title, request.Director,
                request.ReleaseDate, request.Description, request.Genre);
            var idMovie = await _repository.CreateAsync(movie);
            return idMovie;
        }
    }
}
