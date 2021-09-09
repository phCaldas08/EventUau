using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Autenticacao.Core.Especialidade.Queries.BuscaEspecialidadePorId;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Autenticacao.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class EspecialidadeController : BaseController
    {

        [HttpGet("{idEspecialidade}")]
        public async Task<IActionResult> BuscaEspecialidadePorId([FromRoute] int idEspecialidade)
        {
            var query = new BuscaEspecialidadePorIdQuery { IdEspecialidade = idEspecialidade };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

    }
}
