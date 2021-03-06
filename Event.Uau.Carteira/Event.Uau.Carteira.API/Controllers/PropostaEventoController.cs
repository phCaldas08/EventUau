using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Carteira.Core.PropostaEvento.Commands.AceitarPropostaEvento;
using Event.Uau.Carteira.Core.PropostaEvento.Commands.CancelarEvento;
using Event.Uau.Carteira.Core.PropostaEvento.Commands.FinalizarPropostasEvento;
using Event.Uau.Carteira.Core.PropostaEvento.Commands.RecusarPropostaEvento;
using Event.Uau.Carteira.Core.ProspostaEvento.Commands.CriarOperacaoEvento;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Carteira.API.Controllers
{
    [Route("api/eventos/{idEvento}/propostas")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class PropostaEventoController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> CadastrarProposta([FromRoute] int idEvento, [FromBody] CriarOperacaoEventoCommand body)
        {
            body.IdUsuarioLogado = IdUsuarioLogado;
            body.IdEvento = idEvento;
            body.Token = Token;

            var result = await Mediator.Send(body);

            return Ok(result);
        }

        [HttpPut("finalizar")]
        public async Task<ActionResult> FinalizarEvento([FromRoute] int idEvento, [FromBody] FinalizarPropostasEventoCommand body)
        {
            body.IdUsuarioLogado = IdUsuarioLogado;
            body.IdEvento = idEvento;
            body.Token = Token;

            var result = await Mediator.Send(body);

            return Ok(result);
        }

        [HttpPut("aceitar")]
        public async Task<ActionResult> AceitarProposta([FromRoute] int idEvento, [FromBody] AceitarPropostaEventoCommand body)
        {
            body.IdUsuarioLogado = IdUsuarioLogado;
            body.IdEvento = idEvento;
            body.Token = Token;

            var result = await Mediator.Send(body);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> RecusarProposta([FromRoute] int idEvento)
        {
            var command = new RecusarPropostaEventoCommand
            {
                IdEvento = idEvento,
                IdUsuarioLogado = IdUsuarioLogado,
                Token = Token
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("cancelar")]
        public async Task<ActionResult> CancelarEvento([FromRoute] int idEvento)
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
