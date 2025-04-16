using MediatR;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.Movies.Create
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Result<int>>
    {
        private readonly IMovieRepository _repository;

        public CreateMovieCommandHandler(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var movie = new Movie(request.Title, request.Director,
                    request.ReleaseDate, request.Description, request.Genre);
                var idMovie = await _repository.CreateAsync(movie);
                return Result<int>.Success(idMovie);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure(ex.Message);
            }
        }
    }
}
