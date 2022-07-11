using AutoMapper;
using MediatR;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Application.Features.Movimientos;
using System.Globalization;
using CleanArchitecture.Application.Exceptions;

namespace CleanArchitecture.Application.Features.Movimeintos.Queries
{
    public class GetMovimientoByFechaQueryHandler : IRequestHandler<GetMovimientoByFechaQuery, List<MovimientoVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetMovimientoByFechaQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<MovimientoVM>> Handle(GetMovimientoByFechaQuery request, CancellationToken cancellationToken)
        {
            var date = DateTime.UtcNow;
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            var styles = DateTimeStyles.None;

            if (date == null)
                throw new Exception("Fecha incorrecta");

              DateTime.TryParse(request._Fecha, culture, styles, out date);
            var Movimeinto = await _unitOfWork.MovimientoRepository.GetMovimientoByFecha(date);
            return _mapper.Map<List<MovimientoVM>>(Movimeinto);
        }
    }
}
