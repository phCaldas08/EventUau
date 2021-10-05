using System;
using System.Threading.Tasks;
using Event.Uau.Autenticacao.Core.Authentication.Autenticacao.Commands.Login;
using Event.Uau.Autenticacao.Core.Usuario.Commands.AtualizarUsuario;
using Event.Uau.Autenticacao.Core.Usuario.Commands.CadastrarUsuario;
using Event.Uau.Autenticacao.Core.Usuario.Queries.BuscaUsuarioPorId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Autenticacao.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CriarUsuario([FromBody] CadastrarUsuarioCommand body)
        {
            var user = await Mediator.Send(body);

            return Ok(user);
        }

        [HttpPost("{email}/login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromRoute] string email, [FromBody] LoginCommand body)
        {
            body.Email = email;
            var user = await Mediator.Send(body);

            return Ok(user);
        }

        [HttpGet("{idUsuario}")]
        [AllowAnonymous]
        public async Task<ActionResult> BuscaUsuarioPorId([FromRoute] int idUsuario)
        {
            var request = new BuscaUsuarioPorIdQuery { IdUsuario = idUsuario };
            var usuario = await Mediator.Send(request);

            return Ok(usuario);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarUsuario([FromBody] AtualizarUsuarioCommand body)
        {
            body.IdUsuarioLogado = IdUsuarioLogado;
            body.Token = Token;

            var result = await Mediator.Send(body);

            return Ok(result);
        }
    }
}
