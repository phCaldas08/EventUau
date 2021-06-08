using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Event.Commands.Create;
using Event.Uau.Evento.Core.Event.Commands.Update;
using Event.Uau.Evento.Core.Event.Queries.GetById;
using Event.Uau.Evento.Core.Event.Queries.GetList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event.Uau.Evento.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class EventController : BaseController
    {

        [HttpGet("{key}")]
        public async Task<IActionResult> Get([FromRoute] Guid key)
        {
            var query = new GetByIdQuery { Key = key };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventCommand command)
        {
            var createdEvent = await Mediator.Send(command);

            return Ok(createdEvent);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEventCommand command)
        {
            var updatedEvent = await Mediator.Send(command);

            return Ok(updatedEvent);
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete([FromRoute] Guid key)
        {

            return Ok();
        }

    }
}
