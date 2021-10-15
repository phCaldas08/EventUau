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
        [HttpPost("{TipoOperacao}")]
        public async Task<ActionResult> RealizarOperacao([FromBody] RealizarOperacaoCommand body)
        {
            body.IdUsuarioLogado = IdUsuarioLogado;
            body.Token = Token;

            var result = await Mediator.Send(body);

            return Ok(result);
        }

        [HttpPost("prosposta")]
        
    }
}
