using CleanArchitecture.Application.Features.Movimientos;
using CleanArchitecture.Application.Features.Movimientos.Commands;
using CleanArchitecture.Application.Features.Movimeintos.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimientoController(IMediator mediator)
        {
            _mediator = mediator;
        }
     

         [HttpGet("{ClienteId}", Name = "GetMovimiento")]
        [ProducesResponseType(typeof(IEnumerable<MovimientoVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MovimientoVM>>> GetMovimiento(int ClienteId)
        {
            var query = new GetMovimientosByClienteQuery(ClienteId);
            var result = await _mediator.Send(query);
            return Ok(result);


        }


        [HttpPost(Name = "CreateMovimiento")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateMovimiento([FromBody] CreateMovimientoCommand command)
        {
            return await _mediator.Send(command);
        }

     
    }

}
