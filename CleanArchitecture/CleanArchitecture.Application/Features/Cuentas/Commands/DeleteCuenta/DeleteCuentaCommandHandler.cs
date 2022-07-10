using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Cuentas.Commands.DeleteCuenta
{
    public class DeleteCuentaCommandHandler : IRequestHandler<DeleteCuentaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        // private readonly ICuentaRepository _cuentaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCuentaCommandHandler> _logger;

        public DeleteCuentaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteCuentaCommandHandler> logger)
        {
            //   _cuentaRepository = cuentaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCuentaCommand request, CancellationToken cancellationToken)
        {
            var CuentaToDelete = await _unitOfWork.Repository<Cuenta>().GetByIdAsync(request.CuentaId);
            if (CuentaToDelete == null)
            {
                _logger.LogError($"{request.CuentaId} Cuenta no existe en el sistema");
                throw new NotFoundException(nameof(Cuenta), request.CuentaId);      
            }

            //  await _cuentaRepository.DeleteAsync(CuentaToDelete);
            CuentaToDelete.Estado = 0;
            _unitOfWork.Repository<Cuenta>().UpdateEntity(CuentaToDelete);
            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.CuentaId} Cuenta fue eliminado con exito");

            return Unit.Value;
        }
    }
}
