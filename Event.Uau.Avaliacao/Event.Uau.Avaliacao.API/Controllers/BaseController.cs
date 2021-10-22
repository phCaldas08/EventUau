using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Event.Uau.Comum.Configuracao.Helpers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Event.Uau.Avaliacao.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class BaseController : Controller
    {
        private IMediator mediator;

        protected IMediator Mediator => mediator ?? (mediator = HttpContext.RequestServices.GetService<IMediator>());

        private string token;

        protected string Token => token ??= Request.Headers["Authorization"].ToString().Substring(7, Request.Headers["Authorization"].ToString().Length - 7);

        protected int IdUsuarioLogado => Token.ConsultarId() ?? 0;

        override public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();
        }
    }
}
