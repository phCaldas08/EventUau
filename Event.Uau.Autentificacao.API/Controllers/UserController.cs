using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Autentificacao.Core.Authentication.Commands.Login;
using Event.Uau.Autentificacao.Core.Authentication.Commands.Update;
using Event.Uau.Autentificacao.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Autentificacao.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class UserController : BaseController
    {
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
