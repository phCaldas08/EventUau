using System;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Endereco.Infrastructure.Cep.Interfaces;
using FluentValidation;

namespace Event.Uau.Endereco.Core.Enderecos.Commands.AtualizarEndereco
{
    public class AtualizarEnderecoCommandValidator : AbstractValidator<AtualizarEnderecoCommand>
    {
        public AtualizarEnderecoCommandValidator(Persistence.EventUauDbContext context, ICepIntegracao cepIntegracao)
        {
            RuleFor(i => i)
                .Must(query => context.Enderecos.Any(i => i.Id == query.IdEndereco
                                                        && i.IdExterno == query.IdExterno
                                                        && i.TipoEndereco.Descricao.Equals(query.TipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Endereço não cadastrado.");

            RuleFor(endereco => endereco.TipoEndereco)
                .Must(tipoEndereco => context.TiposEnderecos.Any(i => i.Descricao.Equals(tipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Tipo de endereço não encontrado.");

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


            RuleFor(i => i.Cep)
                .MustAsync((cep, c) => Task.Run(async () => await cepIntegracao.BuscarEnderecoPorCep(cep) != null))
                .WithMessage("CEP não encontrado.");
        }
    }
}
