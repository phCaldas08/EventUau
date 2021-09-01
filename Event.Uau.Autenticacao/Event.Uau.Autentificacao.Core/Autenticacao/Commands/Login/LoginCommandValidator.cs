using System.Linq;
using Event.Uau.Comum.Util.Extensoes;
using FluentValidation;

namespace Event.Uau.Autenticacao.Core.Authentication.Autenticacao.Commands.Login
{
    class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i)
                .Must(i => {
                    var user = context.Usuarios.FirstOrDefault(u => u.Email.Equals(i.Email));
                    return user != null && user.Senha == i.Senha.ToHash();
                 })
                .WithMessage("Usuário não encontrado.");
        }

    }
}
