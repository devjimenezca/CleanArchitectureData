using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Movimientos.Commands
{
    public class CreateMovimientoCommandHandler : IRequestHandler<CreateMovimientoCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
   
        private readonly ILogger<CreateMovimientoCommandHandler> _logger;

        public CreateMovimientoCommandHandler(IMapper mapper, ILogger<CreateMovimientoCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateMovimientoCommand request, CancellationToken cancellationToken)
        {
            var MovimientoEntity = _mapper.Map<Movimiento>(request);
            var Cuenta = await _unitOfWork.Repository<Cuenta>().GetByIdAsync(request.CuentaId);

            if (Cuenta == null) {
                throw new Exception("No se puede insertar el record de la Movimiento la cuenta No Existe");
            }
            decimal total = 0;
            MovimientoEntity.SaldoInicial = Cuenta.SaldoInicial;
            if (MovimientoEntity.TipoMovimientoId == 1)
                total = MovimientoEntity.SaldoInicial + MovimientoEntity.Valor;
            else 
                total = MovimientoEntity.SaldoInicial - MovimientoEntity.Valor;


            if (total < 0)
            {
                throw new Exception("No se puede registrar el movimiento fondo insuficiente");
            }
            else
            {
                Cuenta.SaldoInicial = total;
                MovimientoEntity.Saldo = total;
            }
            var resultCuenta = await _unitOfWork.Repository<Cuenta>().UpdateAsync(Cuenta);
            var resultMovimiento = new Movimiento();
            if(resultCuenta !=null)
               resultMovimiento = await _unitOfWork.Repository<Movimiento>().AddAsync(MovimientoEntity);

            if (resultMovimiento == null) {
                _logger.LogError("No se insert");
                throw new Exception("No se puede insertar el record de la Movimiento");
            }
            _logger.LogInformation($"Movimiento {MovimientoEntity.MovimientoId} fue creado existosamente");

            return resultMovimiento.MovimientoId;
        }


    }
}
