using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Evento.Commands.CriarEvento;
using Event.Uau.Evento.Core.Evento.Queries.BuscaEventoPorId;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Evento.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class EventController : BaseController
    {

        [HttpGet("{idEvento}")]
        public async Task<IActionResult> BuscaEventoPorId([FromRoute] int idEvento)
        {
            var query = new BuscaEventoPorIdQuery { IdEvento = idEvento };

            var result = await Mediator.Send(query);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CriarEvento([FromBody] CriarEventoCommand command)
        {
            var createdEvent = await Mediator.Send(command);

            return Created(string.Empty, createdEvent);
        }

    }
}
