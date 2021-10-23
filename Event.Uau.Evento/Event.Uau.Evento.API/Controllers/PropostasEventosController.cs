using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Proposta.Commands.AceitarProposta;
using Event.Uau.Evento.Core.Proposta.Commands.EnviarPropostaFuncionario;
using Event.Uau.Evento.Core.Proposta.Commands.RecusarProposta;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Evento.API.Controllers
{
    [Route("api/eventos/{idEvento}/propostas")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class PropostasEventosController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> EnviarProposta([FromRoute] int idEvento, [FromBody] EnviarPropostaFuncionarioCommand command)
        {
            command.IdUsuarioLogado = IdUsuarioLogado;
            command.Token = Token;
            command.IdEvento = idEvento;

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AceitarProposta([FromRoute] int idEvento, [FromBody] AceitarPropostaCommand command)
        {
            command.IdUsuarioLogado = IdUsuarioLogado;
            command.Token = Token;
            command.IdEvento = idEvento;

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RecusarProposta([FromRoute] int idEvento)
        {
            var command = new RecusarPropostaCommand
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
