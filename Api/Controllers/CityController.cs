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
    public class CityController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CityDto cityDto)
        {
            var result = await _mediator.Send(new CreateCityCommand(cityDto));

            if (result.Errors.Any())
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result = await _mediator.Send(new GetAllCityQuery());

            if (result.Errors.Any())
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-city-by-name")]
        public async Task<IActionResult> GetCityByName(string name)
        {

            var result = await _mediator.Send(new GetCityByNameQuery(name));

            if (result.Errors.Any())
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-city-by-state")]
        public async Task<IActionResult> GetCityByState(string state)
        {

            var result = await _mediator.Send(new GetCityByStateQuery(state));

            if (result.Errors.Any())
                return BadRequest(result);

            return Ok(result);
        }
    }
}
