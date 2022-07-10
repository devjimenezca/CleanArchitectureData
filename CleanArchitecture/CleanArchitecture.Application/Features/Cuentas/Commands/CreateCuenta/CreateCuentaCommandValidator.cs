using FluentValidation;

namespace CleanArchitecture.Application.Features.Cuentas.Commands
{
    public class CreateCuentaCommandValidator : AbstractValidator<CreateCuentaCommand>
    {
        public CreateCuentaCommandValidator()
        {
            RuleFor(p => p.NumeroCuenta)
                .NotEmpty().WithMessage("{NumeroCuenta} no puede estar en blanco")
                .NotNull()
                .MaximumLength(15).WithMessage("{NumeroCuenta} no puede exceder los 15 caracteres");

        }
    }
}
