using FluentValidation;

namespace CleanArchitecture.Application.Features.Movimientos.Commands.UpdateMovimiento
{
    public class UpdateMovimientoCommandValidator : AbstractValidator<UpdateMovimientoCommand>
    {
        public UpdateMovimientoCommandValidator()
        {
            RuleFor(p => p.MovimientoId)
                .NotNull().WithMessage("{MovimientoId} no permite valores nulos");

            
        }
    }
}
