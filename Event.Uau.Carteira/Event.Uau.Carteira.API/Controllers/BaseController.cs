using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Event.Uau.Comum.Configuracao.Helpers;
using Event.Uau.Carteira.Core.Carteira.Commads.CadastrarCarteira;

namespace Event.Uau.Carteira.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class BaseController : Controller
    {
        private IMediator mediator;

        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected string UserName => User.Identity.Name;

        private string token;

        protected string Token => token ??= Request.Headers["Authorization"].ToString().Substring(7, Request.Headers["Authorization"].ToString().Length - 7);

        protected int IdUsuarioLogado => Token.ConsultarId() ?? 0;

        override public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await Mediator.Send(new Core.Inicializacao.Commands.InicializacaoCommand());
            await CadastraCarteira();

            await next();
        }

        private async Task CadastraCarteira()
        {
            try
            {
                var commandCarteira = new CadastrarCarteiraCommand
                {
                    IdUsuarioLogado = IdUsuarioLogado,
                    Token = Token,
                };

                await Mediator.Send(commandCarteira);
            }
            catch { }
        }
    }
}
