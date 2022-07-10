using CleanArchitecture.Application.Features.Movimientos;
using CleanArchitecture.Application.Features.Movimientos.Commands;
using CleanArchitecture.Application.Features.Movimeintos.Queries;
using CleanArchitecture.Application.Features.Movimientos.Commands.DeleteMovimiento;
using CleanArchitecture.Application.Features.Movimientos.Commands.UpdateMovimiento;
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
            var videos = await _mediator.Send(query);
            return Ok(videos);


        }


        [HttpPost(Name = "CreateMovimiento")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateMovimiento([FromBody] CreateMovimientoCommand command)
        {
            return await _mediator.Send(command);
        }

        //[HttpPut(Name = "UpdateMovimiento")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult> UpdateMovimiento([FromBody] UpdateMovimientoCommand command)
        //{
        //    await _mediator.Send(command);

        //    return NoContent();
        //}


        //[HttpDelete("{id}", Name = "DeleteMovimiento")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult> DeleteMovimiento(int id)
        //{
        //    var command = new DeleteMovimientoCommand
        //    {
        //        MovimientoId = id
        //    };

        //    await _mediator.Send(command);

        //    return NoContent();
        //}
    }

}
