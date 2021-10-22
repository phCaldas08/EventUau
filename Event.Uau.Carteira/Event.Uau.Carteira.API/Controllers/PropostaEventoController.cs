using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Carteira.Core.PropostaEvento.Commands.FinalizarPropostasEvento;
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
        
    }
}
