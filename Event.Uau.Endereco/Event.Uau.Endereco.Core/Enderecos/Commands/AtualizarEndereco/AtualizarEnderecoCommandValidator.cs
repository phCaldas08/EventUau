using System;
using System.Linq;
using FluentValidation;

namespace Event.Uau.Endereco.Core.Enderecos.Commands.AtualizarEndereco
{
    public class AtualizarEnderecoCommandValidator : AbstractValidator<AtualizarEnderecoCommand>
    {
        public AtualizarEnderecoCommandValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i)
                .Must(query => context.Enderecos.Any(i => i.Id == query.IdEndereco
                                                        && i.IdExterno == query.IdExterno
                                                        && i.TipoEndereco.Descricao.Equals(query.TipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Endereço não cadastrado.");

            RuleFor(endereco => endereco.TipoEndereco)
                .Must(tipoEndereco => context.TiposEnderecos.Any(i => i.Descricao.Equals(tipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Tipo de endereço não encontrado.");

            RuleFor(i => i.Nome)
                .NotEmpty()
                .Length(3, 255)
                .WithMessage("O endereço é obrigatório.");

            RuleFor(i => i.Numero)
                .NotEmpty()
                .Length(3, 255)
                .WithMessage("O número é obrigatório.");


            RuleFor(i => i.IdExterno)
                .GreaterThan(0)
                .WithMessage("Id inválido.");

            RuleFor(i => i.Latitude)
                .NotEmpty()
                .Length(3, 255)
                .WithMessage("A latitude é obrigatória.");

            RuleFor(i => i.Longitude)
                .NotEmpty()
                .Length(3, 255)
                .WithMessage("A longitude é obrigatória.");
        }
    }
}
