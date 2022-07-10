using MediatR;

namespace CleanArchitecture.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommand : IRequest
    {
        public int ClienteId { get; set; }
    }
}
