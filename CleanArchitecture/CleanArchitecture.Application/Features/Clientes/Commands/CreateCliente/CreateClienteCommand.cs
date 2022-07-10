using MediatR;

namespace CleanArchitecture.Application.Features.Clientes.Commands
{
    public class CreateClienteCommand : IRequest<int>
    {
        public string Contrasenia { get; set; } = String.Empty;
        public string Nombre { get; set; } = String.Empty;
        public string Genero { get; set; } = String.Empty;
        public int Edad { get; set; }
        public string Identificacion { get; set; } = String.Empty;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int Estado { get; set; } = 1;

    }
}
