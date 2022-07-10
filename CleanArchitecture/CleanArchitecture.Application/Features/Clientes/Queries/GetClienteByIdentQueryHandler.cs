using AutoMapper;
using MediatR;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Features.Clientes.Queries
{
    public class GetClienteByIdentQueryHandler : IRequestHandler<GetClienteByIdentQuery, ClienteVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetClienteByIdentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<ClienteVM> Handle(GetClienteByIdentQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _unitOfWork.ClienteRepository.GetClienteByIdent(request._Identificacion);
            return _mapper.Map<ClienteVM>(cliente);
        }
    }
}
