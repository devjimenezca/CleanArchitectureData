using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class Cliente : Persona
    {
        public int ClienteId { get; set; }
        public string Contrasenia { get; set; } = String.Empty;
    }
}
