using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Carteira.Core.Carteira.Commads.CadastrarCarteira;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Carteira.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class CarteirasController : BaseController
    {

        [HttpPost]
        public async Task<ActionResult> CadastrarCarteira([FromBody] CadastrarCarteiraCommand command)
        {
            command.IdUsuarioLogado = IdUsuarioLogado;
            command.Token = Token;

            var result = await Mediator.Send(command);

            return Ok(result);
        }

    }
}
