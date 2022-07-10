using FluentValidation;

namespace CleanArchitecture.Application.Features.Movimientos.Commands
{
    public class CreateMovimientoCommandValidator : AbstractValidator<CreateMovimientoCommand>
    {
        public CreateMovimientoCommandValidator()
        {
            //RuleFor(p => p.SaldoInicial)
            //    .NotNull().WithMessage("{SaldoInicial} no puede ser nulo");

        }
    }
}
