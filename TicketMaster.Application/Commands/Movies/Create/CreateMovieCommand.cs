using MediatR;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.Movies.Create
{
    public class CreateMovieCommand : IRequest<Result<int>>
    {
        public string? Title { get; set; }
        public string? Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
    }
}
