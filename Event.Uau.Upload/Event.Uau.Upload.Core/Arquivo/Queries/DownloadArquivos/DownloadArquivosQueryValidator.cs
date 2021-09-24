using System;
using System.Linq;
using Event.Uau.Upload.Persistence;
using FluentValidation;

namespace Event.Uau.Upload.Core.Arquivo.Queries.DownloadArquivos
{

    public class DownloadArquivosQueryValidator : AbstractValidator<DownloadArquivosQuery>
    {
        public DownloadArquivosQueryValidator(EventUauDbContext context)
        {
            RuleFor(i => new { i.Contexto, i.IdContexto })
                .Must(chave => context.Arquivos.Any(i => i.IdContexto == chave.IdContexto
                                                      && i.Contexto.Equals(chave.Contexto, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Nenhum arquivo encontrado.");
        }
    }

}
