using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Carteira.Core.Carteira.Commads.CadastrarCarteira;
using Event.Uau.Carteira.Core.Operacao.Commands.RealizarOperacao;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Carteira.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class OperacoesController : BaseController
    {
        [HttpPost("{tipoOperacao}")]
        public async Task<ActionResult> RealizarOperacao([FromRoute] string tipoOperacao, [FromBody] RealizarOperacaoCommand body)
        {
            body.IdUsuarioLogado = IdUsuarioLogado;
            body.Token = Token;
            body.TipoOperacao = tipoOperacao;

            var result = await Mediator.Send(body);

            return Ok(result);
        }

    }
}
