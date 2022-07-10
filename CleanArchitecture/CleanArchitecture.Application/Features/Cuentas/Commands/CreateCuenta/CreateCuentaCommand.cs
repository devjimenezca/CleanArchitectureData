using MediatR;

namespace CleanArchitecture.Application.Features.Cuentas.Commands
{
    public class CreateCuentaCommand : IRequest<int>
    {
        public string NumeroCuenta { get; set; } = String.Empty;
        public decimal SaldoInicial { get; set; }

        public int ClienteId { get; set; }
        public int TipoCuentaId { get; set; }
        public int Estado { get; set; } = 1;

    }
}
