using CleanArchitecture.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain
{
    public class Cuenta : BaseDomainModel
    {

        public int CuentaId { get; set; }
        [MaxLength(15)]
        public string NumeroCuenta { get; set; } = String.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoInicial { get; set; }

        public int ClienteId { get; set; }
        public int TipoCuentaId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual TipoCuenta TipoCuenta { get; set; }
    }
}
