using MediatR;
using TicketMaster.Domain.Common;
using TicketMaster.Domain.Repositories;
using TicketMaster.Domain.Services;

namespace TicketMaster.Application.Commands.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Lógica de autenticação
            var user = await _userRepository.FindActiveByEmailPasswordAsync(request.Username, request.Password);
            if (user == null)
            {
                return Result.Failure("Usuário ou senha inválidos.");
            }

            var token = _authService.GenerateJwtToken(user.Email, "teste");
            return Result<string>.Success(token);
        }
    }
}