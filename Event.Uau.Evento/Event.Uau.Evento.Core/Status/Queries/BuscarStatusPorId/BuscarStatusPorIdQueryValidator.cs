using System;
using System.Linq;
using Event.Uau.Evento.Persistence;
using FluentValidation;

namespace Event.Uau.Evento.Core.Status.Queries.BuscarStatusPorId
{
    public class BuscarStatusPorIdQueryValidator : AbstractValidator<BuscarStatusPorIdQuery>
    {
        public BuscarStatusPorIdQueryValidator(EventUauDbContext context)
        {
            RuleFor(i => i.Id)
                .Must(id => context.Status.Any(i => i.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Status contratação não encontrado.");
        }
    }
}
