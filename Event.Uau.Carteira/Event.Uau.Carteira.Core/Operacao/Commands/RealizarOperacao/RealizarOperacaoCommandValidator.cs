using System;
using System.Linq;
using FluentValidation;

namespace Event.Uau.Carteira.Core.Operacao.Commands.RealizarOperacao
{
    public class RealizarOperacaoCommandValidator : AbstractValidator<RealizarOperacaoCommand>
    {
        public RealizarOperacaoCommandValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i.TipoOperacao)
                .Must(tipoOperacao => context.TiposOperacoes.Any(i => i.EhDisponivel && i.Descricao.Equals(tipoOperacao, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Tipo de operação não suportado.");

            RuleFor(i => i.Valor)
                .GreaterThan(0)
                .WithMessage("O valor da operação deve ser maior que 0.");
        }
    }
}
