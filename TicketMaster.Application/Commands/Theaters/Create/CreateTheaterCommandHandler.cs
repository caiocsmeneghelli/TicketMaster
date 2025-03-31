using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Commands.Theaters.Create
{
    public class CreateTheaterCommandHandler : IRequestHandler<CreateTheaterCommand, int>
    {
        private readonly ITheaterRepository _repository;

        public CreateTheaterCommandHandler(ITheaterRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateTheaterCommand request, CancellationToken cancellationToken)
        {
            Theater theater = new Theater(request.Name, request.Address, request.Contact);
            int idTheater = await _repository.CreateAsync(theater);
            return idTheater;
        }
    }
}
