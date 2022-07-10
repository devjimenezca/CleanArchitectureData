using FluentValidation;

namespace CleanArchitecture.Application.Features.Clientes.Commands
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caracteres");

            RuleFor(p => p.Identificacion)
                 .NotEmpty().WithMessage("La {Identificacion} no puede estar en blanco")
                 .NotNull()
                 .MaximumLength(14).WithMessage("{Identificacion} no puede exceder los 14 caracteres");
            RuleFor(p => p.Contrasenia)
                 .NotEmpty().WithMessage("La {Contrasenia} no puede estar en blanco")
                 .NotNull()
                 .MinimumLength(5).WithMessage("{Contrasenia} minimo los 5 caracteres");

        }
    }
}
