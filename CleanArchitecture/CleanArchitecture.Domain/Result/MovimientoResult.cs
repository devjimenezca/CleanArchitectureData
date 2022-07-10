using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Result
{
    public class MovimientoResult
    {
        public int CuentaId { get; set; }
        public string NumeroCuenta { get; set; } = String.Empty;
        public decimal SaldoInicial { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal Valor { get; set; }

        public int ClienteId { get; set; }
        public int TipoCuentaId { get; set; }
        public int TipoMovimientoId { get; set; }

        public string Cliente { get; set; } = String.Empty;
        public string TipoCuenta { get; set; } = String.Empty;
        public string TipoMovimiento { get; set; } = String.Empty;
        public string Fecha { get; set; } = String.Empty;
    }
}
