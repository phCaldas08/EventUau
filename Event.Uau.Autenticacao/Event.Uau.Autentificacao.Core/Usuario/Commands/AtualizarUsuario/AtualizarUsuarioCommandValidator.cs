using System;
using Event.Uau.Autenticacao.Persistence;
using FluentValidation;
using Event.Uau.Comum.Util.Extensoes;
using System.Linq;

namespace Event.Uau.Autenticacao.Core.Usuario.Commands.AtualizarUsuario
{
    public class AtualizarUsuarioCommandValidator : AbstractValidator<AtualizarUsuarioCommand>
    {
        public AtualizarUsuarioCommandValidator(EventUauDbContext context)
        {
            RuleFor(i => i.DataNascimento)
                .LessThanOrEqualTo(DateTime.Today.AddYears(-16))
                .WithMessage("A idade mínima é de 16 anos");

            RuleFor(i => i.DataNascimento)
                .GreaterThanOrEqualTo(DateTime.Today.AddYears(-100))
                .WithMessage("Data de nascimento inválida.");

            RuleFor(i => i.Nome)
                .Length(2, 250)
                .WithMessage("O nome deve ter entre 2 e 250 letras.");

            RuleFor(i => i.Telefone)
                .Must(telefone => telefone.TelefoneValido())
                .WithMessage("Telefone inválido.");

            RuleFor(i => i.Telefone.LimparTelefone())
                .Must(telefone => !context.Usuarios.Any(i => i.Telefone == telefone))
                .WithMessage("Telefone já cadastrado.");
        }
    }
}
