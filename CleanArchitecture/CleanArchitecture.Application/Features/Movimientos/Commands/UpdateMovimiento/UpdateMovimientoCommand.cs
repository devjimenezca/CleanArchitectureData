using MediatR;

namespace CleanArchitecture.Application.Features.Movimientos.Commands.UpdateMovimiento
{
    public  class UpdateMovimientoCommand : IRequest 
    {
        public int MovimientoId { get; set; }
        public decimal SaldoInicial { get; set; }
    }
}
