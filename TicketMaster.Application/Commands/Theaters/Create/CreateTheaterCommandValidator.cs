using FluentValidation;

namespace TicketMaster.Application.Commands.Theaters.Create
{
    public class CreateTheaterCommandValidator : AbstractValidator<CreateTheaterCommand>
    {
        public CreateTheaterCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome do teatro é obrigatório")
                .MinimumLength(2).WithMessage("Nome do teatro deve ter no mínimo 2 caracteres")
                .MaximumLength(100).WithMessage("Nome do teatro deve ter no máximo 100 caracteres");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Endereço é obrigatório")
                .MinimumLength(5).WithMessage("Endereço deve ter no mínimo 5 caracteres")
                .MaximumLength(200).WithMessage("Endereço deve ter no máximo 200 caracteres");

            RuleFor(x => x.Contact)
                .NotEmpty().WithMessage("Contato é obrigatório")
                .MinimumLength(5).WithMessage("Contato deve ter no mínimo 5 caracteres")
                .MaximumLength(100).WithMessage("Contato deve ter no máximo 100 caracteres");
        }
    }
} 