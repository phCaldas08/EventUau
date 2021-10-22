using System;
using System.Linq;
using Event.Uau.Carteira.Persistence;
using FluentValidation;

namespace Event.Uau.Carteira.Core.TipoOperacao.Commands.CadastrarTipoOperacao
{
    public class CadastrarTipoOperacaoCommandValidator : AbstractValidator<CadastrarTipoOperacaoCommand>
    {
        public CadastrarTipoOperacaoCommandValidator(EventUauDbContext context)
        {
            RuleFor(i => i.Descricao)
                .Must(descricao => !context.TiposOperacoes.Any(i => i.Descricao.Equals(descricao, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Descricao já cadastrada.");

            RuleFor(i => i.Id)
                .Must(Id => !context.TiposOperacoes.Any(i => i.Descricao.Equals(Id, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Tipo operação já cadastrada.");
        }
    }
}
