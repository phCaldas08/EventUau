using System.Threading.Tasks;
using Event.Uau.Autenticacao.Core.Authentication.User.Commands.Create;
using Event.Uau.Autenticacao.Core.Authentication.User.Commands.Login;
using Event.Uau.Autenticacao.Core.Authentication.User.Commands.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Autenticacao.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Create([FromBody] CreateCommand body)
        {
            var user = await Mediator.Send(body);

            return Ok(user);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginCommand body)
        {
            var user = await Mediator.Send(body);

            return Ok(user);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateCommand body)
        {
            var token = await Mediator.Send(body);

            return Ok(token);

        }
    }
}
