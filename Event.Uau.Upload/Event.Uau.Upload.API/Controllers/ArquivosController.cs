using System;
using System.IO;
using System.Threading.Tasks;
using Event.Uau.Upload.Core.Arquivo.Commands.DeletarArquivo;
using Event.Uau.Upload.Core.Arquivo.Commands.UploadArquivos;
using Event.Uau.Upload.Core.Arquivo.Queries.DownloadArquivos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Upload.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class ArquivosController : BaseController
    {
        [HttpPost("{idContexto}/{contexto}")]
        public async Task<ActionResult> UploadArquivo([FromRoute] int idContexto, [FromRoute] string contexto, [FromForm] IFormFile arquivo)
        {
            using var stream = new MemoryStream();
            await arquivo?.CopyToAsync(stream);

            var command = new UploadArquivosCommand
            {
                Conteudo = stream.ToArray(),
                Contexto = contexto,
                IdContexto = idContexto,
                IdUsuarioLogado = IdUsuarioLogado,
                Nome = arquivo.FileName,
                Token = Token,
                TipoConteudo = arquivo.ContentType
            };

            await Mediator.Send(command);

            return Ok();
        }

        [HttpGet("{idContexto}/{contexto}")]
        public async Task<ActionResult> DownloadArquivo([FromRoute] int idContexto, [FromRoute] string contexto, [FromQuery] DownloadArquivosQuery query)
        {
            query.Contexto = contexto;
            query.IdContexto = idContexto;
            query.Token = Token;
            query.IdUsuarioLogado = IdUsuarioLogado;

            var result = await Mediator.Send(query);

            return File(result.Conteudo, result.TipoConteudo, result.Nome);
        }

        [HttpDelete("{idContexto}/{contexto}")]
        public async Task<ActionResult> DeletarArquivo([FromRoute] int idContexto, [FromRoute] string contexto)
        {
            var command = new DeletarArquivoCommand
            {
                Contexto = contexto,
                IdContexto = idContexto,
                IdUsuarioLogado = IdUsuarioLogado,
                Token = Token,
            };

            await Mediator.Send(command);

            return Ok();
        }
    }
}
