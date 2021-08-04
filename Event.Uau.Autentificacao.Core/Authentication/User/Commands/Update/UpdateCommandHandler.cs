using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Autenticacao.Core.Helpers;
using Event.Uau.Autenticacao.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autenticacao.Core.Authentication.User.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, string>
    {
        private readonly EventUauDbContext context;

        public UpdateCommandHandler(EventUauDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(i => i.UserName.Equals(request.Username, StringComparison.CurrentCultureIgnoreCase) && i.Password.Equals(request.Password));

            user.Password = request.NewPassword;

            await context.SaveChangesAsync(cancellationToken);

            var token = TokenService.GenerateToken(user);

            return token;
        }
    }
}
