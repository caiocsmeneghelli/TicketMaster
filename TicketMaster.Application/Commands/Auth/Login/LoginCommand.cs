using MediatR;
using TicketMaster.Domain.Common;

namespace TicketMaster.Application.Commands.Auth.Login
{
    public class LoginCommand : IRequest<Result>
    {
        public string Username { get; }
        public string Password { get; }

        public LoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
