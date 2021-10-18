using System;
using System.Linq;
using Event.Uau.Evento.Persistence;
using FluentValidation;

namespace Event.Uau.Evento.Core.Proposta.Queries.BuscarPropostaPorId
{
    public class BuscaProspostaPorIdQueryValidator : AbstractValidator<BuscaProspostaPorIdQuery>
    {
        public BuscaProspostaPorIdQueryValidator(EventUauDbContext context)
        {
            RuleFor(i => i)
                .Must(request => context.Funcionarios.Any(i => i.IdEvento == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado))
                .WithMessage("Funcionário não encontrado para o evento.");
        }
    }
}
