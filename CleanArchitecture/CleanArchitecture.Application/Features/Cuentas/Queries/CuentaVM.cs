
namespace CleanArchitecture.Application.Features.Cuentas
{
    public class CuentaVM
    {
        public int CuentaId { get; set; }
        public string NumeroCuenta { get; set; } = String.Empty;
        public decimal SaldoInicial { get; set; }

        public int ClienteId { get; set; }
        public int TipoCuentaId { get; set; }

        public int Estado { get; set; }

        public string Cliente { get; set; } = String.Empty;
        public string TipoCuenta { get; set; } = String.Empty;

    }

}
