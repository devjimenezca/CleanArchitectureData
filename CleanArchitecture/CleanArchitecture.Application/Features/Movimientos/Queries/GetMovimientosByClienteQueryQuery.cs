using MediatR;

using CleanArchitecture.Application.Features.Movimientos;

namespace CleanArchitecture.Application.Features.Movimeintos.Queries
{
    public class GetMovimientosByClienteQuery: IRequest<List<MovimientoVM>>
    {
        public int _ClienteId { get; set; }

        public GetMovimientosByClienteQuery(int clienteId) {
            _ClienteId = clienteId;
        }

    }
}
