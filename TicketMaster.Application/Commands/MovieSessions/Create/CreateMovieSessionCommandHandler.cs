using MediatR;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.MovieSessions.Create
{
    public class CreateMovieSessionCommandHandler : IRequestHandler<CreateMovieSessionCommand, Result>
    {
        private readonly IMovieSessionRepository _repository;

        public CreateMovieSessionCommandHandler(IMovieSessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(CreateMovieSessionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var movieSession = new MovieSession(request.IdMovie, request.IdAuditorium, request.SessionTime,
                    request.ImageAttribute, request.AudioAttribute);
                Guid guidMovieSession = await _repository.CreateAsync(movieSession);
                return Result<Guid>.Success(guidMovieSession);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure(ex.Message);
            }
        }
    }
}
