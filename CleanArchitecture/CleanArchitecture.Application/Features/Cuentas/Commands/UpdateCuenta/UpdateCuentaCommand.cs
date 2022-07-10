using MediatR;

namespace CleanArchitecture.Application.Features.Cuentas.Commands.UpdateCuenta
{
    public class UpdateCuentaCommand : IRequest
    {
        public int CuentaId { get; set; }
        public int Estado { get; set; }
    }
}
