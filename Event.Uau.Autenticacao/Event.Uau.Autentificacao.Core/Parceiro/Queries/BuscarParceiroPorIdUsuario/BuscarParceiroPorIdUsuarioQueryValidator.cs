using System;
using System.Linq;
using FluentValidation;

namespace Event.Uau.Autenticacao.Core.Parceiro.Queries.BuscarParceiroPorIdUsuario
{
    class BuscarParceiroPorIdUsuarioQueryValidator : AbstractValidator<BuscarParceiroPorIdUsuarioQuery>
    {
        public BuscarParceiroPorIdUsuarioQueryValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i.IdUsuario)
                .Must(id => context.Usuarios.Any(i => i.Id == id))
                .WithMessage("Usuário não encontrado.");

            RuleFor(i => i.IdUsuario)
                .Must(id => context.Parceiros.Any(i => i.IdUsuario == id))
                .WithMessage("O usuário ainda não é um parceiro.");
        }

    }
}
