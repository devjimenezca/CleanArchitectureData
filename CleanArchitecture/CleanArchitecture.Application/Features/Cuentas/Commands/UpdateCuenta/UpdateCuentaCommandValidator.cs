using FluentValidation;

namespace CleanArchitecture.Application.Features.Cuentas.Commands.UpdateCuenta
{
    public class UpdateCuentaCommandValidator : AbstractValidator<UpdateCuentaCommand>
    {
        public UpdateCuentaCommandValidator()
        {
            RuleFor(p => p.CuentaId)
                .NotNull().WithMessage("{CuentaId} no permite valores nulos");

            
        }
    }
}
