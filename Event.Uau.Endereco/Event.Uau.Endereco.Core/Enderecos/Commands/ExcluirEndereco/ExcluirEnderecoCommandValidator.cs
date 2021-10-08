using System;
using System.Linq;
using Event.Uau.Endereco.Persistence;
using FluentValidation;

namespace Event.Uau.Endereco.Core.Enderecos.Commands.ExcluirEndereco
{
    public class ExcluirEnderecoCommandValidator : AbstractValidator<ExcluirEnderecoCommand>
    {
        public ExcluirEnderecoCommandValidator(EventUauDbContext context)
        {
            RuleFor(i => new { i.IdEndereco, i.IdExterno, i.IdUsuarioLogado, i.TipoEndereco })
                .Must(obj => context.Enderecos.Any(i => i.Id == obj.IdEndereco && i.IdExterno == obj.IdExterno && i.TipoEndereco.Descricao.Equals(obj.TipoEndereco, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Endereço não encontrado.");
        }
    }
}
