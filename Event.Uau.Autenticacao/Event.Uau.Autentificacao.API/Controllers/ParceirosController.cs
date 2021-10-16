using System;
using System.Threading.Tasks;
using Event.Uau.Autenticacao.Core.Parceiro.Commands.AtualizarParceiro;
using Event.Uau.Autenticacao.Core.Parceiro.Commands.CadastrarParceiro;
using Event.Uau.Autenticacao.Core.Parceiro.Queries.BuscarParceiroPorIdUsuario;
using Event.Uau.Autenticacao.Core.Parceiro.Queries.BuscarParceiros;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Autenticacao.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class ParceirosController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> CadastrarParceiro([FromBody] CadastrarParceiroCommand body)
        {
            body.Token = Token;
            body.IdUsuarioLogado = IdUsuarioLogado;

            var parceiro = await Mediator.Send(body);

            return Ok(parceiro);
        }

        [HttpGet("{idUsuario}")]
        public async Task<ActionResult> BuscarParceiroPorIdUsuario([FromRoute] int idUsuario, [FromQuery] BuscarParceiroPorIdUsuarioQuery query)
        {
            query.IdUsuario = idUsuario;
            query.IdUsuarioLogado = IdUsuarioLogado;
            query.Token = Token;

            var parceiro = await Mediator.Send(query);

            return Ok(parceiro);
        }

        [HttpGet]
        public async Task<ActionResult> BuscarParceiros([FromQuery] BuscarParceirosQuery query)
        {
            query.IdUsuarioLogado = IdUsuarioLogado;
            query.Token = Token;

            var parceiro = await Mediator.Send(query);

            return Ok(parceiro);
        }

        [HttpPut("{idUsuario}")]
        public async Task<ActionResult> AtualizarUsuario([FromRoute] int idUsuario, [FromBody] AtualizarParceiroCommand body)
        {
            body.IdUsuario = idUsuario;
            body.IdUsuarioLogado = IdUsuarioLogado;
            body.Token = Token;

            var result = await Mediator.Send(body);

            return Ok(result);
        }

    }
}
