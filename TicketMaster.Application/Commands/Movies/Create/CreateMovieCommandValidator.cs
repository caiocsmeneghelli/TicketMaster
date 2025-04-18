using FluentValidation;

namespace TicketMaster.Application.Commands.Movies.Create
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Titulo não pode ser vazio")
                .MinimumLength(2).WithMessage("Titulo deve ter no minimo 2 caracteres")
                .MaximumLength(100).WithMessage("Titulo deve ter no máximo 100 caracteres");

            RuleFor(x => x.Director)
                .NotEmpty().WithMessage("Diretor não pode ser vazio")
                .MinimumLength(2).WithMessage("Diretor deve ter no minimo 2 caracteres")
                .MaximumLength(100).WithMessage("Diretor não pode passar de 100 caracteres");

            RuleFor(x => x.ReleaseDate)
                .NotEmpty().WithMessage("Data de lançamento não pode ser vazio")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Data de lançamento deve ser anterior ao dia de hoje");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Descrição não pode ser nula")
                .MinimumLength(10).WithMessage("Descrição deve ter no minimo 10 caracteres")
                .MaximumLength(1000).WithMessage("Descrição deve ter no maximo 10 caracteres");

            RuleFor(x => x.Genre)
                .NotEmpty().WithMessage("Genero não pode ser nulo")
                .MinimumLength(2).WithMessage("Genero deve ter no minimo 2 caracteres")
                .MaximumLength(50).WithMessage("Genero deve ter no maximo 50 caracteres");
        }
    }
} 