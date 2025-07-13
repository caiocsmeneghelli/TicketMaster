using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;
using TicketMaster.Domain.Services;

namespace TicketMaster.Application.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            string hashedPassword = _authService.ComputeSha256Hash(request.Password);
            User user = new User(request.Name, request.LastName, request.Email, hashedPassword);

            int idUser = await _userRepository.CreateUserAsync(user);
            return Result<int>.Success(idUser);
        }
    }
}
