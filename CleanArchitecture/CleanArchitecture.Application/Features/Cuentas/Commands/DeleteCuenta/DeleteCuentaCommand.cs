using MediatR;

namespace CleanArchitecture.Application.Features.Cuentas.Commands.DeleteCuenta
{
    public class DeleteCuentaCommand : IRequest
    {
        public int CuentaId { get; set; }
    }
}
