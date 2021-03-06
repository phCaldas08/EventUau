using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Evento.Commands.CancelarEvento;
using Event.Uau.Evento.Core.Evento.Commands.CriarEvento;
using Event.Uau.Evento.Core.Evento.Commands.FinalizarEvento;
using Event.Uau.Evento.Core.Evento.Queries.BuscaEventoPorId;
using Event.Uau.Evento.Core.Evento.Queries.ListarEventos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Evento.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class EventosController : BaseController
    {

        [HttpGet("{idEvento}")]
        public async Task<IActionResult> BuscaEventoPorId([FromRoute] BuscaEventoPorIdQuery query)
        {
            query.IdUsuarioLogado = IdUsuarioLogado;
            query.Token = Token;

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarEventos([FromQuery] ListarEventosQuery query)
        {
            query.IdUsuarioLogado = IdUsuarioLogado;
            query.Token = Token;

            var eventos = await Mediator.Send(query);

            return Ok(eventos);
        }


        [HttpPost]
        public async Task<IActionResult> CriarEvento([FromBody] CriarEventoCommand command)
        {
            command.IdUsuarioLogado = IdUsuarioLogado;
            command.Token = Token;

            var createdEvent = await Mediator.Send(command);

            return Created(string.Empty, createdEvent);
        }

        [HttpPut("{idEvento}/finalizar")]
        public async Task<IActionResult> FinalizarEvento([FromRoute] int idEvento, [FromBody] FinalizarEventoCommand command)
        {
            command.IdEvento = idEvento;
            command.IdUsuarioLogado = IdUsuarioLogado;
            command.Token = Token;

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{idEvento}")]
        public async Task<IActionResult> CancelarEvento([FromRoute] int idEvento)
        {
            var command = new CancelarEventoCommand
            {
                IdEvento = idEvento,
                IdUsuarioLogado = IdUsuarioLogado,
                Token = Token
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }

    }
}
