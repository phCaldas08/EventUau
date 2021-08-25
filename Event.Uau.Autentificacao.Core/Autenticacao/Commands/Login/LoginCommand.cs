using System;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Authentication.Autenticacao.Commands.Login
{
    public class LoginCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
