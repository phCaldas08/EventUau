using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Autenticacao.Core.Helpers;
using Event.Uau.Autenticacao.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace Event.Uau.Autenticacao.Core.Authentication.Autenticacao.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly EventUauDbContext context;
        private readonly LoginCommandValidator validations;

        public LoginCommandHandler(EventUauDbContext context)
        {
            this.context = context;
            validations = new LoginCommandValidator(context);
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            validations.ValidateAndThrow(request);

            var usuario = await context.Usuarios.FirstOrDefaultAsync(i => i.Email.Equals(request.Email));

            var token = TokenService.GenerateToken(usuario);

            return token;
        }
    }
}
