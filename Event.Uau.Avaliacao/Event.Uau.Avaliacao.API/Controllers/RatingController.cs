﻿using System.Threading.Tasks;
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

        //[HttpPut("{idEndereco}")]
        //public async Task<ActionResult> AtualizarEndereco([FromRoute] string tipoEndereco, [FromRoute] int idExterno, [FromRoute] int idEndereco, [FromBody] AtualizarEnderecoCommand body)
        //{
        //    body.TipoEndereco = new TipoEnderecoViewModel { Descricao = tipoEndereco };
        //    body.Token = Token;
        //    body.IdUsuarioLogado = IdUsuarioLogado;
        //    body.IdEndereco = idEndereco;
        //    body.IdExterno = idExterno;

        //    var result = await Mediator.Send(body);

        //    return Ok(result);
        //}

        //[HttpDelete("{idEndereco}")]
        //public async Task<ActionResult> ExcluirEndereco([FromRoute] string tipoEndereco, [FromRoute] int idExterno, [FromRoute] int idEndereco)
        //{
        //    var command = new ExcluirEnderecoCommand
        //    {
        //        IdEndereco = idEndereco,
        //        IdExterno = idExterno,
        //        IdUsuarioLogado = IdUsuarioLogado,
        //        TipoEndereco = tipoEndereco,
        //        Token = Token,
        //    };

        //    var result = await Mediator.Send(command);

        //    return Ok(result);
        //}
    }
}