using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Upload.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Upload.Core.Arquivo.Commands.UploadArquivos
{
    public class UploadArquivosCommandValidator : AbstractValidator<UploadArquivosCommand>
    {
        public UploadArquivosCommandValidator(EventUauDbContext context)
        {
            RuleFor(i => new { i.IdContexto, i.Contexto, i.IdUsuarioLogado })

                .Must(chave => context.Arquivos.Any(i => i.IdContexto == chave.IdContexto
                                                      && i.Contexto.Equals(chave.Contexto, StringComparison.CurrentCultureIgnoreCase)
                                                      && i.IdUsuario == chave.IdUsuarioLogado))

                .When(chave => context.Arquivos.Any(i => i.IdContexto == chave.IdContexto
                                                      && i.Contexto.Equals(chave.Contexto, StringComparison.CurrentCultureIgnoreCase)))

                .WithMessage("Usuário não tem permissão para alterar o arquivo.");

            RuleFor(i => i.Conteudo)
                .NotEmpty()
                .WithMessage("O arquivo não pode ser vazio.");
                        
        }
    }
}
