using CleanArchitecture.Application.Features.Clientes;
using CleanArchitecture.Application.Features.Clientes.Queries;
using CleanArchitecture.Application.Features.Clientes.Commands;
using CleanArchitecture.Application.Features.Clientes.Commands.DeleteCliente;
using CleanArchitecture.Application.Features.Clientes.Commands.UpdateCliente;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClienteController : ControllerBase
    {

        private IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetClienteList")]
        [ProducesResponseType(typeof(IEnumerable<ClienteVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClienteVM>>> GetClienteList()
        {
            var query = new GetClienteAllQuery();
            var videos = await _mediator.Send(query);
            return Ok(videos);


        }

        [HttpGet("{identificacion}", Name = "GetCliente")]
        [ProducesResponseType(typeof(IEnumerable<ClienteVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClienteVM>>> GetCliente(string identificacion)
        {
            var query = new GetClienteByIdentQuery(identificacion);
            var videos = await _mediator.Send(query);
            return Ok(videos);


        }

        [HttpPost(Name = "CreateCliente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCliente([FromBody] CreateClienteCommand command)
        {
          return  await  _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCliente([FromBody] UpdateClienteCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            var command = new DeleteClienteCommand
            {
                ClienteId = id
            };

            await _mediator.Send(command);

            return NoContent();    
        }

    }
}
