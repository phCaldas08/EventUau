using System;
using System.Linq;
using Event.Uau.Autenticacao.Core.Parceiro.Commands.AtualizarParceiro;
using FluentValidation;

namespace Event.Uau.Autenticacao.Core.Parceiro.Commands.AtualizarParceiro
{
    class AtualizarParceiroCommandValidator : AbstractValidator<AtualizarParceiroCommand>
    {
        public AtualizarParceiroCommandValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i.IdUsuario)
                .Must(id => context.Usuarios.Any(i => i.Id == id))
                .WithMessage("Usuário não encontrado.");

            RuleFor(i => i.IdUsuario)
                .Must(id => context.Parceiros.Any(i => i.IdUsuario == id))
                .WithMessage("Parceiro não encontrado.");

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
