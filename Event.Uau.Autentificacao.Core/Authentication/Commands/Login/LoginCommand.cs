using System;
using MediatR;

namespace Event.Uau.Autentificacao.Core.Authentication.Commands.Login
{
    public class LoginCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
