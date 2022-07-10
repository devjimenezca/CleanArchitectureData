using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand>
    {
        private readonly IClienteRepository _ClienteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteClienteCommandHandler> _logger;

        public DeleteClienteCommandHandler(IClienteRepository ClienteRepository, IMapper mapper, ILogger<DeleteClienteCommandHandler> logger)
        {
            _ClienteRepository = ClienteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var ClienteToDelete = await _ClienteRepository.GetByIdAsync(request.ClienteId);
            if (ClienteToDelete == null)
            {
                _logger.LogError($"{request.ClienteId} Cliente no existe en el sistema");
                throw new NotFoundException(nameof(Cliente), request.ClienteId);      
            }
            ClienteToDelete.Estado = 0;
            await _ClienteRepository.UpdateAsync(ClienteToDelete);
            
            _logger.LogInformation($"El {request.ClienteId} Cliente fue eliminado con exito");

            return Unit.Value;
        }
    }
}
