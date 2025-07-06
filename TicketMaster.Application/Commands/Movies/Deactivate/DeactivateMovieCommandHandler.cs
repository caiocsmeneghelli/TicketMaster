using MediatR;
using TicketMaster.Application.Repositories;
using TicketMaster.Application.UnitOfWork;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Commands.Movies.Deactivate
{
    public class DeactivateMovieCommandHandler : IRequestHandler<DeactivateMovieCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICachedMovieRepository _cache;

        public DeactivateMovieCommandHandler(IUnitOfWork unitOfWork, ICachedMovieRepository cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Result> Handle(DeactivateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _unitOfWork.MovieRepository.GetByIdAsync(request.Id);
            if (movie is null)
            {
                return Result.Failure("Movie not found.");
            }

            if (!movie.Active)
            {
                return Result.Failure("Movie is already inactive.");
            }

            try
            {
                await _unitOfWork.BeginTransaction();

                movie.Deactivate();
                await _unitOfWork.CompleteAsync();

                var movieSessions = await _unitOfWork.MovieSessionRepository
                    .GetAllAvailableByMovieWithTickets(request.Id);
                foreach (var session in movieSessions)
                {
                    session.Cancel();
                    await _unitOfWork.CompleteAsync();
                }

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                return Result.Failure($"An error occurred while deactivating the movie: {ex.Message}");
            }

            // refresh na lista de cache
            await _cache.RefreshActiveMovies();

            return Result<int>.Success(movie.Id);
        }
    }
}
