using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Cuentas.Commands.UpdateCuenta
{
    public class UpdateCuentaCommandHandler : IRequestHandler<UpdateCuentaCommand>
    {
        //  private readonly ICuentaRepository _CuentaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCuentaCommandHandler> _logger;

        public UpdateCuentaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCuentaCommandHandler> logger)
        {
            //  _CuentaRepository = CuentaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCuentaCommand request, CancellationToken cancellationToken)
        {
            // var CuentaToUpdate =  await  _CuentaRepository.GetByIdAsync(request.CuentaId);
            var CuentaToUpdate = await _unitOfWork.Repository<Cuenta>().GetByIdAsync(request.CuentaId);
            if (CuentaToUpdate == null)
            {
                _logger.LogError($"No se encontro el Cuenta id {request.CuentaId}");
                throw new NotFoundException(nameof(Cuenta), request.CuentaId);
            }

            _mapper.Map(request, CuentaToUpdate, typeof(UpdateCuentaCommand), typeof(Cuenta));

            //  await _CuentaRepository.UpdateAsync(CuentaToUpdate);
            CuentaToUpdate.Estado = request.Estado;
            var result = await _unitOfWork.Repository<Cuenta>().UpdateAsync(CuentaToUpdate);
            

            _logger.LogInformation($"La operacion fue exitosa actualizando el Cuenta {request.CuentaId}");

            return Unit.Value;
        }
    }
}
