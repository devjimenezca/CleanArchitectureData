
namespace CleanArchitecture.Application.Features.Clientes
{
    public class ClienteVM
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public string Genero { get; set; } = String.Empty;
        public int Edad { get; set; }
        public string Identificacion { get; set; } = String.Empty;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int Estado { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }

}
