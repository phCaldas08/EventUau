using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Proposta.Commands.EnviarPropostaFuncionario;
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
    }
}
