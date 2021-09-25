using System;
using System.Linq;
using Event.Uau.Endereco.Persistence;
using FluentValidation;

namespace Event.Uau.Endereco.Core.Enderecos.Queries.BuscarEnderecos
{
    public class BuscarEnderecosQueryValidator : AbstractValidator<BuscarEnderecosQuery>
    {
        public BuscarEnderecosQueryValidator(EventUauDbContext context)
        {

            RuleFor(endereco => endereco.TipoEndereco)
                .Must(tipoEndereco => context.TiposEnderecos.Any(i => i.Descricao.Equals(tipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Tipo de endereço não encontrado.");
        }
    }
}
