using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateClienteCommandHandler> _logger;

        public UpdateClienteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateClienteCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
           var ClienteToUpdate =  await _unitOfWork.Repository<Cliente>().GetByIdAsync(request.ClienteId);

            if (ClienteToUpdate == null)
            {
                _logger.LogError($"No se encontro el Cliente id {request.ClienteId}");
                throw new NotFoundException(nameof(Cliente), request.ClienteId);
            }

            _mapper.Map(request, ClienteToUpdate, typeof(UpdateClienteCommand), typeof(Cliente));

            //  await _CuentaRepository.UpdateAsync(CuentaToUpdate);
            var result = await _unitOfWork.Repository<Cliente>().UpdateAsync(ClienteToUpdate);
            
            _logger.LogInformation($"La operacion fue exitosa actualizando el Cliente {request.ClienteId}");

            return Unit.Value;
        }
    }
}
