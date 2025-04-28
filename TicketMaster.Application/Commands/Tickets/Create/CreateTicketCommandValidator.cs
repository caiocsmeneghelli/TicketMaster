using FluentValidation;

namespace TicketMaster.Application.Commands.Tickets.Create
{
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {
            RuleFor(x => x.GuidMovieSession)
                .NotEmpty().WithMessage("ID da sessão é obrigatório");

            RuleFor(x => x.Seat)
                .NotEmpty().WithMessage("Número do assento é obrigatório")
                .Matches(@"^[A-Z]\d{1,2}$").WithMessage("Formato do assento inválido. Use o formato 'A1', 'B2', etc.");

            RuleFor(x => x.PaymentType)
                .IsInEnum().WithMessage("Tipo de pagamento inválido");
        }
    }
} 