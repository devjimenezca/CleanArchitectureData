using AutoMapper;
using MediatR;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Features.Cuentas.Queries
{
    public class GetCuentaByIdentQueryHandler : IRequestHandler<GetCuentaByClienteIdQuery, List<CuentaVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetCuentaByIdentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<CuentaVM>> Handle(GetCuentaByClienteIdQuery request, CancellationToken cancellationToken)
        {
            var Cuenta = await _unitOfWork.CuentaRepository.GetCuentaById(request._ClienteId);
            return _mapper.Map<List<CuentaVM>>(Cuenta);
        }
    }
}
