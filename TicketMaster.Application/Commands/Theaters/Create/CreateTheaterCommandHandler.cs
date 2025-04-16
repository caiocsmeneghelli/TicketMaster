using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.Theaters.Create
{
    public class CreateTheaterCommandHandler : IRequestHandler<CreateTheaterCommand, Result<int>>
    {
        private readonly ITheaterRepository _repository;

        public CreateTheaterCommandHandler(ITheaterRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(CreateTheaterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Theater theater = new Theater(request.Name, request.Address, request.Contact);
                int idTheater = await _repository.CreateAsync(theater);
                return Result<int>.Success(idTheater);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure(ex.Message);
            }
        }
    }
}
