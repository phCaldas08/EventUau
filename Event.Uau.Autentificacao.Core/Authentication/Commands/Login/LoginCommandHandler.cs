using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Autentificacao.Core.Helpers;
using Event.Uau.Autentificacao.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autentificacao.Core.Authentication.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly EventUauDbContext context;

        public LoginCommandHandler(EventUauDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(i => i.Username.Equals(request.UserName, StringComparison.CurrentCultureIgnoreCase) && i.Password.Equals(request.Password));

            var token = TokenService.GenerateToken(user);

            return token;
        }
    }
}
