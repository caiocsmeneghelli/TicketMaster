using FluentValidation;

namespace TicketMaster.Application.Commands.Auditoriums.Create
{
    public class CreateAuditoriumCommandValidator : AbstractValidator<CreateAuditoriumCommand>
    {
        public CreateAuditoriumCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome do auditório é obrigatório")
                .MinimumLength(2).WithMessage("Nome do auditório deve ter no mínimo 2 caracteres")
                .MaximumLength(100).WithMessage("Nome do auditório deve ter no máximo 100 caracteres");

            RuleFor(x => x.TotalSeats)
                .NotEmpty().WithMessage("Número total de assentos é obrigatório")
                .GreaterThan(0).WithMessage("Número total de assentos deve ser maior que zero")
                .LessThanOrEqualTo(500).WithMessage("Número total de assentos não pode exceder 500");

            RuleFor(x => x.AuditoriumType)
                .IsInEnum().WithMessage("Tipo de auditório inválido");

            RuleFor(x => x.IdTheater)
                .NotEmpty().WithMessage("ID do teatro é obrigatório")
                .GreaterThan(0).WithMessage("ID do teatro deve ser maior que zero");
        }
    }
} 