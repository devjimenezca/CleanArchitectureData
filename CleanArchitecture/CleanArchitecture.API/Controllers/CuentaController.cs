
using CleanArchitecture.Application.Features.Cuentas;
using CleanArchitecture.Application.Features.Cuentas.Commands;
using CleanArchitecture.Application.Features.Cuentas.Commands.DeleteCuenta;
using CleanArchitecture.Application.Features.Cuentas.Commands.UpdateCuenta;
using CleanArchitecture.Application.Features.Cuentas.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CuentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{ClienteId}", Name = "GetCuentaList")]
        [ProducesResponseType(typeof(IEnumerable<CuentaVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CuentaVM>>> GetCuentasList(int clienteId)
        {
            var query = new GetCuentaByClienteIdQuery(clienteId);
            var cuentas = await _mediator.Send(query);


            return Ok(cuentas);


        }
        [HttpPost(Name = "CreateCuenta")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCuenta([FromBody] CreateCuentaCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateCuenta")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCuenta([FromBody] UpdateCuentaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteCuenta")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCuenta(int id)
        {
            var command = new DeleteCuentaCommand
            {
                CuentaId = id
            };

            await _mediator.Send(command);

            return NoContent();
        }



    }

}
