using MediatR;

namespace CleanArchitecture.Application.Features.Movimientos.Commands
{
    public class CreateMovimientoCommand : IRequest<int>
    {
      
        
        public decimal Valor { get; set; }
        

        public int CuentaId { get; set; }

        public int TipoMovimientoId { get; set; }

    }
}
