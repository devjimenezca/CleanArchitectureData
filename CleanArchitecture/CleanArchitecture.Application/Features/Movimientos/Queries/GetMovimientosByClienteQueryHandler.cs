using AutoMapper;
using MediatR;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Application.Features.Movimientos;

namespace CleanArchitecture.Application.Features.Movimeintos.Queries
{
    public class GetMovimientosByClienteQueryHandler : IRequestHandler<GetMovimientosByClienteQuery, List<MovimientoVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetMovimientosByClienteQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<MovimientoVM>> Handle(GetMovimientosByClienteQuery request, CancellationToken cancellationToken)
        {
            var Movimeinto = await _unitOfWork.MovimientoRepository.GetMovimientoById(request._ClienteId);
            return _mapper.Map<List<MovimientoVM>>(Movimeinto);
        }
    }
}
