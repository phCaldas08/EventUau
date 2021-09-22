using System;
using System.Linq;
using FluentValidation;
using Event.Uau.Comum.Util.Extensoes;

namespace Event.Uau.Autenticacao.Core.Especialidade.Commands.CadastrarEspecialidade
{
    public class CadastrarEspecialidadeCommandValidator : AbstractValidator<CadastrarEspecialidadeCommand>
    {
        public CadastrarEspecialidadeCommandValidator(Persistence.EventUauDbContext context)
        {

            RuleFor(i => i.Descricao)
                .Must(descricao => !context.Especialidades.Any(i => i.Descricao.Equals(descricao)))
                .WithMessage("Especialidade informada já existe.");

            RuleFor(i => i.Descricao)
                .Length(2, 30)
                .WithMessage("A especialidade deve ter entre 2 e 30 caracteres.");
        }
    }
}
