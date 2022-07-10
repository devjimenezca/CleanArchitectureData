using CleanArchitecture.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain
{
    public class Movimiento : BaseDomainModel
    {
        public int MovimientoId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Saldo { get; set; }

        public decimal SaldoInicial { get; set; }

        public int CuentaId { get; set; }
        public virtual Cuenta? Cuenta { get; set; }

        public int TipoMovimientoId { get; set; }
        public virtual TipoMovimiento? TipoMovimiento { get; set; }
    }
}
