using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain
{
    public abstract class Persona : BaseDomainModel
    {

        public string Nombre { get; set; } = String.Empty;
        public string Genero { get; set; } = String.Empty;
        public int Edad { get; set; }
        public string Identificacion { get; set; } = String.Empty;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }
}
