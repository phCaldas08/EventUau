using System.Linq;
using FluentValidation;

namespace Event.Uau.Autenticacao.Core.Parceiro.Queries.BuscarParceiros
{
    public class BuscarParceirosQueryValidator : AbstractValidator<BuscarParceirosQuery>
    { 
        public BuscarParceirosQueryValidator()
        {
            RuleFor(i => i.Indice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O índice não pode ser negativo.");

            RuleFor(i => i.TamanhoPagina)
                .GreaterThan(0)
                .LessThanOrEqualTo(20)
                .WithMessage("O tamanho da página deve estar entre 1 e 20.");

            RuleFor(i => i.ChaveOrdenacao)
                .Must(chave => BuscarParceirosQuerySettings.DicionarioOrdenacao.Keys.Contains(chave))
                .WithMessage("Ordenação não suportada.");

        }
    }
}
