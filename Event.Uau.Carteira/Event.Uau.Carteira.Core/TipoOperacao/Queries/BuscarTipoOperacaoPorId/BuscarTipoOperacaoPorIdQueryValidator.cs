using System;
using System.Linq;
using Event.Uau.Carteira.Persistence;
using FluentValidation;

namespace Event.Uau.Carteira.Core.TipoOperacao.Queries.BuscarTipoOperacaoPorId
{
    public class BuscarTipoOperacaoPorIdQueryValidator : AbstractValidator<BuscarTipoOperacaoPorIdQuery>
    {
        public BuscarTipoOperacaoPorIdQueryValidator(EventUauDbContext context)
        {
            RuleFor(i => i.IdTipoOperacao)
                .Must(id => context.TiposOperacoes.Any(i => i.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Tipo de operação não encontrado.");
        }
    }
}
