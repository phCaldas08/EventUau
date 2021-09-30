using System;
using System.Linq;
using FluentValidation;

namespace Event.Uau.Upload.Core.Arquivo.Commands.DeletarArquivo
{
    public class DeletarArquivoCommandValidator : AbstractValidator<DeletarArquivoCommand>
    {
        public DeletarArquivoCommandValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(i => new { i.IdContexto, i.Contexto, i.IdUsuarioLogado })

                .Must(chave => context.Arquivos.Any(i => i.IdContexto == chave.IdContexto
                                                      && i.Contexto.Equals(chave.Contexto, StringComparison.CurrentCultureIgnoreCase)
                                                      && i.IdUsuario == chave.IdUsuarioLogado))
                .WithMessage("Usuário não tem permissão para deletar o arquivo.");
        }
    }
}
