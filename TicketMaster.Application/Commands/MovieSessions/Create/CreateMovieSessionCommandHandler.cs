using MediatR;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.MovieSessions.Create
{
    public class CreateMovieSessionCommandHandler : IRequestHandler<CreateMovieSessionCommand, Result<int>>
    {
        private readonly IMovieSessionRepository _repository;

        public CreateMovieSessionCommandHandler(IMovieSessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(CreateMovieSessionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var movieSession = new MovieSession(request.IdMovie, request.IdAuditorium, request.SessionTime,
                    request.ImageAttribute, request.AudioAttribute);
                int idMovieSession = await _repository.CreateAsync(movieSession);
                return Result<int>.Success(idMovieSession);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure(ex.Message);
            }
        }
    }
}
