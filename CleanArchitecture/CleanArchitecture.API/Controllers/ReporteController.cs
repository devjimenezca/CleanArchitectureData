using CleanArchitecture.Application.Features.Movimeintos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CleanArchitecture.Application.Features.Movimientos;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReporteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReporteController(IMediator mediator)
        {
            _mediator = mediator;
        }
     

         [HttpGet("{fecha}", Name = "GetReporte")]
        [ProducesResponseType(typeof(IEnumerable<MovimientoVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MovimientoVM>>> GetReporte(string fecha)
        {
            var query = new GetMovimientoByFechaQuery(fecha);
            var result = await _mediator.Send(query);
            return Ok(result);


        }
    }

}
