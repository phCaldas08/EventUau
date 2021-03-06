using System;
using System.Linq;
using FluentValidation;

namespace Event.Uau.Autenticacao.Core.Parceiro.Commands.CadastrarParceiro
{
    class CadastrarParceiroCommandValidator : AbstractValidator<CadastrarParceiroCommand>
    {
        public CadastrarParceiroCommandValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i.IdUsuarioLogado)
                .Must(id => context.Usuarios.Any(i => i.Id == id))
                .WithMessage("Usuário não encontrado.");

            RuleFor(i => i.IdUsuarioLogado)
                .Must(id => !context.Parceiros.Any(i => i.IdUsuario == id))
                .WithMessage("O usuário já é um parceiro.");

            RuleFor(i => i.ValorHora)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor deve ser positivo e maior que zero.");

            RuleFor(i => i.Especialidades.Select(i => i.Id))
                .Must(especialidades => especialidades.All(e => context.Especialidades.Any(i => i.Id == e)))
                .When(i => (i.Especialidades?.Any()).GetValueOrDefault(false))
                .WithMessage("Especialidades não encontrada.");
        }
    }
}
