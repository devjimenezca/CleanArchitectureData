using MediatR;
using CleanArchitecture.Application.Features.Clientes;

namespace CleanArchitecture.Application.Features.Clientes.Queries
{
    public class GetClienteByIdentQuery: IRequest<ClienteVM>
    {
        public string _Identificacion { get; set; }

        public GetClienteByIdentQuery(string identificacion) {
            _Identificacion = identificacion;
        }

    }
}
