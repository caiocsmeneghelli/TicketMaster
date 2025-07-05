using MediatR;
using TicketMaster.Application.UnitOfWork;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.Movies.Deactivate
{
    public class DeactivateMovieCommandHandler : IRequestHandler<DeactivateMovieCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeactivateMovieCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            await _unitOfWork.BeginTransaction();

            movie.Deactivate();
            
            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitAsync();

            return Result<int>.Success(movie.Id);
        }
    }
}
