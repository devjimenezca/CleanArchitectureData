
namespace CleanArchitecture.Application.Features.Movimientos
{
    public class MovimientoVM
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

