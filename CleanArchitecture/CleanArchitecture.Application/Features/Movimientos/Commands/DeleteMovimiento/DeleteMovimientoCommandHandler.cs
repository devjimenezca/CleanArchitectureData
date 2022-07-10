using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Movimientos.Commands.DeleteMovimiento
{
    public class DeleteMovimientoCommandHandler : IRequestHandler<DeleteMovimientoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        // private readonly IMovimientoRepository _MovimientoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteMovimientoCommandHandler> _logger;

        public DeleteMovimientoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteMovimientoCommandHandler> logger)
        {
            //   _MovimientoRepository = MovimientoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteMovimientoCommand request, CancellationToken cancellationToken)
        {
            var MovimientoToDelete = await _unitOfWork.Repository<Movimiento>().GetByIdAsync(request.MovimientoId);
            if (MovimientoToDelete == null)
            {
                _logger.LogError($"{request.MovimientoId} Movimiento no existe en el sistema");
                throw new NotFoundException(nameof(Movimiento), request.MovimientoId);      
            }

            //  await _MovimientoRepository.DeleteAsync(MovimientoToDelete);
            _unitOfWork.Repository<Movimiento>().DeleteEntity(MovimientoToDelete);
            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.MovimientoId} Movimiento fue eliminado con exito");

            return Unit.Value;
        }
    }
}
