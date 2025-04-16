using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.Auditoriums.Create
{
    public class CreateAuditoriumCommandHandler : IRequestHandler<CreateAuditoriumCommand, Result<int>>
    {
        private readonly IAuditoriumRepository _repository;

        public CreateAuditoriumCommandHandler(IAuditoriumRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(CreateAuditoriumCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Auditorium auditorium = new Auditorium(request.Name, request.IdTheater, request.TotalSeats, request.AuditoriumType);
                int idAuditorium = await _repository.CreateAsync(auditorium);
                return Result<int>.Success(idAuditorium);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure(ex.Message);
            }
        }
    }
}
