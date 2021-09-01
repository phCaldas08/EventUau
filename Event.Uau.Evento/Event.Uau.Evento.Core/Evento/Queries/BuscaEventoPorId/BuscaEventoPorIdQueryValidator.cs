using System;
using System.Linq;
using FluentValidation;

namespace Event.Uau.Evento.Core.Evento.Queries.BuscaEventoPorId
{
    public class BuscaEventoPorIdQueryValidator : AbstractValidator<BuscaEventoPorIdQuery>
    {
        public BuscaEventoPorIdQueryValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(x => x.IdEvento)
                .Must(id => context.Eventos.Any(i => i.Id == id))
                .WithMessage("Evento não encontrado.");
        }
    }
}
