using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Cuentas.Commands
{
    public class CreateCuentaCommandHandler : IRequestHandler<CreateCuentaCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
   
        private readonly ILogger<CreateCuentaCommandHandler> _logger;

        public CreateCuentaCommandHandler(IMapper mapper, ILogger<CreateCuentaCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCuentaCommand request, CancellationToken cancellationToken)
        {
            var cuentaEntity = _mapper.Map<Cuenta>(request);
           
            _unitOfWork.Repository<Cuenta>().AddAsync(cuentaEntity);
            var result = await _unitOfWork.Complete();



            if (result <= 0)
            {
                _logger.LogError("No se insert");
                throw new Exception("No se puede insertar el record de la cuenta");
            }
            _logger.LogInformation($"Cuenta {request.NumeroCuenta} fue creado existosamente");

            return result;
        }


    }
}
