using System;
using System.Linq;
using Event.Uau.Autenticacao.Core.Helpers;
using FluentValidation;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Authentication.Autenticacao.Commands.Login
{
    class LoginCommandValidator : FluentValidation.AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i)
                .Must(i => {
                    var user = context.Usuarios.FirstOrDefault(u => u.Email.Equals(i.Email));
                    return user != null ? user.Senha == i.Senha.ToHash() : false;
                 })
                .WithMessage("Usuário não encontrado.");
        }

    }
}
