using System;
using System.Linq;
using FluentValidation;
using Event.Uau.Comum.Util.Extensoes;

namespace Event.Uau.Autenticacao.Core.Especialidade.Queries.BuscaEspecialidadePorId
{
    public class BuscarEspecialidadePorIdValidator : AbstractValidator<BuscaEspecialidadePorIdQuery>
    {
        public BuscarEspecialidadePorIdValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => i.IdEspecialidade)
                .Must(Id => context.Especialidades.Any(i => i.Id.Equals(Id)))
                .WithMessage("Especialidade não existe.");
        }
    }
}
