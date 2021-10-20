using System;
using System.Linq;
using Event.Uau.Evento.Persistence;
using FluentValidation;

namespace Event.Uau.Evento.Core.Status.Commands.CadastrarStatus
{
    public class CadastrarStatusCommandValidator : AbstractValidator<CadastrarStatusCommand>
    {
        public CadastrarStatusCommandValidator(EventUauDbContext context)
        {
            RuleFor(i => i.Id)
                .Must(id => !context.StatusContratacoes.Any(i => i.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Status de contratacão já cadastrado.");
        }
    }
}
