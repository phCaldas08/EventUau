using System;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Endereco.Infrastructure.Cep.Interfaces;
using FluentValidation;

namespace Event.Uau.Endereco.Core.Enderecos.Commands.CadastrarEndereco
{
    public class CadastrarEnderecoCommandValidator : AbstractValidator<CadastrarEnderecoCommand>
    {
        public CadastrarEnderecoCommandValidator(Persistence.EventUauDbContext context, ICepIntegracao cepIntegracao)
        {
            RuleFor(endereco => endereco)
                .Must(endereco => !context.Enderecos.Any(i => i.TipoEndereco.Descricao.Equals(endereco.TipoEndereco.Descricao, StringComparison.CurrentCultureIgnoreCase)
                                                            && i.IdExterno == endereco.IdExterno
                                                            && i.Cep == endereco.Cep
                                                            && i.Numero.Equals(endereco.Numero, StringComparison.CurrentCultureIgnoreCase)
                                                            && i.Complemento.Equals(endereco.Complemento, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Endereço já existente.");

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
                .When(i => i.Bairro != null || i.Logradouro != null || i.Cidade != null || i.Estado != null)
                .WithMessage("CEP não encontrado.");

        }
    }
}
