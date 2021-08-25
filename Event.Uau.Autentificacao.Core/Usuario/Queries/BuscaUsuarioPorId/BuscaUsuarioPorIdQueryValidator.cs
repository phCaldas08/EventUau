using System;
using System.Linq;
using FluentValidation;

namespace Event.Uau.Autenticacao.Core.Usuario.Queries.BuscaUsuarioPorId
{
    public class BuscaUsuarioPorIdQueryValidator : FluentValidation.AbstractValidator<BuscaUsuarioPorIdQuery>
    {
        public BuscaUsuarioPorIdQueryValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i.IdUsuario)
                .Must(i => context.Usuarios.Any(x => x.Id == i))
                .WithMessage("Usuário não encontrado.");

        }
    }
}
