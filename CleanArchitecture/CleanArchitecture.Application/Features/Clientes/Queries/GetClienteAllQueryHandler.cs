using AutoMapper;
using MediatR;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Features.Clientes.Queries
{
    public class GetClienteAllQueryHandler : IRequestHandler<GetClienteAllQuery, List<ClienteVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetClienteAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<ClienteVM>> Handle(GetClienteAllQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _unitOfWork.ClienteRepository.GetClienteAll();
            return _mapper.Map<List<ClienteVM>>(cliente);
        }

    }
}
