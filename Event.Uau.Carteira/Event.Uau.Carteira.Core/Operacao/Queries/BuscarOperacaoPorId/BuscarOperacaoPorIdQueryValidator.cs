using System;
using System.Linq;
using Event.Uau.Carteira.Persistence;
using FluentValidation;

namespace Event.Uau.Carteira.Core.Operacao.Queries.BuscarOperacaoPorId
{
    public class BuscarOperacaoPorIdQueryValidator : AbstractValidator<BuscarOperacaoPorIdQuery>
    {
        public BuscarOperacaoPorIdQueryValidator(EventUauDbContext context)
        {
            RuleFor(request => request)
                .Must(request => context.Operacoes.Any(i => i.Id == request.IdOperacao && i.IdUsuario == request.IdUsuarioLogado))
                .WithMessage("Operação não encontrada.");
        }
    }
}
