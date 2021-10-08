using System.Threading.Tasks;
using Event.Uau.Endereco.Core.Enderecos.Commands.AtualizarEndereco;
using Event.Uau.Endereco.Core.Enderecos.Commands.CadastrarEndereco;
using Event.Uau.Endereco.Core.Enderecos.Commands.ExcluirEndereco;
using Event.Uau.Endereco.Core.Enderecos.Queries.BuscarEnderecoPorId;
using Event.Uau.Endereco.Core.Enderecos.Queries.BuscarEnderecos;
using Event.Uau.Endereco.ViewModel.Endereco;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Endereco.API.Controllers
{
    [Route("api/{tipoEndereco}/{idExterno}/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class EnderecosController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> BuscarEnderecos([FromRoute] string tipoEndereco, [FromRoute] int idExterno)
        {
            var query = new BuscarEnderecosQuery
            {
                IdExterno = idExterno,
                IdUsuarioLogado = IdUsuarioLogado,
                TipoEndereco = new TipoEnderecoViewModel { Descricao = tipoEndereco },
                Token = Token
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{idEndereco}")]
        public async Task<ActionResult> BuscarEnderecoPorId([FromRoute] string tipoEndereco, [FromRoute] int idExterno, [FromRoute] int idEndereco)
        {
            var query = new BuscarEnderecoPorIdQuery
            {
                IdExterno = idExterno,
                IdUsuarioLogado = IdUsuarioLogado,
                IdEndereco = idEndereco,
                TipoEndereco = new TipoEnderecoViewModel { Descricao = tipoEndereco },
                Token = Token
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarEndereco([FromRoute] string tipoEndereco, [FromRoute] int idExterno, [FromBody] CadastrarEnderecoCommand body)
        {
            body.TipoEndereco = new TipoEnderecoViewModel { Descricao = tipoEndereco };
            body.Token = Token;
            body.IdUsuarioLogado = IdUsuarioLogado;
            body.IdExterno = idExterno;

            var result = await Mediator.Send(body);

            return Ok(result);
        }

        [HttpPut("{idEndereco}")]
        public async Task<ActionResult> AtualizarEndereco([FromRoute] string tipoEndereco, [FromRoute] int idExterno, [FromRoute] int idEndereco, [FromBody] AtualizarEnderecoCommand body)
        {
            body.TipoEndereco = new TipoEnderecoViewModel { Descricao = tipoEndereco };
            body.Token = Token;
            body.IdUsuarioLogado = IdUsuarioLogado;
            body.IdEndereco = idEndereco;
            body.IdExterno = idExterno;

            var result = await Mediator.Send(body);

            return Ok(result);
        }

        [HttpDelete("{idEndereco}")]
        public async Task<ActionResult> ExcluirEndereco([FromRoute] string tipoEndereco, [FromRoute] int idExterno, [FromRoute] int idEndereco)
        {
            var command = new ExcluirEnderecoCommand
            {
                IdEndereco = idEndereco,
                IdExterno = idExterno,
                IdUsuarioLogado = IdUsuarioLogado,
                TipoEndereco = tipoEndereco,
                Token = Token,
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
