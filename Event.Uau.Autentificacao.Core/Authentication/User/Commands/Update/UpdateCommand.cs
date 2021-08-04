using System;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Authentication.User.Commands.Update
{
    public class UpdateCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
