using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Application.Commands.Auditoriums.Create
{
    public class CreateAuditoriumCommandHandler : IRequestHandler<CreateAuditoriumCommand, int>
    {
        private readonly IAuditoriumRepository _repository;

        public CreateAuditoriumCommandHandler(IAuditoriumRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateAuditoriumCommand request, CancellationToken cancellationToken)
        {
            Auditorium auditorium = new Auditorium(request.Name, request.IdTheater);
            int idAuditorium = await _repository.CreateAsync(auditorium);
            return idAuditorium;
        }
    }
}
