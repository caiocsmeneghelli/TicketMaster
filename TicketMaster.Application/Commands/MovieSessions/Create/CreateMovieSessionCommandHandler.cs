using MediatR;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Commands.MovieSessions.Create
{
    public class CreateMovieSessionCommandHandler : IRequestHandler<CreateMovieSessionCommand, int>
    {
        private readonly IMovieSessionRepository _repository;

        public CreateMovieSessionCommandHandler(IMovieSessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateMovieSessionCommand request, CancellationToken cancellationToken)
        {
            var movieSession = new MovieSession(request.IdMovie, request.IdAuditorium, request.SessionTime,
                request.ImageAttribute, request.AudioAttribute);
            int idMovieSession = await _repository.CreateAsync(movieSession);
            return idMovieSession;
        }
    }
}
