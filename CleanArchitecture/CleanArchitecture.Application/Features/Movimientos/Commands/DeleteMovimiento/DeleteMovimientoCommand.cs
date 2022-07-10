using MediatR;

namespace CleanArchitecture.Application.Features.Movimientos.Commands.DeleteMovimiento
{
    public class DeleteMovimientoCommand : IRequest
    {
        public int MovimientoId { get; set; }
    }
}
