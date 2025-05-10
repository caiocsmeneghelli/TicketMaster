using FluentValidation;
using TicketMaster.Application.DTOs;
using TicketMaster.Domain.Enums;

namespace TicketMaster.Application.Commands.OrderRequests.Create
{
    public class CreateOrderRequestCommandValidator : AbstractValidator<CreateOrderRequestCommand>
    {
        public CreateOrderRequestCommandValidator()
        {
            RuleFor(x => x.GuidMovieSession)
                .NotEmpty()
                .WithMessage("O ID da sessão do filme é obrigatório");

            RuleFor(x => x.Tickets)
                .NotEmpty()
                .WithMessage("É necessário pelo menos um ingresso")
                .Must(tickets => tickets != null && tickets.Any())
                .WithMessage("A lista de ingressos não pode estar vazia");

            RuleFor(x => x.Payment)
                .NotNull()
                .WithMessage("As informações de pagamento são obrigatórias")
                .SetValidator(new PaymentDtoValidator());

            RuleForEach(x => x.Tickets)
                .SetValidator(new TicketDtoValidator());
        }
    }

    public class TicketDtoValidator : AbstractValidator<TicketDto>
    {
        public TicketDtoValidator()
        {
            RuleFor(x => x.Seat)
                .NotEmpty().WithMessage("O assento não pode ser vazio.")
                .Length(1, 3).WithMessage("O assento deve ter entre 1 e 3 caracteres.")
                .Matches(@"^[A-Za-z][0-9]{2}$")
                .WithMessage("O assento deve seguir o padrão de letra seguida por dois números (ex: A01, B02).")
        }
    }

    public class PaymentDtoValidator : AbstractValidator<PaymentDto>
    {
        public PaymentDtoValidator()
        {
            RuleFor(x => x.PaymentType)
                .IsInEnum()
                .WithMessage("O tipo de pagamento é inválido")
                .NotEmpty()
                .WithMessage("O tipo de pagamento é obrigatório");
        }
    }
} 