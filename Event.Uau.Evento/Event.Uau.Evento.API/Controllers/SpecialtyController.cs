using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Especialidade.Queries.BuscaEspecialidadePorId;
using Event.Uau.Evento.Core.Evento.Commands.CriarEvento;
using Event.Uau.Evento.Core.Evento.Queries.BuscaEventoPorId;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Evento.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class SpecialtyController : BaseController
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
