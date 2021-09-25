using System;
using System.Linq;
using FluentValidation;

namespace Event.Uau.Endereco.Core.TiposEnderecos.Queries.BuscarTipoEnderecoPorId
{
    public class BuscarTipoEnderecoPorIdQueryValidator : AbstractValidator<BuscarTipoEnderecoPorIdQuery>
    {
        public BuscarTipoEnderecoPorIdQueryValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i)
                .Must(tipoEndereco => context.TiposEnderecos.Any(i => i.Id == tipoEndereco.IdTipoEndereco))
                .WithMessage("Tipo de endereço não encontrado.");
        }
    }
}
