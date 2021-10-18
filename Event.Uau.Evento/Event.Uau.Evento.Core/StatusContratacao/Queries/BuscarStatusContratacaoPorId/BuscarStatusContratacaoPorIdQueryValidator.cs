using System;
using System.Linq;
using Event.Uau.Evento.Persistence;
using FluentValidation;

namespace Event.Uau.Evento.Core.StatusContratacao.Queries.BuscarStatusContratacaoPorId
{
    public class BuscarStatusContratacaoPorIdQueryValidator : AbstractValidator<BuscarStatusContratacaoPorIdQuery>
    {
        public BuscarStatusContratacaoPorIdQueryValidator(EventUauDbContext context)
        {
            RuleFor(i => i.Id)
                .Must(id => context.StatusContratacoes.Any(i => i.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Status contratação não encontrado.");
        }
    }
}
