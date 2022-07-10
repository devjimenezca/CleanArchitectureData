using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Movimientos.Commands.UpdateMovimiento
{
    public class UpdateMovimientoCommandHandler : IRequestHandler<UpdateMovimientoCommand>
    {
        //  private readonly IMovimientoRepository _MovimientoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateMovimientoCommandHandler> _logger;

        public UpdateMovimientoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateMovimientoCommandHandler> logger)
        {
            //  _MovimientoRepository = MovimientoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateMovimientoCommand request, CancellationToken cancellationToken)
        {
            // var MovimientoToUpdate =  await  _MovimientoRepository.GetByIdAsync(request.MovimientoId);
            var MovimientoToUpdate = await _unitOfWork.Repository<Movimiento>().GetByIdAsync(request.MovimientoId);
            if (MovimientoToUpdate == null)
            {
                _logger.LogError($"No se encontro el Movimiento id {request.MovimientoId}");
                throw new NotFoundException(nameof(Movimiento), request.MovimientoId);
            }

            _mapper.Map(request, MovimientoToUpdate, typeof(UpdateMovimientoCommand), typeof(Movimiento));

            //  await _MovimientoRepository.UpdateAsync(MovimientoToUpdate);
            _unitOfWork.Repository<Movimiento>().UpdateEntity(MovimientoToUpdate);
            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando el Movimiento {request.MovimientoId}");

            return Unit.Value;
        }
    }
}
