using FluentValidation;

namespace TicketMaster.Application.Commands.Movies.Create
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Titulo n�o pode ser vazio")
                .MinimumLength(2).WithMessage("Titulo deve ter no minimo 2 caracteres")
                .MaximumLength(100).WithMessage("Titulo deve ter no m�ximo 100 caracteres");

            RuleFor(x => x.Director)
                .NotEmpty().WithMessage("Diretor n�o pode ser vazio")
                .MinimumLength(2).WithMessage("Diretor deve ter no minimo 2 caracteres")
                .MaximumLength(100).WithMessage("Diretor n�o pode passar de 100 caracteres");

            RuleFor(x => x.ReleaseDate)
                .NotEmpty().WithMessage("Data de lan�amento n�o pode ser vazio")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Data de lan�amento deve ser anterior ao dia de hoje");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Descri��o n�o pode ser nula")
                .MinimumLength(10).WithMessage("Descri��o deve ter no minimo 10 caracteres")
                .MaximumLength(1000).WithMessage("Descri��o deve ter no maximo 10 caracteres");

            RuleFor(x => x.Genre)
                .NotEmpty().WithMessage("Genero n�o pode ser nulo")
                .MinimumLength(2).WithMessage("Genero deve ter no minimo 2 caracteres")
                .MaximumLength(50).WithMessage("Genero deve ter no maximo 50 caracteres");
        }
    }
} 