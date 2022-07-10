using MediatR;

namespace CleanArchitecture.Application.Features.Clientes.Commands.UpdateCliente
{
    public  class UpdateClienteCommand : IRequest 
    {
        public int ClienteId { get; set; }
        public string Contrasenia { get; set; } = String.Empty;
        public string Nombre { get; set; } = String.Empty;
        public string Genero { get; set; } = String.Empty;
        public int Edad { get; set; }
        public string Identificacion { get; set; } = String.Empty;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int Estado { get; set; }
    }
}
