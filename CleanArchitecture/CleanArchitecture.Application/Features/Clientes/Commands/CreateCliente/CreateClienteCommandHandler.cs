using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Clientes.Commands
{
    public class CreateCuentaCommandHandler : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IClienteRepository _ClienteRepository;
        private readonly IMapper _mapper;
   
        private readonly ILogger<CreateCuentaCommandHandler> _logger;

        public CreateCuentaCommandHandler(IClienteRepository ClienteRepository, IMapper mapper, ILogger<CreateCuentaCommandHandler> logger)
        {
            _ClienteRepository = ClienteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteEntity = _mapper.Map<Cliente>(request);
            var newCliente = await _ClienteRepository.AddAsync(clienteEntity);

            _logger.LogInformation($"Cliente {newCliente.ClienteId} fue creado existosamente");

    

            return newCliente.ClienteId;
        }


    }
}
