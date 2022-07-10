using MediatR;
using CleanArchitecture.Application.Features.Cuentas;

namespace CleanArchitecture.Application.Features.Cuentas.Queries
{
    public class GetCuentaByClienteIdQuery: IRequest<List<CuentaVM>>
    {
        public int _ClienteId { get; set; }

        public GetCuentaByClienteIdQuery(int clienteId) {
            _ClienteId = clienteId;
        }

    }
}
