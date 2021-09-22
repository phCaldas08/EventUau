using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Evento.Commands.CriarEvento;
using Event.Uau.Evento.Core.Evento.Queries.BuscaEventoPorId;
using Event.Uau.Evento.Core.Evento.Queries.ListarEventos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Evento.API.Controllers
{
    [Route("api/eventos/{idEvento}/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class FuncionariosController : BaseController
    {

        [HttpPost("propostas")]
        public async Task<IActionResult> BuscaEventoPorId([FromRoute] BuscaEventoPorIdQuery query)
        {
            query.IdUsuarioLogado = IdUsuarioLogado;
            query.Token = Token;

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
