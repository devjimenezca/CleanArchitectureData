using FluentValidation;

namespace CleanArchitecture.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no permite valores nulos");

            RuleFor(p => p.Identificacion)
                .NotNull().WithMessage("{Identificacion} no permite valores nulos");
        }
    }
}
