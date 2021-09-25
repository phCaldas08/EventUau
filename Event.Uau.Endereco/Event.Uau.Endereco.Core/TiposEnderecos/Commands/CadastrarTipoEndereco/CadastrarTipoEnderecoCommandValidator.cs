using System;
using System.Linq;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Endereco.ViewModel.Endereco;
using FluentValidation;

namespace Event.Uau.Endereco.Core.TiposEnderecos.Commands.CadastrarTipoEndereco
{
    public class CadastrarTipoEnderecoCommandValidator : AbstractValidator<CadastrarTipoEnderecoCommand>
    {
        public CadastrarTipoEnderecoCommandValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i.Descricao)
                .Must(desc => !context.TiposEnderecos.Any(i => i.Descricao.Equals(desc, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Tipo de endereço já existe.");
        }
    }
}
