using System;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Authentication.Autenticacao.Commands.Login
{
    public class LoginCommand : IRequest<LoginViewModel>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
