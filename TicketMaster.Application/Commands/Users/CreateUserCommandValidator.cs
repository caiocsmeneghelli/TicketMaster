using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Application.Commands.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(50).WithMessage("Nome não pode exceder 50 caracteres");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Sobrenome é obrigatório")
                .MaximumLength(50).WithMessage("Sobrenome não pode exceder 50 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email é obrigatório")
                .EmailAddress().WithMessage("Email inválido")
                .MaximumLength(100).WithMessage("Email não pode exceder 100 caracteres");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Senha é obrigatória")
                .MinimumLength(6).WithMessage("Senha deve ter pelo menos 6 caracteres")
                .MaximumLength(100).WithMessage("Senha não pode exceder 100 caracteres");
        }
    }
}
