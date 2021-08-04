using System;
using System.Linq;
using FluentValidation;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Authentication.User.Commands.Login
{
    class LoginCommandValidator : FluentValidation.AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i)
                .Must(i => context.Users.Any(u => u.UserName.Equals(i.UserName) && u.Password.Equals(i.Password)))
                .WithMessage("Usuário não encontrado.");
        }

    }
}
