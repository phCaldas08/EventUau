using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Autentificacao.Core.Helpers;
using Event.Uau.Autentificacao.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autentificacao.Core.Authentication.Commands.Update
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
            var user = await context.Users.FirstOrDefaultAsync(i => i.Username.Equals(request.Username, StringComparison.CurrentCultureIgnoreCase) && i.Password.Equals(request.Password));

            user.Password = request.NewPassword;

            await context.SaveChangesAsync(cancellationToken);

            var token = TokenService.GenerateToken(user);

            return token;
        }
    }
}
