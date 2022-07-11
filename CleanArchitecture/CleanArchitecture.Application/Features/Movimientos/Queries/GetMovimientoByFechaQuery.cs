using MediatR;

using CleanArchitecture.Application.Features.Movimientos;

namespace CleanArchitecture.Application.Features.Movimeintos.Queries
{
    public class GetMovimientoByFechaQuery: IRequest<List<MovimientoVM>>
    {
        public string _Fecha { get; set; }

        public GetMovimientoByFechaQuery(string fecha) {
            _Fecha = fecha;
        }

    }
}
