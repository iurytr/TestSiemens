using Application.Command;
using Application.Query;
using Domain.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/v1/[controller]/")]
    public class ClientController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClientDto createClient)
        {
            var result = await _mediator.Send(new CreateClientCommand(createClient));

            if (result.Errors.Any())
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result = await _mediator.Send(new GetAllClientQuery());

            if (result.Errors.Any())
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-client-by-name")]
        public async Task<IActionResult> GetClientByName(string name)
        {

            var result = await _mediator.Send(new GetClientByNameQuery(name));

            if (result.Errors.Any())
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-client-by-id/{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {

            var result = await _mediator.Send(new GetClientByIdQuery(id));

            if (result.Errors.Any())
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("update-client-name/{id}")]
        public async Task<IActionResult> UpdateClientName(int id, [FromBody]UpdateClientNameDto dto)
        {

            var result = await _mediator.Send(new UpdateClientNameCommand(id, dto.Name));

            if (result.Errors.Any())
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("delete-client/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {

            var result = await _mediator.Send(new DeleteClientCommand(id));

            if (result.Errors.Any())
                return BadRequest(result);

            return Ok(result);
        }
    }
}
