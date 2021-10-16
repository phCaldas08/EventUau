using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Carteira.Core.Carteira.Commads.CadastrarCarteira;
using Event.Uau.Carteira.Core.Carteira.Queries.BuscarCarteiraPorUsuario;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Carteira.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class CarteirasController : BaseController
    {
        [HttpGet("extrato")]
        public async Task<ActionResult> BuscarExtrato([FromQuery] BuscarCarteiraPorUsuarioQuery query)
        {
            query.IdUsuarioLogado = IdUsuarioLogado;
            query.Token = Token;

            var result = await Mediator.Send(query);

            return Ok(result);
        }

    }
}
