using FluentValidation;

namespace TicketMaster.Application.Commands.MovieSessions.Create
{
    public class CreateMovieSessionCommandValidator : AbstractValidator<CreateMovieSessionCommand>
    {
        public CreateMovieSessionCommandValidator()
        {
            RuleFor(x => x.IdMovie)
                .NotEmpty().WithMessage("ID do filme é obrigatório")
                .GreaterThan(0).WithMessage("ID do filme deve ser maior que zero");

            RuleFor(x => x.IdAuditorium)
                .NotEmpty().WithMessage("ID do auditório é obrigatório")
                .GreaterThan(0).WithMessage("ID do auditório deve ser maior que zero");

            RuleFor(x => x.AudioAttribute)
                .IsInEnum().WithMessage("Atributo de áudio inválido");

            RuleFor(x => x.ImageAttribute)
                .IsInEnum().WithMessage("Atributo de imagem inválido");

            RuleFor(x => x.SessionTime)
                .NotEmpty().WithMessage("Horário da sessão é obrigatório")
                .GreaterThan(DateTime.Now).WithMessage("Horário da sessão deve ser no futuro");
        }
    }
} 