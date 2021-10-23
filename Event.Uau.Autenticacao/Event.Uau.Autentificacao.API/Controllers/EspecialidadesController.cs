using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Autenticacao.Core.Especialidade.Queries.BuscaEspecialidadePorId;
using Event.Uau.Autenticacao.Core.Especialidade.Commands.CadastrarEspecialidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Event.Uau.Autenticacao.Core.Especialidade.Queries.BuscarEspecialidades;

namespace Event.Uau.Autenticacao.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class EspecialidadesController : BaseController
    {

        [HttpGet("{idEspecialidade}")]
        public async Task<IActionResult> BuscaEspecialidadePorId([FromRoute] int idEspecialidade)
        {
            var query = new BuscaEspecialidadePorIdQuery { IdEspecialidade = idEspecialidade };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CriarEspecialidade([FromBody] CadastrarEspecialidadeCommand body)
        {
            var especialidade = await Mediator.Send(body);

            return Ok(especialidade);
        }

        [HttpGet]
        public async Task<ActionResult> BuscarEspecialidades([FromQuery] BuscarEspecialidadesQuery query)
        {
            query.Token = Token;
            query.IdUsuarioLogado = IdUsuarioLogado;

            var result = await Mediator.Send(query);

            return Ok(result);
        }

    }
}
