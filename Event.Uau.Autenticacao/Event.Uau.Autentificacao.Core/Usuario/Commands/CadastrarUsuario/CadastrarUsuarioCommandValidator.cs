using System;
using System.Linq;
using FluentValidation;
using Event.Uau.Comum.Util.Extensoes;

namespace Event.Uau.Autenticacao.Core.Usuario.Commands.CadastrarUsuario
{
    public class CadastrarUsuarioCommandValidator : AbstractValidator<CadastrarUsuarioCommand>
    {
        public CadastrarUsuarioCommandValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i.Email)
                .Must(email => !context.Usuarios.Any(i => i.Email.Equals(email)))
                .WithMessage("Nome de usuário já existente.");

            RuleFor(i => i.Senha)
                .Must(senha => senha.CanBeUsed())
                .WithMessage(PasswordValidator.Rule);

            RuleFor(i => i)
                .Must(i => i.Senha == i.ConfirmarSenha)
                .WithMessage("Senhas diferentes.");

            RuleFor(i => i.DataNascimento)
                .LessThanOrEqualTo(DateTime.Today.AddYears(-16))
                .WithMessage("A idade mínima é de 16 anos");

            RuleFor(i => i.DataNascimento)
                .GreaterThanOrEqualTo(DateTime.Today.AddYears(-100))
                .WithMessage("Data de nascimento inválida.");

            RuleFor(i => i.Nome)
                .Length(2, 250)
                .WithMessage("O nome deve ter entre 2 e 250 letras.");

            RuleFor(i => i.SobreNome)
                .Length(2, 250)
                .WithMessage("O sobrenome deve ter entre 2 e 250 letras.");

            RuleFor(i => i.Cpf)
                .Must(cpf => cpf.CpfValido())
                .WithMessage("CPF inválido.");

            RuleFor(i => i.Cpf)
                .Must(cpf => !context.Usuarios.Any(i => i.Cpf == cpf))
                .WithMessage("CPF já cadastrado.");

            RuleFor(i => i.Telefone)
                .Must(telefone => telefone.TelefoneValido())
                .WithMessage("Telefone inválido.");

            RuleFor(i => i.Telefone.LimparTelefone())
                .Must(telefone => !context.Usuarios.Any(i => i.Telefone == telefone))
                .WithMessage("Telefone já cadastrado.");
        }
    }
}
