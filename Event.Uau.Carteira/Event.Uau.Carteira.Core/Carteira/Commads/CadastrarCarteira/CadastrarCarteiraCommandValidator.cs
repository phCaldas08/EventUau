using System;
using System.Linq;
using Event.Uau.Comum.Util.Mediator;
using FluentValidation;

namespace Event.Uau.Carteira.Core.Carteira.Commads.CadastrarCarteira
{
    public class CadastrarCarteiraCommandValidator  : AbstractValidator<CadastrarCarteiraCommand>
    {
        public CadastrarCarteiraCommandValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i.IdUsuarioLogado)
                .Must(idUsuario => !context.Carteiras.Any(i => i.IdUsuario == idUsuario))
                .WithMessage("Carteira já cadastrada para o usuário.");
        }
    }
}
