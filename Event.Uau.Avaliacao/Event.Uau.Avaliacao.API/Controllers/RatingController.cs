using System.Threading.Tasks;
using Event.Uau.Avaliacao.API.Controllers;
using Event.Uau.Avaliacao.Core.Rating.Commands.CadastrarRating;
using Event.Uau.Avaliacao.Core.Rating.Queries.BuscarRatingPorId;
using Event.Uau.Avaliacao.Core.Rating.Queries.BuscarRatings;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Endereco.API.Controllers
{
    [Route("api/rating")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class RatingController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> BuscarRatings([FromQuery] BuscarRatingsQuery query)
        {
            query.IdUsuarioLogado = IdUsuarioLogado;
            query.Token = Token;

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{idRating}")]
        public async Task<ActionResult> BuscarRatingPorId([FromRoute] int idRating)
        {
            var query = new BuscarRatingPorIdQuery
            {
                IdUsuarioLogado = IdUsuarioLogado,
                Token = Token,
                IdRating = idRating
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarRating([FromBody] CadastrarRatingCommand body)
        {
            body.Token = Token;
            body.IdUsuarioLogado = IdUsuarioLogado;

            var result = await Mediator.Send(body);

            return Ok(result);
        }

    }
}
