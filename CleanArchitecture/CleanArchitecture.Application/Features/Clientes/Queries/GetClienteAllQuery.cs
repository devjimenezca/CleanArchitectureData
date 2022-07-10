using MediatR;
using CleanArchitecture.Application.Features.Clientes;

namespace CleanArchitecture.Application.Features.Clientes.Queries
{
    public class GetClienteAllQuery: IRequest<List<ClienteVM>>
    {

    }
}
