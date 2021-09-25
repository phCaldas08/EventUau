using System;
using System.Linq;
using FluentValidation;

namespace Event.Uau.Endereco.Core.Enderecos.Queries.BuscarEnderecoPorId
{
    public class BuscarEnderecoPorIdQueryValidator : AbstractValidator<BuscarEnderecoPorIdQuery>
    {
        public BuscarEnderecoPorIdQueryValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i)
                .Must(query => context.Enderecos.Any(i => i.Id == query.IdEndereco
                                                        && i.IdExterno == query.IdExterno
                                                        && i.TipoEndereco.Descricao.Equals(query.TipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Endereço não cadastrado.");


            RuleFor(endereco => endereco.TipoEndereco)
                .Must(tipoEndereco => context.TiposEnderecos.Any(i => i.Descricao.Equals(tipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Tipo de endereço não encontrado.");
        }
    }
}
